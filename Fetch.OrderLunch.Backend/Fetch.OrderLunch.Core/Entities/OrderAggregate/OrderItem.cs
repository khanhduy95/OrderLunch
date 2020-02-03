using Fetch.OrderLunch.Core.Exceptions;
using Fetch.OrderLunch.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fetch.OrderLunch.Core.Entities.OrderAggregate
{
    public class OrderItem : BaseEntity
    {
        private string _productName;
        private string _pictureUrl;
        private decimal _unitPrice;
        private int _units;
        public int ProductId { get; private set; }

        protected OrderItem() { }
        public OrderItem(string productName, string pictureUrl, decimal unitPrice, int productId, int units = 1)
        {

            if (units < 0)
            {
                throw new OrderingDomainException("Invalid number of units");
            }
            ProductId = productId;

            _productName = productName;
            _pictureUrl = pictureUrl;
            _unitPrice = unitPrice;
            _units = units;
        }

        public string GetPictureUrl()
        {
            return _pictureUrl;
        }

        public string GetOrderItemProductName()
        {
            return _productName;
        }

        public decimal GetUnitPrice()
        {
            return _unitPrice;
        }

        public int GetUnits()
        {
            return _units;
        }

        public void AddUnits(int units)
        {
            if (units < 0)
            {
                throw new OrderingDomainException("Invalid units");
            }
            _units += units;
        }

    }
}
