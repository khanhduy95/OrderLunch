using Fetch.OrderLunch.Core.Entities.SupplierAggregate;
using Fetch.OrderLunch.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fetch.OrderLunch.Core.Entities.CompanyAggregate
{
    public class DailyMenu : BaseEntity
    {
        public string Name { get; set; }
        private List<Food> _foods=new List<Food>();
        public IEnumerable<Food> Foods => _foods.AsReadOnly();
       
        
    }
}
