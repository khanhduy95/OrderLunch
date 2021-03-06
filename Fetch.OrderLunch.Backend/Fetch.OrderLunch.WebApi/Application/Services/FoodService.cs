﻿using Fetch.OrderLunch.WebApi.Application.Interfaces;
using Fetch.OrderLunch.WebApi.Application.Models;
using Fetch.OrderLunch.Core.Entities.SupplierAggregate;
using Fetch.OrderLunch.Core.Interfaces;
using Fetch.OrderLunch.Core.Specifications;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Services
{
    public class FoodService : IFoodService
    {
        private readonly IRepository<Food> _repository;
        private readonly IAsyncRepository<Food> _asyncFoodRepository;
        private readonly IAsyncRepository<Menu> _asyncMenuRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FoodService(IRepository<Food> repository,
                           IAsyncRepository<Food> asyncFoodRepository,
                           IAsyncRepository<Menu> asyncMenuRepository,
                           IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _asyncFoodRepository = asyncFoodRepository;
            _asyncMenuRepository = asyncMenuRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task Add(FoodInput foodVm)
        {
            //var userId = ExtensionMethod.GetUserId(_httpContextAccessor.HttpContext);
            //if (userId == null)
            //{
            //    throw new ArgumentNullException();
            //}
            var Food = new Food
            {
                Name = foodVm.Name,
                Description = foodVm.Description,
                Price = foodVm.Price,
                Image = foodVm.Image,
                MenuId = foodVm.MenuId,
                CategoryId = foodVm.CategoryId,
                CreationTime = DateTime.Now,
            //    CreatorUserId=userId
            };

            await _asyncFoodRepository.AddAsync(Food);
            await _asyncFoodRepository.unitOfWork.SaveChangesAsync();
        }

        public async  Task Delete(int foodId)
        {
            var food =await _asyncFoodRepository.GetByIdAsync(foodId);
            if (food == null)
            {
                throw new ArgumentNullException(nameof(food));
            }
           await _asyncFoodRepository.DeleteAsync(food);
           await _asyncFoodRepository.unitOfWork.SaveChangesAsync();
        }
        public async Task<PaginatedItemsViewModel<FoodViewModel>> GetAll(int pageIndex, int pageSize)
        {
            var roots = await _asyncFoodRepository.ListAllAsync();
            var root = roots.FirstOrDefault();
            var menu= await _asyncMenuRepository.GetByIdAsync(root.MenuId);
            
                var totalItems = roots.Count();
                var itemsOnPage = roots.OrderBy(x => x.Name)
                                      .Select(x => new FoodViewModel
                                      {
                                          Id = x.Id,
                                          Description = x.Description,
                                          Name = x.Name,
                                          Price = x.Price,
                                          MenuId = x.MenuId,
                                          CategoryId = x.CategoryId,
                                          Image = x.Image
                                      })
                                      .Skip(pageSize * pageIndex)
                                      .Take(pageSize)
                                      .ToList();

                var model = new PaginatedItemsViewModel<FoodViewModel>(
                    pageIndex, pageSize, totalItems, itemsOnPage);

                return model;
            
        }
       
        public async Task<PaginatedItemsViewModel<FoodViewModel>> GetFoodByCategory(int id, int pageSize, int pageIndex)
        {
            var filterSpecification = new FoodFilterSpecification(id);
            var roots = await _asyncFoodRepository.ListAsync(filterSpecification);
            var root = roots.FirstOrDefault();
            var menu = await _asyncMenuRepository.GetByIdAsync(root.MenuId);
            if (menu.ExprireTime >= DateTime.Now)
            {
                var totalItems = roots.Count();
                var itemsOnPage = roots.OrderBy(x => x.Name)
                                      .Select(x => new FoodViewModel
                                      {
                                          Id = x.Id,
                                          Description = x.Description,
                                          Name = x.Name,
                                          Price = x.Price,
                                          MenuId = x.MenuId,
                                          CategoryId = x.CategoryId,
                                          Image = x.Image
                                      })
                                      .Skip(pageSize * pageIndex)
                                      .Take(pageSize)
                                      .ToList();

                var model = new PaginatedItemsViewModel<FoodViewModel>(
                    pageIndex, pageSize, totalItems, itemsOnPage);
                return model;
            }
            return null;
        }

        public async Task<FoodViewModel> GetFoodById(int id)
        {
            var food = await _asyncFoodRepository.GetByIdAsync(id);
            if (food == null)
            {
                throw new ArgumentNullException("Food is null");
            }
            return new FoodViewModel { Id = food.Id, 
                Name = food.Name,
                Description = food.Description,
                Price = food.Price, 
                CategoryId = food.CategoryId, 
                MenuId = food.MenuId,
                Image = food.Image
            };
        }

        public async Task<PaginatedItemsViewModel<FoodViewModel>> SearchFoodByFoodName(string foodName, int pageIndex, int pageSize)
        {
            if (!String.IsNullOrEmpty(foodName))
            {
                var filterSpecification = new FoodFilterSpecification(foodName);
                var roots = await _asyncFoodRepository.ListAsync(filterSpecification);
                var root = roots.FirstOrDefault();
                var menu = await _asyncMenuRepository.GetByIdAsync(root.MenuId);

                var totalItems = roots.Count();
                var itemsOnPage = roots.OrderBy(x => x.Name)
                                      .Select(x => new FoodViewModel
                                      {
                                          Id = x.Id,
                                          Description = x.Description,
                                          Name = x.Name,
                                          Price = x.Price,
                                          MenuId = x.MenuId,
                                          CategoryId = x.CategoryId,
                                          Image = x.Image
                                      })
                                      .Skip(pageSize * pageIndex)
                                      .Take(pageSize)
                                      .ToList();

                var model = new PaginatedItemsViewModel<FoodViewModel>(
                    pageIndex, pageSize, totalItems, itemsOnPage);

                return model;
            }
            return await GetAll(pageIndex,pageSize);
        }

        public async Task Update(FoodViewModel foodVm,int id)
        {
            var food = await _asyncFoodRepository.GetByIdAsync(id);
            if (food == null || food.Id!=foodVm.Id)
            {
                throw new ArgumentNullException("parameter 'Id' Incorrect");
            }

            food.Name = foodVm.Name;
            food.Description = foodVm.Description;
            food.Price = foodVm.Price;
            food.MenuId = foodVm.MenuId;
            food.CategoryId = foodVm.CategoryId;
            food.Image = foodVm.Image;
            await _asyncFoodRepository.UpdateAsync(food);
            await _asyncFoodRepository.unitOfWork.SaveChangesAsync();

        }
           
    }
}
