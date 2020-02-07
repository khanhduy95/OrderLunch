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

       
       

        public Buyer UpdateBuyer(Buyer buyer)
        {
            return _dbContext.Buyers
                .Update(buyer)
                .Entity;
        }
    }
}
