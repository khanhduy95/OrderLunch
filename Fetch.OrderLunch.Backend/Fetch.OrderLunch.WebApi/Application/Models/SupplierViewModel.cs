
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Models
{
    public class SupplierInput
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string HotLine { get; set; }       
    }
    public class SupplierViewModel
    {
        public int Id { get; set; }       
        public string Name { get; set; }
        public string Address { get; set; }
        public string HotLine { get; set; }       
    }
    public class MenuViewModel
    {
        public int Id { get; set; }      
        public DateTime ExprireTime { get; set; }     
        public List<FoodViewModel> Foods { get; set; }
    }
   
}
