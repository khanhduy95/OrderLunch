using Fetch.OrderLunch.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fetch.OrderLunch.Core.Entities
{
    public class FoodDailyMenu : BaseEntity
    {
        public int FoodId { get; set; }
        
        public int DailyMenuId { get; set; }
    }
}
