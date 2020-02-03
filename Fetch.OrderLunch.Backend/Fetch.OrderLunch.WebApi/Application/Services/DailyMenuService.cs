
using Fetch.OrderLunch.WebApi.Application.Interfaces;
using Fetch.OrderLunch.WebApi.Application.Models;
using Fetch.OrderLunch.Core.Entities;
using Fetch.OrderLunch.Core.Entities.CompanyAggregate;
using Fetch.OrderLunch.Core.Interfaces;
using Fetch.OrderLunch.WebApi.Application.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Services
{
    public class DailyMenuService : IDailyMenuService
    {
        private readonly IRepository<DailyMenu> _repository;
        private readonly IAsyncRepository<DailyMenu> _asyncDailyMenuRepository;
        private readonly IAsyncRepository<FoodDailyMenu> _asyncFoodDailyMenuRepository;
        private readonly IDailyMenuRepository _dailyMenuRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DailyMenuService(IRepository<DailyMenu> repository,
                                IAsyncRepository<DailyMenu> asyncDailyMenuRepository,
                                IAsyncRepository<FoodDailyMenu> asyncFoodDailyMenuRepository,
                                IDailyMenuRepository dailyMenuRepository,
                                IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _asyncDailyMenuRepository = asyncDailyMenuRepository;
            _asyncFoodDailyMenuRepository = asyncFoodDailyMenuRepository;
            _dailyMenuRepository = dailyMenuRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddFoodToDailyMenu(ObjectID objectID)
        {
            var userId = ExtensionMethod.GetUserId(_httpContextAccessor.HttpContext);
            if (userId == null)
            {
                throw new ArgumentNullException();
            }
            var dailyMenu = _repository.ListAll()
                                       .Where(x => x.CreatorUserId == userId)
                                       .FirstOrDefault();

            var foodDailyMenu = new FoodDailyMenu
            {
                FoodId = objectID.Id,
                DailyMenuId = dailyMenu.Id
            };
            await _asyncFoodDailyMenuRepository.AddAsync(foodDailyMenu);
            await _asyncFoodDailyMenuRepository.unitOfWork.SaveChangesAsync();
            
        }

        public async Task Create(DailyMenuViewModel dailyMenuVm)
        {
            var userId = ExtensionMethod.GetUserId(_httpContextAccessor.HttpContext);
            if (userId == null)
            {
                throw new ArgumentNullException();
            }
            
            //var dailyMenu = new DailyMenu
            //{
            //    Name = dailyMenuVm.Name,
            //    CreatorUserId = userId,
            //};
            //await _asyncDailyMenuRepository.AddAsync(dailyMenu);
            await _asyncDailyMenuRepository.unitOfWork.SaveChangesAsync();
        }

        public async Task<DailyMenuViewModel> GetDailyMenuById()
        {
            var userId = ExtensionMethod.GetUserId(_httpContextAccessor.HttpContext);
            if (userId==null) 
            {
                throw new ArgumentNullException();
            }
            var dailyMenu = await _dailyMenuRepository.GetAsync(userId);
            var foodDailys = await _asyncFoodDailyMenuRepository.GetByIdAsync(dailyMenu.Id);
            var model = new DailyMenuViewModel
            {
                Foods = dailyMenu.Foods
                .Where(x => x.Id == foodDailys.Id)
                .Select(x => new FoodViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    MenuId = x.MenuId,
                    Price = x.Price,
                    Description = x.Description

                })
                .ToList()
            };

            return model;

        }
     
    }
}
