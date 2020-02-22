using Fetch.OrderLunch.Core.Entities.CompanyAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.Core.Interfaces
{
    public interface IDailyMenuRepository : IAsyncRepository<DailyMenu>
    {
        DailyMenu AddDailyMenu(DailyMenu dailyMenu);

        Task<DailyMenu> GetAsync(string userId);

        Task<DailyMenu> FindByIdAsync(int id);

    }
}
