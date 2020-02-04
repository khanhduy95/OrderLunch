
using Fetch.OrderLunch.Core.Entities.CompanyAggregate;
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
    public class DailyMenuRepository : BaseRepository<DailyMenu>, IDailyMenuRepository
    {
        public DailyMenuRepository(OrderLunchContext dbContext) : base(dbContext)
        {
        }

        public DailyMenu AddDailyMenu(DailyMenu dailyMenu)
        {
            throw new NotImplementedException();
        }

        public async Task<DailyMenu> GetAsync(string userId)
        {
            var dailyMenu = await _dbContext.DailyMenu                
                .Where(x => x.CreatorUserId == userId)
                .FirstOrDefaultAsync();
           
            if (dailyMenu != null)
            {
                await _dbContext.Entry(dailyMenu)
                    .Collection(i => i.Foods)
                    .LoadAsync();

                await _dbContext.Entry(dailyMenu)
                    .Reference(i => i.Foods)
                    .LoadAsync();
            }

            return dailyMenu;
                
        }
    }
}
