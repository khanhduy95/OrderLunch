using Fetch.OrderLunch.WebApi.Application.Interfaces;
using Fetch.OrderLunch.WebApi.Application.Models;
using Fetch.OrderLunch.Core.Entities.SupplierAggregate;
using Fetch.OrderLunch.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IAsyncRepository<Supplier> _asyncSupplierRepository;
        private readonly IAsyncRepository<Menu> _asyncMenuRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SupplierService(IAsyncRepository<Supplier> asyncSupplierRepository,
                               IAsyncRepository<Menu> asyncMenuRepository,
                               IHttpContextAccessor httpContextAccessor)
        {
            _asyncSupplierRepository = asyncSupplierRepository;
            _asyncMenuRepository = asyncMenuRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task Add(SupplierInput supplierInput)
        {
            //var userId = ExtensionMethod.GetUserId(_httpContextAccessor.HttpContext);
            //if (userId == null)
            //{
            //    throw new ArgumentNullException();
            //}
           
            var supplier = new Supplier
                {
                    Name = supplierInput.Name,
                    HotLine = supplierInput.HotLine,
                    Address = supplierInput.Address,
                    CreationTime = DateTime.Now,
                    IsDeleted = false,

                };

                await _asyncSupplierRepository.AddAsync(supplier);
                var menu = supplier.CreateMenu(supplier.Id);

                await _asyncMenuRepository.AddAsync(menu);
                await _asyncSupplierRepository.unitOfWork.SaveChangesAsync();
        }
       
        public async Task Delete(ObjectID objectID)
        {
           var supplier=await _asyncSupplierRepository.GetByIdAsync(objectID.Id);
            if (supplier == null)
            {
                throw new ArgumentNullException("supplier is null");
            }
            await _asyncSupplierRepository.DeleteAsync(supplier);
            await _asyncSupplierRepository.unitOfWork.SaveChangesAsync();
        }

        public async  Task<IEnumerable<SupplierViewModel>> GetAll()
        {          
            var suppliers = await _asyncSupplierRepository.ListAllAsync();
            var listSupplier = suppliers.Select(x =>
                                 new SupplierViewModel
                                 {
                                     Id=x.Id,
                                     Name=x.Name,
                                     Address=x.Address,
                                     HotLine=x.HotLine
                                 });
            return listSupplier;
        }

        public async Task<SupplierViewModel> GetById(int id)
        {
            var query = await _asyncSupplierRepository.GetByIdAsync(id);

            if (query != null)
            {
                var supplier = new SupplierViewModel
                {
                    Id = query.Id,
                    Name = query.Name,
                    Address = query.Address,
                    HotLine = query.HotLine
                };
                return supplier;
            }
            throw new ArgumentNullException("SupplierId is null"); 
        }

        public async Task Update(SupplierViewModel supplierVm)
        {
            var supplier = await _asyncSupplierRepository.GetByIdAsync(supplierVm.Id);

            if (supplier == null)
            {
                throw new ArgumentNullException(nameof(supplier));
            }
            
            supplier.Name = supplierVm.Name;
            supplier.Address = supplierVm.Address;
            supplier.HotLine = supplierVm.HotLine;

            await _asyncSupplierRepository.UpdateAsync(supplier);
           
        }
       
    }
}
