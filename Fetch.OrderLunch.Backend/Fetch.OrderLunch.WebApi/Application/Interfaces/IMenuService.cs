﻿using Fetch.OrderLunch.WebApi.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Interfaces
{
    public interface IMenuService
    {
        Task<MenuViewModel> GetMenuById(int supplierId);
        Task Update(ObjectID objectID);
    }
}
