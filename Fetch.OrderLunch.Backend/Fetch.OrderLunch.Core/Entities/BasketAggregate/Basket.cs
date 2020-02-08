using Fetch.OrderLunch.Core.Exceptions;
using Fetch.OrderLunch.Core.Interfaces;
using Fetch.OrderLunch.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fetch.OrderLunch.Core.Entities.BasketAggregate
{
    public class Basket :  IAggregateRoot
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        private readonly List<BasketItem> _items = new List<BasketItem>();
        public IReadOnlyCollection<BasketItem> Items => _items;

        public void AddItemToBasket(
              int foodId, string foodName, decimal unitPrice, decimal oldUnitPrice,
             string pictureUrl, int quantity = 1)
        {
            var itemExist = GetById(foodId);

            if (itemExist != null)
            {
                itemExist.AddUnits(quantity);
                itemExist.UnitPrice = unitPrice * itemExist.Quantity;
            }
            else
            {
                _items.Add(new BasketItem(foodId,
                                          foodName,
                                          unitPrice,
                                          oldUnitPrice,
                                          quantity,
                                          pictureUrl));
            }
        }
        public void DeleteItemToBasket(int id)
        {
            var itemExist = GetById(id);
            if (itemExist == null)
            {
                throw new BasketDomainException("Product id not found");
            }
            _items.Remove(itemExist);
        }
        public void UpdateBasket(int foodId, int quantity)
        {
            var itemExist = GetById(foodId);
            if (itemExist == null)
            {
                throw new BasketDomainException("Product id not found");
            }

            itemExist.UnitPrice = (itemExist.UnitPrice / itemExist.Quantity) * quantity;
            itemExist.Quantity = quantity;
        }
        private BasketItem GetById(int id)
        {
            var basketItem = _items.Where(x => x.Id == id).FirstOrDefault();
            return basketItem;
        }
    }
}
