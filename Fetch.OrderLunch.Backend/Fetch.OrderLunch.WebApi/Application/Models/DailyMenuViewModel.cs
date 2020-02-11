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
    public class CreateDailyMenu
    {
        public string Name { get; set; }
    }

    public class DisplayDailyMenu
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class FoodDaily
    {
        public string UserId { get; set; }
        public int FoodId { get; set; }
    }
}
