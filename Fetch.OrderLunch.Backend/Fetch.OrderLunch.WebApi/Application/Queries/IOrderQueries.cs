
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Queries
{
    public interface IOrderQueries
    {
        Task<Order> GetOrder(int id);

        Task<IEnumerable<OrderPaid>> GetOrders();

    }
}
