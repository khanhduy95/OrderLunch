using Fetch.OrderLunch.Core.Exceptions;
using Fetch.OrderLunch.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fetch.OrderLunch.Core.Entities.OrderAggregate
{
    public class OrderStatus : Enumeration
    {
        public static OrderStatus Submitted = new OrderStatus(1, nameof(Submitted).ToLowerInvariant());
//          public static OrderStatus AwaitingValidation = new OrderStatus(2, nameof(AwaitingValidation).ToLowerInvariant());
//        public static OrderStatus StockConfirmed = new OrderStatus(3, nameof(StockConfirmed).ToLowerInvariant());
        public static OrderStatus Paid = new OrderStatus(2, nameof(Paid).ToLowerInvariant());
        public static OrderStatus Cancelled = new OrderStatus(3, nameof(Cancelled).ToLowerInvariant());

        public OrderStatus(int id, string name)
            : base(id, name)
        {
        }

        

     
    }
}
