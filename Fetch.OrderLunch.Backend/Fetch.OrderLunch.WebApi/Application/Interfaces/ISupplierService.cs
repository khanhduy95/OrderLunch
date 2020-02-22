using Fetch.OrderLunch.WebApi.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Interfaces
{
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierViewModel>> GetAll();
        Task<SupplierViewModel> GetById(int id);
        Task Add(SupplierInput supplierVm);
        Task Update(SupplierViewModel supplier, int id);       
        Task Delete(int id);
    }
}
