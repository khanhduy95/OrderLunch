using Fetch.OrderLunch.WebApi.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Interfaces
{
    public interface IBasketService
    {
        Task CreateBasket();
        Task AddItemToBasket(int basketId, int catalogItemId, decimal price, int quantity);
        Task SetQuantities(int basketId, Dictionary<string, int> quantities);
        Task DeleteBasketAsync(int basketId);
        Task<IEnumerable<BasketViewModel>> Getbasket(string buyerId);
    }
}
