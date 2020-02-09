using Fetch.OrderLunch.WebApi.Application.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Validations
{
    public class IdentifiedCommandValidator : AbstractValidator<IdentifiedCommand<CreateOrderCommand, bool>>
    {
        public IdentifiedCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
        }
    }
}
