using Dapper;
using Fetch.OrderLunch.Core.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Queries
{
    public class OrderQueries : IOrderQueries
    {
        private string _connectionString = string.Empty;

        public OrderQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<Order> GetOrder(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<dynamic>(
                    @"SELECT o.[Id] as OrderId, o.OrderDate as OrderDate, s.Name as StatusName, 
                    i.ProductName as ProductName,i.PictureUrl as Picture,i.UnitPrice as UnitPrice, i.Units as Units
                    FROM Orders o
                    LEFT JOIN OrderItems i on o.Id=i.Id
                    LEFT JOIN OrderStatus s on o.OrderStatusId=s.Id
                    WHERE o.Id=@id", new { id }
                    );

                if (result.AsList().Count == 0)
                    throw new KeyNotFoundException();
                
                return MapOrderItems(result);
            }
        }

        public async Task<IEnumerable<OrderPaid>> GetOrders()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<dynamic>(
                    @"SELECT o.[Id] as OrderId, o.OrderDate as OrderDate, s.Name as StatusName, 					
                    SUM(i.units*i.unitprice) as total
                    FROM Orders o
                    LEFT JOIN OrderItems i on o.Id=i.Id
                    LEFT JOIN OrderStatus s on o.OrderStatusId=s.Id                
					GROUP BY o.Id, o.OrderDate, s.Name"
                    );
                if (result.AsList().Count == 0)
                    throw new KeyNotFoundException();

                return MapOrdersPaid(result);
            }
        }

        private IEnumerable<OrderPaid> MapOrdersPaid(dynamic result)
        {
            var orders = new List<OrderPaid>();
            foreach (var item in result)
            {
                var order = new OrderPaid
                {
                    OrderNumber = item.OrderId,
                    Date = item.OrderDate,
                    Status = item.StatusName,
                    
                };

                orders.Add(order);
            }
            return orders;
        }

        private Order MapOrderItems(dynamic result)
        {
            var order = new Order
            {
                OrderNumber = result[0].OrderId,
                Date = result[0].OrderDate,
                Status = result[0].StatusName,
                OrderItems = new List<OrderItem>(),
                Total = 0
            };

            foreach (dynamic item in result)
            {
                var orderitem = new OrderItem
                {
                    ProductName = item.ProductName,
                    Units = item.Units,
                    UnitPrice = (double)item.UnitPrice,
                    PictureUrl = item.Picture
                };

                order.Total += item.Units * item.UnitPrice;
                order.OrderItems.Add(orderitem);
            }

            return order;
        }
    }
}
