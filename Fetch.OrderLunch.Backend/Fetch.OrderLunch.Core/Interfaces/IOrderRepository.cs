using Fetch.OrderLunch.Core.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.Core.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order AddOrder(Order order);

        void UpdateOrder(Order order);

        Task<Order> GetAsync(int orderId);
       
    }
}
