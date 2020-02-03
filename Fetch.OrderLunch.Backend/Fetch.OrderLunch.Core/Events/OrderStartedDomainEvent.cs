
using Fetch.OrderLunch.Core.Entities.OrderAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.Events
{
    public class OrderStartedDomainEvent : INotification
    {
        public Order Order { get; private set; }
        public string UserId { get; }
        public string UserName { get; }
        public int MethodId { get;  }

        public OrderStartedDomainEvent(Order order, string userId, string userName,int methodId)
        {
            Order = order;
            UserId = userId;
            UserName = userName;
            MethodId = methodId;
        }
    }
}
