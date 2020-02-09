using Fetch.OrderLunch.Core.Entities.OrderAggregate;
using Fetch.OrderLunch.Core.Events;
using Fetch.OrderLunch.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.DomainEventHandlers
{
    public class OrderStatusChangedToPaidDomainEventHandler
                    : INotificationHandler<OrderStatusChangedToPaidDomainEvent>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILoggerFactory _logger;

        public OrderStatusChangedToPaidDomainEventHandler(IOrderRepository orderRepository,
                                                          ILoggerFactory logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Handle(OrderStatusChangedToPaidDomainEvent notification, CancellationToken cancellationToken)
        {
            _logger.CreateLogger<OrderStatusChangedToPaidDomainEventHandler>()
                .LogTrace("Order with Id: {OrderId} has been successfully updated to status {Status} ({Id})",
                    notification.OrderId, nameof(OrderStatus.Paid), OrderStatus.Paid.Id);

            await _orderRepository.GetAsync(notification.OrderId);
        }
    }
}
