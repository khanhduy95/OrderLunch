using Fetch.OrderLunch.Core.Entities.OrderAggregate;
using Fetch.OrderLunch.Core.Interfaces;
using Fetch.OrderLunch.Infrastructure.Idempotency;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<CreateOrderCommand> _logger;

        public CreateOrderCommandHandler(IOrderRepository orderRepository,
                                         ILogger<CreateOrderCommand> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order(request.UserId,request.UserName);

            foreach(var item in request.OrderItems)
            {
                order.AddOrderItem(item.ProductId, item.ProductName, item.UnitPrice, item.PictureUrl, item.Units);
            }
            _orderRepository.AddOrder(order);

            order.DeleteBasketWhenCreateCompleted(request.BasketId);
            
            return await _orderRepository.unitOfWork.SaveEntitiesAsync();
        }
    }
    public class CreateOrderIdentifiedCommandHandler : IdentifiedCommandHandler<CreateOrderCommand, bool>
    {
        public CreateOrderIdentifiedCommandHandler(
            IMediator mediator,
            IRequestManager requestManager,
            ILogger<IdentifiedCommandHandler<CreateOrderCommand, bool>> logger)
            : base(mediator, requestManager)
        {
        }

        protected override bool CreateResultForDuplicateRequest()
        {
            return true;                // Ignore duplicate requests for creating order.
        }
    }
}
