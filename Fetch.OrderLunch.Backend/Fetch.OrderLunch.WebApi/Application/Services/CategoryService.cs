using Fetch.OrderLunch.WebApi.Application.Interfaces;
using Fetch.OrderLunch.WebApi.Application.Models;
using Fetch.OrderLunch.Core.Entities.SupplierAggregate;
using Fetch.OrderLunch.Core.Interfaces;
using Fetch.OrderLunch.WebApi.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Services
{
    public class CategoryService : ICategoryService
    {        
        private readonly IAsyncRepository<Category> _asyncRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoryService(IAsyncRepository<Category> asyncRepository, IHttpContextAccessor httpContextAccessor)
        {
            _asyncRepository = asyncRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task Add(CategoryViewModel categoryVm)
        {
            
            var userId = ExtensionMethod.GetUserId(_httpContextAccessor.HttpContext);          
            if (userId == null)
            {
                throw new ArgumentNullException("userId invalied");
            }
            var category = new Category
            {
                Name = categoryVm.Name,
                CreationTime = DateTime.Now,             
                CreatorUserId = userId

            };
            await _asyncRepository.AddAsync(category);
            await _asyncRepository.unitOfWork.SaveChangesAsync();       
        }

        public Task Delete(ObjectID objectID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAll()
        {           
            var items = await _asyncRepository.ListAllAsync();
            var categories = new List<CategoryViewModel>();
            foreach(var i in items)
            {
                var category = new CategoryViewModel
                {
                    Id = i.Id,
                    Name = i.Name
                };
                categories.Add(category);
            }
            return categories;
        }

        public Task<CategoryViewModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task HardDelete(ObjectID objectID)
        {
            throw new NotImplementedException();
        }

        public Task Update(CategoryViewModel categoryVm)
        {
            throw new NotImplementedException();
        }
    }
}
