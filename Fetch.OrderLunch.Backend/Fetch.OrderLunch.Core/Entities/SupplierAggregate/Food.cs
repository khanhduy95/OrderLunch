using Fetch.OrderLunch.Core.Entities.CompanyAggregate;
using Fetch.OrderLunch.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fetch.OrderLunch.Core.Entities.SupplierAggregate
{
    public class Food : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int MenuId { get; set; }
        public int CategoryId { get; set; }
        public ICollection<FoodDailyMenu> FoodDailyMenus { get; set; }
    }
}
