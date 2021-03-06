﻿using Fetch.OrderLunch.Core.Entities.SupplierAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.Core.Interfaces
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<Supplier> GetAsync(int supplierId);
    }
}
