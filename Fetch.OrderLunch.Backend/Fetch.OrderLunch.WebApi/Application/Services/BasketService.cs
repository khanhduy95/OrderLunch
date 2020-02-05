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
        private readonly IAsyncRepository<Basket> _asyncRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BasketService(IAsyncRepository<Basket> asyncRepository,
                             IHttpContextAccessor httpContextAccessor)
        {
            _asyncRepository = asyncRepository ?? throw new ArgumentNullException(nameof(asyncRepository));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public Task AddItemToBasket(int basketId, int catalogItemId, decimal price, int quantity)
        {
            throw new NotImplementedException();
        }

        public async Task CreateBasket()
        {
            var userId = ExtensionMethod.GetUserId(_httpContextAccessor.HttpContext);
            if (userId == null)
            {
                throw new ArgumentNullException("userId invalied");
            }
            var basket = new Basket { CreatorUserId = userId };
            await _asyncRepository.AddAsync(basket);
        }

        public async Task DeleteBasketAsync(int basketId)
        {
            var basket = await _asyncRepository.GetByIdAsync(basketId);
            if (basket == null)
            {
                throw new ArgumentNullException("Basket is null");
            }
            await _asyncRepository.DeleteAsync(basket);
        }

        public Task<IEnumerable<BasketViewModel>> Getbasket(string buyerId)
        {
            throw new NotImplementedException();
        }

        public Task SetQuantities(int basketId, Dictionary<string, int> quantities)
        {
            throw new NotImplementedException();
        }
    }
}
