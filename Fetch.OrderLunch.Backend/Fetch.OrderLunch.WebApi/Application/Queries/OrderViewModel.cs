using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Queries
{
    public class Order
    {
        public List<OrderItem> orderitems { get; set; }
        public decimal total { get; set; }
    }
    public class OrderItem
    {
        public string productname { get; set; }
        public int units { get; set; }
        public double unitprice { get; set; }
        public string pictureurl { get; set; }
    }
}
