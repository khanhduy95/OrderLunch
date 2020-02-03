using Fetch.OrderLunch.Core.Exceptions;
using Fetch.OrderLunch.Core.Interfaces;
using Fetch.OrderLunch.Core.SeedWork;
using Ordering.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fetch.OrderLunch.Core.Entities.OrderAggregate
{
    public class Order : BaseEntity, IAggregateRoot
    {
        private DateTime _orderDate;

        public int? GetBuyerId => _buyerId;
        private int? _buyerId;

        public OrderStatus OrderStatus { get; private set; }
        private int _orderStatusId;

        private string _description;
        private int? _paymentMethodId;

        public string Address { get; set; }

        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        protected Order()
        {
            _orderItems = new List<OrderItem>();
        }

        public Order(string userId, string userName, int methodId, string address, int? paymentMethodId = null, int? buyerId = null)
            : this()
        {
            _buyerId = buyerId;
            _orderDate = DateTime.Now;
            _paymentMethodId = paymentMethodId;
            _orderStatusId = OrderStatus.Submitted.Id;
            Address = address;
            AddOrderStartDomainEvent(userId, userName, methodId);
        }

        public void AddOrderItem(string productName, string pictureUrl, decimal unitPrice, int productId, int units = 1)
        {
            var existingOrderForProduct = _orderItems.Where(x => x.ProductId == productId)
                .FirstOrDefault();
            if (existingOrderForProduct != null)
            {
                existingOrderForProduct.AddUnits(units);
            }
            else
            {
                var orderItem = new OrderItem(productName, pictureUrl, unitPrice, productId, units);
                _orderItems.Add(orderItem);
            }
        }

        public void SetPaymentId(int id)
        {
            _paymentMethodId = id;
        }

        public void SetBuyerId(int id)
        {
            _buyerId = id;
        }

        public void SetAwaitingValidationStatus()
        {
            if (_orderStatusId == OrderStatus.Submitted.Id)
            {
                AddDomainEvent(new OrderStatusChangedToAwaitingValidationDomainEvent(Id, _orderItems));
                
            }
        }


        public void SetCancelledStatus()
        {
            if (_orderStatusId == OrderStatus.Paid.Id)
            {
                StatusChangeException(OrderStatus.Cancelled);
            }
            _orderStatusId = OrderStatus.Cancelled.Id;
            _description = $"The order was cancelled.";
            AddDomainEvent(new OrderCancelledDomainEvent(this));
        }

        public void AddOrderStartDomainEvent(string userId, string userName, int methodId)
        {
            var orderStartDomainEvent = new OrderStartedDomainEvent(this, userId, userName, methodId);
            this.AddDomainEvent(orderStartDomainEvent);
        }

        private void StatusChangeException(OrderStatus orderStatusToChange)
        {
            throw new OrderingDomainException($"Is not possible to change the order status from {OrderStatus.Name} to {orderStatusToChange.Name}.");
        }

        public decimal GetTotal()
        {
            return _orderItems.Sum(x => x.GetUnits() * x.GetUnitPrice());
        }
    }
}
