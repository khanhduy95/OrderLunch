using Fetch.OrderLunch.Core.Exceptions;
using Fetch.OrderLunch.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fetch.OrderLunch.Core.Entities.BasketAggregate
{
    public class BasketItem : BaseEntity
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal OldUnitPrice { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
        public BasketItem(int foodId, string foodName, decimal unitPrice, decimal oldUnitPrice,
                        int quantity, string pictureUrl)
        {

            FoodId = foodId;
            FoodName = foodName;
            UnitPrice = unitPrice;
            OldUnitPrice = oldUnitPrice;
            Quantity = quantity;
            PictureUrl = pictureUrl;
        }
        public void AddUnits(int quantity)
        {
            if (quantity < 0)
            {
                throw new BasketDomainException("Invalid quantity");
            }
            Quantity += quantity;
        }
    }
}
