using Fetch.OrderLunch.Core.Entities.BasketAggregate;
using Fetch.OrderLunch.Core.Interfaces;
using Fetch.OrderLunch.WebApi.Application.Interfaces;
using Fetch.OrderLunch.WebApi.Application.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BasketService(IBasketRepository basketRepository,
                             IHttpContextAccessor httpContextAccessor)
        {
            _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public async Task AddItemToBasket(BasketItemViewModel basketItem)
        {
            var userId = ExtensionMethod.GetUserId(_httpContextAccessor.HttpContext);
            if (userId == null)
            {
                throw new ArgumentNullException("userId invalied");
            }
            var basket = await _basketRepository.GetAsync(userId);
            basket.AddItemToBasket(
                basketItem.FoodId,
                basketItem.FoodName,
                basketItem.UnitPrice,
                basketItem.OldUnitPrice,
                basketItem.PictureUrl,
                basketItem.Quantity);

            await _basketRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task CreateBasket()
        {
            var userId = ExtensionMethod.GetUserId(_httpContextAccessor.HttpContext);
            if (userId == null)
            {
                throw new ArgumentNullException("userId invalied");
            }
            var result = await _basketRepository.GetAsync(userId);
            if (result == null)
            {
                var basket = new Basket { BuyerId = userId };
                 _basketRepository.Add(basket);
                await _basketRepository.UnitOfWork.SaveChangesAsync();
            }
        }

        public async Task DeleteBasketAsync(int basketId)
        {
            var basket = await _basketRepository.FindIdAsync(basketId);
            if (basket == null)
            {
                throw new ArgumentNullException("Basket is null");
            }
             _basketRepository.Delete(basket);
            await _basketRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task<bool> DeleteItemInBasket(int id)
        {
            var userId = ExtensionMethod.GetUserId(_httpContextAccessor.HttpContext);
            if (userId == null)
            {
                throw new ArgumentNullException("userId invalied");
            }
            var basket = await _basketRepository.GetAsync(userId);
            basket.DeleteItemToBasket(id);
            await _basketRepository.UnitOfWork.SaveChangesAsync();
            
            return true;
        }

        public async Task<BasketViewModel> Getbasket()
        {
            var userId = ExtensionMethod.GetUserId(_httpContextAccessor.HttpContext);
            if (userId == null)
            {
                throw new ArgumentNullException("userId invalied");
            }
            var basket = await _basketRepository.GetAsync(userId);
            var basketModel = new BasketViewModel
            {
                buyerId = basket.BuyerId,
                BasketItems = basket.Items
                    .Select(x => new BasketItemViewModel
                    {
                        FoodId = x.FoodId,
                        FoodName = x.FoodName,
                        UnitPrice = x.UnitPrice,
                        OldUnitPrice = x.OldUnitPrice,
                        PictureUrl = x.PictureUrl,
                        Quantity=x.Quantity
                    })
                    .ToList()
            };
            return basketModel;
        }

        public async Task UpdateBasket(BasketItemViewModel basketItem)
        {
            var userId = ExtensionMethod.GetUserId(_httpContextAccessor.HttpContext);
            if (userId == null)
            {
                throw new ArgumentNullException("userId invalied");
            }
            var basket = await _basketRepository.GetAsync(userId);

            basket.UpdateBasket(basketItem.FoodId, basketItem.Quantity);
            await _basketRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}
