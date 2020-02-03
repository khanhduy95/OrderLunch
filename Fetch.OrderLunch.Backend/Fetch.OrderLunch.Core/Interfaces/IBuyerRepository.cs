using Fetch.OrderLunch.Core.Entities.BuyerAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.Core.Interfaces
{
    public interface IBuyerRepository : IRepository<Buyer>
    {
        Buyer AddBuyer(Buyer buyer);
        Buyer UpdateBuyer(Buyer buyer);
        Task<Buyer> FindAsync(string buyerIdentityGuid);
        Task<Buyer> FindByIdAsync(string id);
       
    }
}
