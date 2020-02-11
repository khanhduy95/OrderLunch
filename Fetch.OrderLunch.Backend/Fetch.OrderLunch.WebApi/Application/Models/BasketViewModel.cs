using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Models
{
    public class BasketViewModel
    {
        public int id { get; set; }
        public string buyerId { get; set; }
        public List<BasketItemViewModel> BasketItems { get; set; }
    }
    public class BasketInPut
    {
        public string UserId { get; set; }
    }
    public class BasketItemViewModel
    {
        public int BasketId { get; set; }
        public string UserId { get; set; }
        public int FoodId { get; set; }       
        public string FoodName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal OldUnitPrice { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
    }
}
