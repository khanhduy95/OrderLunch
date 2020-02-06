using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Commands
{
    public class CreateOrderCommand : IRequest<bool>
    {
        public int BuyerId { get; private set; }
        private readonly List<OrderItemDTO> _orderItems;
        public IEnumerable<OrderItemDTO> OrderItems => _orderItems;
        public CreateOrderCommand()
        {
            _orderItems = new List<OrderItemDTO>();
        }
        public CreateOrderCommand(int buyerId)
        {
            BuyerId = buyerId;
        }
    }
    public class OrderItemDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Units { get; set; }
        public string PictureUrl { get; set; }
    }
}
