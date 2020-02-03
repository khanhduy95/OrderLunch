using Fetch.OrderLunch.Core.Interfaces;
using Fetch.OrderLunch.Core.SeedWork;
using Ordering.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fetch.OrderLunch.Core.Entities.BuyerAggregate
{
    public class Buyer : BaseEntity, IAggregateRoot
    {
        public string IdentityGuid { get; private set; }
        public string Name { get; private set; }

        private List<PaymentMethod> _paymentMethods;
        public IEnumerable<PaymentMethod> PaymentMethods => _paymentMethods;

        protected Buyer()
        {
            _paymentMethods = new List<PaymentMethod>();
        }
        public Buyer(string identity, string name) : this()
        {
            IdentityGuid = !string.IsNullOrWhiteSpace(identity) ? identity : throw new ArgumentNullException(nameof(identity));
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
        }

        public PaymentMethod VerifyOrAddPaymentMethod(int methodId, int orderId)
        {
            var existingPayment = _paymentMethods.SingleOrDefault(x => x.IsEqualTo(methodId));
            if (existingPayment != null)
            {
                AddDomainEvent(new BuyerAndPaymentMethodVerifiedDomainEvent(this, existingPayment, orderId));
                return existingPayment;
            }
            var payment = new PaymentMethod(methodId);

            _paymentMethods.Add(payment);

            AddDomainEvent(new BuyerAndPaymentMethodVerifiedDomainEvent(this, payment, orderId));
            return payment;

        }
    }
}
