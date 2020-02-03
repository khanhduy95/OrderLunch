using Fetch.OrderLunch.Core.Entities.OrderAggregate;
using Fetch.OrderLunch.Core.Interfaces;
using Fetch.OrderLunch.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.Infrastructure.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(OrderLunchContext dbContext) : base(dbContext)
        {
        }

        public Order AddOrder(Order order)
        {
            return _dbContext.Orders
                .Add(order)
                .Entity;
        }

        public async Task<Order> GetAsync(int orderId)
        {
            var order = await _dbContext.Orders
                .FirstOrDefaultAsync(x => x.Id == orderId);
            if (order == null)
            {
                order = _dbContext.Orders
                    .Local
                    .FirstOrDefault(x => x.Id == orderId);
            }
            if (order != null)
            {
                await _dbContext.Entry(order)
                    .Collection(i => i.OrderItems)
                    .LoadAsync();

                await _dbContext.Entry(order)
                    .Reference(i => i.OrderStatus)
                    .LoadAsync();
            }

            return order;
        }

        public void UpdateOrder(Order order)
        {
            _dbContext.Entry(order).State = EntityState.Modified;
           
        }
    }
}
