using Fetch.OrderLunch.Infrastructure.Idempotency;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Commands
{
    public class IdentifierCommandHandler<T, R> : IRequestHandler<IdentifiedCommand<T, R>, R>
       where T : IRequest<R>
    {
        private readonly IMediator _mediator;
        private readonly IRequestManager _requestManager;

        public IdentifierCommandHandler(IMediator mediator, IRequestManager requestManager)
        {
            _mediator = mediator;
            _requestManager = requestManager;
        }

        protected virtual R CreateResultForDuplicateRequest()
        {
            return default(R);
        }

        public async Task<R> Handle(IdentifiedCommand<T, R> request, CancellationToken cancellationToken)
        {
            var alreadyExists = await _requestManager.ExistAsync(request.Id);
            if (alreadyExists)
            {
                return CreateResultForDuplicateRequest();
            }
            else
            {
                var result = await _mediator.Send(request.Command);
                await _requestManager.CreateRequestForCommandAsync<T>(request.Id);
                return result;
            }
        }
    }
}
