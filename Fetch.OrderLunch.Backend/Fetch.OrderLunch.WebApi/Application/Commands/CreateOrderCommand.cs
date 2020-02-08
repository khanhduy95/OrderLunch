using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Commands
{
    [DataContract]
    public class CreateOrderCommand : IRequest<bool>
    {
        [DataMember]
        public string UserId { get; private set; }
        [DataMember]
        public string UserName { get; private set; }
        [DataMember]
        private readonly List<OrderItemDTO> _orderItems;
        [DataMember]
        public IEnumerable<OrderItemDTO> OrderItems => _orderItems;
        public CreateOrderCommand()
        {
            _orderItems = new List<OrderItemDTO>();
        }
        public CreateOrderCommand(string buyerId)
        {
            UserId = buyerId;
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
