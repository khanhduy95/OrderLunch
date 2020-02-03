using Fetch.OrderLunch.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fetch.OrderLunch.Core.Entities.BuyerAggregate
{
    public class Method : Enumeration
    {
        public static Method cash = new Cash();
        public Method(int id, string name) : base(id, name)
        {
        }
        private class Cash : Method
        {
            public Cash() : base(1, "Cash")
            {
            }
        }
    }
}
