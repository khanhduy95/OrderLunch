using Fetch.OrderLunch.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fetch.OrderLunch.Core.Entities.CompanyAggregate
{
    public class Company :BaseEntity
    {
        
        public string Name { get; set; }
        public string Address { get; set; }
        public string HotLine { get; set; }

    }
}
