using Fetch.OrderLunch.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fetch.OrderLunch.Core.Entities.BasketAggregate
{
    public class BasketItem : BaseEntity
    {
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int CatalogItemId { get; set; }
    }
}
