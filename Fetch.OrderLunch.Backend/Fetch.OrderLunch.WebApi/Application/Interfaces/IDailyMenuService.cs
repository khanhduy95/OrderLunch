using Fetch.OrderLunch.WebApi.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Interfaces
{
    public interface IDailyMenuService
    {
        Task AddFoodToDailyMenu(ObjectID objectID);
        Task Create(DailyMenuViewModel dailyMenuVm);
        Task<DailyMenuViewModel> GetDailyMenuById();
       
    }
}
