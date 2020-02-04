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

        private List<FoodDailyMenu> _foods=new List<FoodDailyMenu>();
        public IEnumerable<FoodDailyMenu> Foods => _foods;
       
        public void AddFoodToDailyMenu(int foodId,int dailyMenuId)
        {
            var exist = _foods.Where(x => x.FoodId == foodId).FirstOrDefault();
            if (exist != null) { }
            else

                exist.FoodId = foodId;
                exist.DailyMenuId = dailyMenuId;    
                _foods.Add(exist);
            }
        }
    }

