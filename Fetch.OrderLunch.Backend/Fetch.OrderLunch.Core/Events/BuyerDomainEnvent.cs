using Fetch.OrderLunch.Core.Entities.BuyerAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fetch.OrderLunch.Core.Events
{
    public class BuyerDomainEnvent : INotification
    {
        public BuyerDomainEnvent(Buyer buyer, int orderId)
        {
            Buyer = buyer;
            OrderId = orderId;
        }

        public Buyer Buyer { get; private set; }
       
        public int OrderId { get; private set; }

        
    }
}
