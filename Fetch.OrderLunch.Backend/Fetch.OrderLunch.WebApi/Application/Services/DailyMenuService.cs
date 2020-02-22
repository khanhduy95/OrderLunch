
using Fetch.OrderLunch.WebApi.Application.Interfaces;
using Fetch.OrderLunch.WebApi.Application.Models;
using Fetch.OrderLunch.Core.Entities.CompanyAggregate;
using Fetch.OrderLunch.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fetch.OrderLunch.Core.Entities.SupplierAggregate;

namespace Fetch.OrderLunch.WebApi.Application.Services
{
    public class DailyMenuService : IDailyMenuService
    {
        private readonly IDailyMenuRepository _dailyMenuRepository;
        private readonly IAsyncRepository<Food> _foodRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DailyMenuService(IDailyMenuRepository dailyMenuRepository,
                                IAsyncRepository<Food> foodRepository,
                                IHttpContextAccessor httpContextAccessor)
        {
            _dailyMenuRepository = dailyMenuRepository ?? throw new ArgumentNullException(nameof(dailyMenuRepository));
            _foodRepository = foodRepository ?? throw new ArgumentNullException(nameof(foodRepository));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public async Task AddFoodToDailyMenu(FoodDaily food, string userId)
        {
            //var userId = ExtensionMethod.GetUserId(_httpContextAccessor.HttpContext);
            //if (userId == null)
            //{
            //    throw new ArgumentNullException();
            //}
            var dailyMenu =await _dailyMenuRepository.GetAsync(userId);
            if (dailyMenu==null)
            {
                throw new ArgumentException("DailyMenu is not exist!");
            };

            dailyMenu.AddFoodToDailyMenu(food.FoodId, dailyMenu.Id);
            await _dailyMenuRepository.unitOfWork.SaveChangesAsync();
        }

        public async Task Create(CreateDailyMenu dailyMenuVm)
        {
            var userId = ExtensionMethod.GetUserId(_httpContextAccessor.HttpContext);
            if (userId == null)
            {
                throw new ArgumentNullException();
            };

            var dailyMenu = new DailyMenu
            {
                Name = dailyMenuVm.Name,
                CreatorUserId = userId,
                CreationTime=DateTime.Now
            };
            await _dailyMenuRepository.AddAsync(dailyMenu);
            await _dailyMenuRepository.unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int dailyMenuId)
        {
            var dailyMenu = await _dailyMenuRepository.GetByIdAsync(dailyMenuId);
            if (dailyMenu == null)
            {
                throw new ArgumentNullException("Category is null");
            };

            await _dailyMenuRepository.DeleteAsync(dailyMenu);
        }

        public async Task<IEnumerable<DisplayDailyMenu>> GetAll()
        {
            var results = await _dailyMenuRepository.ListAllAsync();
            var model = results.Select(x => new DisplayDailyMenu
                                {   
                                    Id=x.Id,
                                    Name=x.Name,
                                    Date=x.CreationTime
                                }).ToList();
            return model;
        }


        public async Task<DailyMenuViewModel> GetDailyMenu(string userId)
        {
            var dailyMenu = await _dailyMenuRepository.GetAsync(userId);
            var Foods = new List<FoodViewModel>();
                           
            foreach(var item in dailyMenu.GetFood())
            {
                var results = await _foodRepository.ListAllAsync();

                var food = results.Where(i=>i.Id==item.FoodId)
                    .Select(x => new FoodViewModel
                    {
                        Id = x.Id,
                        Name = x.Name
                    }).FirstOrDefault();
                
                Foods.Add(food);
                
            };
            return new DailyMenuViewModel {
                Name = dailyMenu.Name,
                Foods = Foods
            };
        }

        public async Task<DailyMenuViewModel> GetDailyMenuToDay()
        {
            var result =await _dailyMenuRepository.ListAllAsync();
            var dailyMenu = result.Where(x => x.CreationTime == DateTime.Today).FirstOrDefault();
            
            var Foods = new List<FoodViewModel>();
            foreach (var item in dailyMenu.GetFood())
            {
                var results = await _foodRepository.ListAllAsync();

                var food = results.Where(i => i.Id == item.FoodId)
                    .Select(x => new FoodViewModel
                    {
                        Id = x.Id,
                        Name = x.Name
                    }).FirstOrDefault();

                Foods.Add(food);

            };

            return new DailyMenuViewModel
            {
                Name = dailyMenu.Name,
                Foods = Foods
            };
        }
    }
}
