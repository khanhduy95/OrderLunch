using Fetch.OrderLunch.Core.Entities.BasketAggregate;
using Fetch.OrderLunch.Core.Interfaces;
using Fetch.OrderLunch.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.Infrastructure.Repository
{
    public class BasketRepository :  IBasketRepository
    {
        private OrderLunchContext _dbContext;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _dbContext;
            }
        }

        public BasketRepository(OrderLunchContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

       
        public Basket Add(Basket basket)
        {
            return _dbContext.Baskets
                .Add(basket)
                .Entity;
        }

        public bool Delete(Basket basket)
        {
            _dbContext.Baskets.Remove(basket);
            return true;
        }

        public async Task<Basket> GetAsync(string userId)
        {
            var basket = await _dbContext.Baskets.Where(x => x.BuyerId == userId).FirstOrDefaultAsync();
            if (basket != null)
            {
                await _dbContext.Entry(basket)
                                    .Collection(x => x.Items)
                                    .LoadAsync();
                return basket;
            }
            return basket;
        }

        public async Task<Basket> FindIdAsync(int id)
        {
            return await _dbContext.Baskets
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
