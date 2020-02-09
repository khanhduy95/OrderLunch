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
    public class DeleteBasketWhenCreateOrderCompleteEventHandler : INotificationHandler<DeleteBasketDomainEvent>
    {
        private readonly ILoggerFactory _logger;
        private readonly IBasketRepository _basketRepository;

        public DeleteBasketWhenCreateOrderCompleteEventHandler(ILoggerFactory logger,
                                                               IBasketRepository buyerRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _basketRepository = buyerRepository ?? throw new ArgumentNullException(nameof(buyerRepository));
        }

        public async Task Handle(DeleteBasketDomainEvent notification, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.FindIdAsync(notification.BasketId);

            if (basket != null)
            {
                _basketRepository.Delete(basket);

                await _basketRepository.UnitOfWork.SaveEntitiesAsync();
            }
            
        }
    }
}
