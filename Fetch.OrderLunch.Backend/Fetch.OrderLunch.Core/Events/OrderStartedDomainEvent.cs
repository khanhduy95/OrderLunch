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
        public OrderStartedDomainEvent(string userId, string userName, Order order)
        {
            UserId = userId;
            UserName = userName;
            Order = order;
        }

        public string UserId { get; }
        public string UserName { get; }
        public Order Order { get; private set; }
      
    }
}
