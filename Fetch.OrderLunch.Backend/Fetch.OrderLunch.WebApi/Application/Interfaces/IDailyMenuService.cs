using Fetch.OrderLunch.WebApi.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Interfaces
{
    public interface IDailyMenuService
    {
        Task AddFoodToDailyMenu(FoodDaily food);
        Task Create(CreateDailyMenu dailyMenuVm);
        Task<DailyMenuViewModel> GetDailyMenu();
        Task<IEnumerable<DisplayDailyMenu>> GetAll();
        Task Delete(ObjectID objectID);
    }
}
