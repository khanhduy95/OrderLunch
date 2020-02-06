using Fetch.OrderLunch.Core.Interfaces;
using Fetch.OrderLunch.Core.SeedWork;
using Ordering.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fetch.OrderLunch.Core.Entities.BuyerAggregate
{
    public class Buyer : BaseEntity, IAggregateRoot
    {
        public string IdentityGuid { get; private set; }
        public string Name { get; private set; }

             
        public Buyer(string identity, string name) 
        {
            IdentityGuid = !string.IsNullOrWhiteSpace(identity) ? identity : throw new ArgumentNullException(nameof(identity));
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
        }

    }
}
