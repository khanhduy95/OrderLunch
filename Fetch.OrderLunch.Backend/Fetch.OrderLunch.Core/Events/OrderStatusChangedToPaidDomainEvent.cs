using Fetch.OrderLunch.Core.Entities.OrderAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fetch.OrderLunch.Core.Events
{
    public class OrderStatusChangedToPaidDomainEvent : INotification
    {
        public OrderStatusChangedToPaidDomainEvent(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; }
       

    }
}
