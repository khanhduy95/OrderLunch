using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fetch.OrderLunch.Core.Events
{
    public class DeleteBasketDomainEvent : INotification
    {
        public DeleteBasketDomainEvent(int basketId)
        {
            BasketId = basketId;
        }

        public int BasketId { get; set; }

    }
}
