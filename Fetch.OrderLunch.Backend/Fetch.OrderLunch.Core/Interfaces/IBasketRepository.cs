using Fetch.OrderLunch.Core.Entities.BasketAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.Core.Interfaces
{
    public  interface IBasketRepository : IRepository<Basket>
    {
        Task<Basket> GetAsync(string userId);
    }
}
