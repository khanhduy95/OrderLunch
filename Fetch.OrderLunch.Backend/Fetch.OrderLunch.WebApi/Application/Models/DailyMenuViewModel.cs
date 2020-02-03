using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Models
{
    public class DailyMenuViewModel
    {
        public string Name { get; set; }
        public List<FoodViewModel> Foods { get; set; }
    }
}
