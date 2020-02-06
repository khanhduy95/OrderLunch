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
    public class CreateBasketViewModel
    { 
        
    }
        public class BasketItemViewModel
    {
        public int FoodId { get; set; }       
        public string FoodName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal OldUnitPrice { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
    }
}
