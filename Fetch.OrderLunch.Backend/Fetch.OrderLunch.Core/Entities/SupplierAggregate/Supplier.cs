using Fetch.OrderLunch.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fetch.OrderLunch.Core.Entities.SupplierAggregate
{
    public class Supplier : BaseEntity
    {      
        public string Name { get; set; }
        public string Address { get; set; }
        public string HotLine { get; set; }
        public Menu Menu { get; set; }

        public Menu CreateMenu(int supplierId)
        {
           
            return new Menu(supplierId);
        }
    }
}
