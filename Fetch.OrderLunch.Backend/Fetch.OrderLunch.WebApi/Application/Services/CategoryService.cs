using Fetch.OrderLunch.WebApi.Application.Interfaces;
using Fetch.OrderLunch.WebApi.Application.Models;
using Fetch.OrderLunch.Core.Entities.SupplierAggregate;
using Fetch.OrderLunch.Core.Interfaces;
using Microsoft.AspNetCore.Http;
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

        public CategoryService(IAsyncRepository<Category> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }

        
        public async Task Add(CategoryInput categoryInput)
        {
            
            //var userId = ExtensionMethod.GetUserId(_httpContextAccessor.HttpContext);          
            //if (userId == null)
            //{
            //    throw new ArgumentNullException("userId invalied");
            //}
            var category = new Category
            {
                Name = categoryInput.Name,
                CreationTime = DateTime.Now,             
             //   CreatorUserId = userId

            };
            await _asyncRepository.AddAsync(category);
        }

        public async Task Delete(int categoryId)
        {
            var category = await _asyncRepository.GetByIdAsync(categoryId);
            if (category == null)
            {
                throw new ArgumentNullException("Category is null");
            }
            await _asyncRepository.DeleteAsync(category);
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

        public async Task<CategoryViewModel> GetById(int id)
        {
            var category = await _asyncRepository.GetByIdAsync(id);
            if (category == null)
            {
                throw new ArgumentNullException("Category is null");
            }
            return new CategoryViewModel { Id = category.Id, Name = category.Name };
        }

       
        public async Task Update(CategoryViewModel category,int id)
        {
            var result = await _asyncRepository.GetByIdAsync(id);
            if (result == null || result.Id!=category.Id)
            {
                throw new ArgumentNullException("Category is null");
            }
            result.Name = category.Name;

            await _asyncRepository.UpdateAsync(result);
          
        }
    }
}
