using Fetch.OrderLunch.Core.Entities.SupplierAggregate;
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
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(OrderLunchContext dbContext) : base(dbContext)
        {
        }

        public async Task<Supplier> GetAsync(int supplierId)
        {
            var supplier =await _dbContext.Suppliers
                    .Where(x => x.Id == supplierId)
                    .FirstOrDefaultAsync();
            if (supplier != null)
            {
                await _dbContext.Entry(supplier)
                    .Reference(x => x.Menu)
                    .LoadAsync();

                await _dbContext.Entry(supplier)
                    .Collection(x => x.Menu.Foods)
                    .LoadAsync();
            };

            throw new ArgumentNullException();
        }
    }
}
