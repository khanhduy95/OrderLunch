using Fetch.OrderLunch.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fetch.OrderLunch.Core.Entities
{
    public class OfficeSupplier : BaseEntity
    {
        public int OfficeId { get; set; }        
        public int SupplierId { get; set; }
        
    }
}
