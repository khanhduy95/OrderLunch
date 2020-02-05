using Fetch.OrderLunch.Core.Entities.SupplierAggregate;
using Fetch.OrderLunch.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fetch.OrderLunch.Core.Entities.CompanyAggregate
{
    public class DailyMenu : BaseEntity
    {
        public string Name { get; set; }

        private List<FoodDailyMenu> _foodDailies=new List<FoodDailyMenu>();
        public ICollection<FoodDailyMenu> FoodDailyMenus =>_foodDailies;


        public void AddFoodToDailyMenu(int foodId, int dailyMenuId)
        {
            var exist = _foodDailies.Where(x => x.FoodId == foodId).FirstOrDefault();
            if (exist == null)
            {
                FoodDailyMenu foodDailyMenu = new FoodDailyMenu { FoodId = foodId, DailyMenuId = dailyMenuId };
                _foodDailies.Add(foodDailyMenu);
            }         
        }

        public IEnumerable<FoodDailyMenu> GetFood()
        {
            var Foods = _foodDailies.Where(x => x.DailyMenuId == Id).ToList();
            return Foods;

        }
    }
}

