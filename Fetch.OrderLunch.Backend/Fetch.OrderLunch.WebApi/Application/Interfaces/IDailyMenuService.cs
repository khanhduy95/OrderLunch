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
        
        Task<DailyMenuViewModel> GetDailyMenu(string userId);
        Task<IEnumerable<DisplayDailyMenu>> GetAll();
        Task<DailyMenuViewModel> GetDailyMenuToDay();
        Task Delete(ObjectID objectID);
    }
}
