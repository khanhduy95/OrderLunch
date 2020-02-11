using Fetch.OrderLunch.WebApi.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Interfaces
{
    public interface IBasketService
    {
        Task CreateBasket(BasketInPut basketInPut);
        Task AddItemToBasket(BasketItemViewModel basketItem);
        Task UpdateBasket(BasketItemViewModel basketItem);
        Task<BasketViewModel> Getbasket();
        Task<bool> DeleteItemInBasket(int id);
    }
}
