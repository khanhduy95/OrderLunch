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
    public class SetPaidOrderStatusCommandHandler : IRequestHandler<SetPaidOrderStatusCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;

        public SetPaidOrderStatusCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> Handle(SetPaidOrderStatusCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(10000);

            var orderToUpdate = await _orderRepository.GetAsync(request.OrderNumber);
            if (orderToUpdate == null)
            {
                return false;
            }

            orderToUpdate.SetPaidStatus();
            return await _orderRepository.unitOfWork.SaveEntitiesAsync();
        }
    public class SetPaidIdentifiedOrderStatusCommandHandler : IdentifiedCommandHandler<SetPaidOrderStatusCommand, bool>
    {
        public SetPaidIdentifiedOrderStatusCommandHandler(
            IMediator mediator,
            IRequestManager requestManager,
            ILogger<IdentifiedCommandHandler<SetPaidOrderStatusCommand, bool>> logger)
            : base(mediator, requestManager)
        {
        }

        protected override bool CreateResultForDuplicateRequest()
        {
            return true;                // Ignore duplicate requests for processing order.
        }
    }
    }
}
