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
    public class MenuRepository : BaseRepository<Menu>, IMenuRepository
    {
        public MenuRepository(OrderLunchContext dbContext) : base(dbContext)
        {

        }

        public async Task<Menu> GetAsync(int supplierId)
        {
            var menu = await _dbContext.Menu
               .Include(x => x.Foods)
               .Where(x => x.SupplierId == supplierId)
               .FirstOrDefaultAsync();

            return menu;
        }
    }
}
