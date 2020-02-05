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
    public class BasketRepository : BaseRepository<Basket>, IBasketRepository
    {
        public BasketRepository(OrderLunchContext dbContext) : base(dbContext)
        {
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
    }
}
