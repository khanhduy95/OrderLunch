
using Fetch.OrderLunch.Core.Entities.SupplierAggregate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Fetch.OrderLunch.Core.Specifications
{
    public class FoodFilterSpecification : BaseSpecification<Food>
    {
        public FoodFilterSpecification(int? categoryId)
            : base(x => x.CategoryId == categoryId)
        {
        }
        public FoodFilterSpecification(string foodName)
            : base(x => x.Name.Contains(foodName))
        {
        }
    }
}
