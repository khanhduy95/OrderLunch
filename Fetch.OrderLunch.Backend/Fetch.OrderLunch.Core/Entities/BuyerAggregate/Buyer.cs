using Fetch.OrderLunch.Core.Interfaces;
using Fetch.OrderLunch.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fetch.OrderLunch.Core.Entities.BuyerAggregate
{
    public class Buyer : BaseEntity, IAggregateRoot
    {
        public Buyer(string identityGuid, string name)
        {
            IdentityGuid = identityGuid;
            Name = name;
        }

        public string IdentityGuid { get; private set; }
        public string Name { get; private set; }
    }
}
