using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Models
{
    public class CompanyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string HotLine { get; set; }
        public DateTime CreationTime { get;private set; }
        public bool IsActive { get;private set; }
       

        public CompanyViewModel(
            int id, string name, string address, string hotline, DateTime dateTime, bool isActive)
        {
            Id = id;
            Name = name;
            Address = address;
            HotLine = hotline;
            CreationTime = dateTime;
            IsActive = isActive;
        }
        
    }
}
