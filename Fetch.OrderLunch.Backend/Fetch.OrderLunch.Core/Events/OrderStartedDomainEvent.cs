using Fetch.OrderLunch.Core.Entities.OrderAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fetch.OrderLunch.Core.Events
{
    public class OrderStartedDomainEvent
       : INotification
    {
        public Order Order { get; private set; }
        public OrderStartedDomainEvent(Order order)
        {
            Order = order;
        }
    }
}
