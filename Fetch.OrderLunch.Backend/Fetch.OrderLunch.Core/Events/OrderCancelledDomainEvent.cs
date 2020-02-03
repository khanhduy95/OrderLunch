
using Fetch.OrderLunch.Core.Entities.OrderAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.Events
{
    public class OrderCancelledDomainEvent : INotification
    {
        public Order Order { get; private set; }
        public OrderCancelledDomainEvent(Order order)
        {
            Order = order;
        }
    }
}
