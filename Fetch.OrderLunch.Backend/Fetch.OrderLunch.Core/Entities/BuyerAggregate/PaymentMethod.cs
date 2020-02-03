using Fetch.OrderLunch.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fetch.OrderLunch.Core.Entities.BuyerAggregate
{
    public class PaymentMethod : BaseEntity
    {
        public Method method { get; private set; }
        private int _methodId;
        protected PaymentMethod()
        {

        }
        public PaymentMethod(int methodId)
        {
            _methodId = methodId;
        }
        public void SetMethodId(int methodId)
        {
            _methodId = methodId;
        }
        public bool IsEqualTo(int methodId)
        {
            return _methodId == methodId;
        }
    }
}
