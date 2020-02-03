using Fetch.OrderLunch.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fetch.OrderLunch.Core.Entities.SupplierAggregate
{
    public class Menu : BaseEntity
    {
    
        public DateTime ExprireTime { get; set; }
        public int SupplierId { get; set; }

        private readonly List<Food> _foods;
        public IReadOnlyCollection<Food> Foods => _foods.AsReadOnly();
        protected Menu()
        {
            _foods = new List<Food>();
        }

        public Menu(int supplierId)
        {
            CreationTime = DateTime.Now;
            ExprireTime = DateTime.Now;           
            SupplierId = supplierId;           
        }

    }
}
