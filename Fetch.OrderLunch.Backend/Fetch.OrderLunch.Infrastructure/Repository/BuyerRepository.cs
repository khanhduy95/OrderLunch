using Fetch.OrderLunch.Core.Entities.BuyerAggregate;
using Fetch.OrderLunch.Core.Interfaces;
using Fetch.OrderLunch.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.Infrastructure.Repository
{
    public class BuyerRepository : BaseRepository<Buyer>, IBuyerRepository
    {
        public BuyerRepository(OrderLunchContext dbContext) : base(dbContext)
        {
        }

        public Buyer AddBuyer(Buyer buyer)
        {
            if (buyer.IsTransient())
            {
                return _dbContext.Buyers
                    .Add(buyer)
                    .Entity;
            }
            else
            {
                return buyer;
            }
        }

        public async Task<Buyer> FindAsync(string buyerIdentityGuid)
        {
            var buyer = await _dbContext.Buyers
                .Include(x => x.PaymentMethods)
                .Where(x => x.IdentityGuid == buyerIdentityGuid)
                .SingleOrDefaultAsync();

            return buyer;
        }

        public async Task<Buyer> FindByIdAsync(string id)
        {
            var buyer = await _dbContext.Buyers
                .Include(x => x.PaymentMethods)
                .Where(x => x.Id == int.Parse(id))
                .SingleOrDefaultAsync();

            return buyer;
        }

        public Buyer UpdateBuyer(Buyer buyer)
        {
            return _dbContext.Buyers
                .Update(buyer)
                .Entity;
        }
    }
}
