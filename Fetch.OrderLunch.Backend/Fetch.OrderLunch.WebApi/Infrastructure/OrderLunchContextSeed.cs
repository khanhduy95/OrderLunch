using Fetch.OrderLunch.Core.Entities.OrderAggregate;
using Fetch.OrderLunch.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Infrastructure
{
    public class OrderLunchContextSeed
    {
        public void Seed(OrderLunchContext context)
        {
            using (context)
            {
                context.Database.Migrate();

                if (!context.OrderStatus.Any())
                {
                    context.OrderStatus.AddRange(GetPredefinedOrderStatus());
                }
               
                context.SaveChanges();
            }
        }
        private IEnumerable<OrderStatus> GetPredefinedOrderStatus()
        {
            return new List<OrderStatus>()
            {
                OrderStatus.Submitted,
                OrderStatus.Shipped,
                OrderStatus.Cancelled
            };
        }
    }
}
