using Fetch.OrderLunch.WebApi.Application.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Validations
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(Command => Command.BasketId).NotEmpty();
            RuleFor(Command => Command.UserName).NotEmpty();
            RuleFor(Command => Command.UserId).NotEmpty();
            RuleFor(command => command.OrderItems).Must(ContainOrderItems).WithMessage("No order items found");
        }

        private bool ContainOrderItems(IEnumerable<OrderItemDTO> orderItems)
        {
            return orderItems.Any();
        }
    }
}
