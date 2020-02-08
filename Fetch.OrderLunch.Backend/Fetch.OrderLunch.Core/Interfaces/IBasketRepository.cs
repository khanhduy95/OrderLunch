using Fetch.OrderLunch.Core.Entities.BasketAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.Core.Interfaces
{
    public  interface IBasketRepository 
    {
        Basket Add(Basket basket);
        Task Delete(Basket basket);
        Task<Basket> GetAsync(string userId);
        Task<Basket> FindIdAsync(int id);
        IUnitOfWork UnitOfWork { get; }
    }
}
