
using Fetch.OrderLunch.Core.Events;
using Fetch.OrderLunch.Core.Exceptions;
using Fetch.OrderLunch.Core.Interfaces;
using Fetch.OrderLunch.Core.SeedWork;
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

        
        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        protected Order()
        {
            
        }
        public Order(string userId,string userName, int? buyerId=null):this()
        {
            _orderItems = new List<OrderItem>();
            _buyerId = buyerId;
            _orderStatusId = OrderStatus.Submitted.Id;
            _orderDate = DateTime.Now;

            AddOrderStartedDomainEvent(userId,userName);
        }
        
        public void AddOrderItem(int productId, string productName, decimal unitPrice, string pictureUrl, int units = 1)
        {
            var existingOrderForProduct = _orderItems.Where(o => o.ProductId == productId)
                .SingleOrDefault();

            if (existingOrderForProduct != null)
            {
                //if previous line exist modify it with higher discount  and units..
                existingOrderForProduct.AddUnits(units);
            }
            else
            {
                //add validated new order item

                var orderItem = new OrderItem(productName,pictureUrl,unitPrice,productId,units);
                _orderItems.Add(orderItem);
            }
        }
        public void SetBuyerId(int id)
        {
            _buyerId = id;
        }
        private void AddOrderStartedDomainEvent(string userId, string userName)
        {
            var orderStartedDomainEvent = new OrderStartedDomainEvent( userId, userName,this);

            AddDomainEvent(orderStartedDomainEvent);
        }
    }
}
