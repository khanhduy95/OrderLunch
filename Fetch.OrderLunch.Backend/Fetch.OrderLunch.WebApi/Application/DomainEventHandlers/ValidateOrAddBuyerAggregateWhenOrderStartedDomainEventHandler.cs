using Fetch.OrderLunch.Core.Entities.BuyerAggregate;
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
    public class ValidateOrAddBuyerAggregateWhenOrderStartedDomainEventHandler : INotificationHandler<OrderStartedDomainEvent>
    {
        private readonly ILoggerFactory _logger;
        private readonly IBuyerRepository _buyerRepository;

        public ValidateOrAddBuyerAggregateWhenOrderStartedDomainEventHandler(ILoggerFactory logger,
                                                                             IBuyerRepository buyerRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _buyerRepository = buyerRepository ?? throw new ArgumentNullException(nameof(buyerRepository));
        }

        public async Task Handle(OrderStartedDomainEvent notification, CancellationToken cancellationToken)
        {
           var  buyer = await _buyerRepository.FindAsync(notification.UserId);
           bool buyerOriginallyExisted = (buyer == null) ? false : true;
            if (!buyerOriginallyExisted)
            {
                buyer = new Buyer(notification.UserId, notification.UserName);
            }
            var buyerUpdated = buyerOriginallyExisted ?
                _buyerRepository.UpdateBuyer(buyer) :
                _buyerRepository.AddBuyer(buyer);

            await _buyerRepository.unitOfWork.SaveEntitiesAsync();
            _logger.CreateLogger(nameof(ValidateOrAddBuyerAggregateWhenOrderStartedDomainEventHandler));
        }
    }
}
