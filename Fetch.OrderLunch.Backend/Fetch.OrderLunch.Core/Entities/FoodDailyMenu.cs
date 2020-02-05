using Fetch.OrderLunch.Core.Entities.CompanyAggregate;
using Fetch.OrderLunch.Core.Entities.SupplierAggregate;
using Fetch.OrderLunch.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fetch.OrderLunch.Core.Entities
{
    
    public class FoodDailyMenu : BaseEntity
    {

        public int FoodId { get; set; }
        public Food Food { get; set; }

        public int DailyMenuId { get; set; }
        public DailyMenu DailyMenu { get; set; }

    
    }
}
