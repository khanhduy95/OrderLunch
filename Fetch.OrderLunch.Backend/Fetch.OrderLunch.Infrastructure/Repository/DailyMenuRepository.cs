
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
            return _dbContext.DailyMenu
                .Add(dailyMenu)
                .Entity;
        }

        public async Task<DailyMenu> GetAsync(string userId)
        {
            var dailyMenu = await _dbContext.DailyMenu
                .Where(x => x.CreatorUserId == userId && x.CreationTime==DateTime.Today)
                .FirstOrDefaultAsync();

            if (dailyMenu == null)
            {
                dailyMenu = _dbContext.DailyMenu
                    .Local
                    .FirstOrDefault(x => x.CreatorUserId == userId);
            }
            if (dailyMenu != null)
            {
                await _dbContext.Entry(dailyMenu)
                    .Collection(i => i.FoodDailyMenus)
                    .LoadAsync();
            }

            return dailyMenu;
        }

        public async Task<DailyMenu> FindByIdAsync(int id)
        {
            var dailyMenu = await _dbContext.DailyMenu
               .Where(x => x.Id == id && x.CreationTime == DateTime.Today)
               .FirstOrDefaultAsync();

            if (dailyMenu != null)
            {
                await _dbContext.Entry(dailyMenu)
                    .Collection(i => i.FoodDailyMenus)
                    .LoadAsync();
            }
            return dailyMenu;
        }
    }
}
