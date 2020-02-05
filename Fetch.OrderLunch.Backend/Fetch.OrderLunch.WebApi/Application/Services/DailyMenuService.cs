
using Fetch.OrderLunch.WebApi.Application.Interfaces;
using Fetch.OrderLunch.WebApi.Application.Models;
using Fetch.OrderLunch.Core.Entities;
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

        public async Task AddFoodToDailyMenu(ObjectID objectID)
        {
            var userId = ExtensionMethod.GetUserId(_httpContextAccessor.HttpContext);
            if (userId == null)
            {
                throw new ArgumentNullException();
            }
         //   var result = await _dailyMenuRepository.ListAllAsync();
          //  var daily = result.Where(x => x.CreatorUserId == userId).FirstOrDefault();
            var dailyMenu =await _dailyMenuRepository.GetAsync(userId);
           
            dailyMenu.AddFoodToDailyMenu(objectID.Id, dailyMenu.Id);                     
            await _dailyMenuRepository.unitOfWork.SaveChangesAsync();
            
        }

        public async Task Create(DailyMenuViewModel dailyMenuVm)
        {
            var userId = ExtensionMethod.GetUserId(_httpContextAccessor.HttpContext);
            if (userId == null)
            {
                throw new ArgumentNullException();
            }

            var dailyMenu = new DailyMenu
            {
                Name = dailyMenuVm.Name,
                CreatorUserId = userId,
                CreationTime=DateTime.Now
            };
            await _dailyMenuRepository.AddAsync(dailyMenu);
            await _dailyMenuRepository.unitOfWork.SaveChangesAsync();
        }

        public async Task<DailyMenuViewModel> GetDailyMenu()
        {
            var userId = ExtensionMethod.GetUserId(_httpContextAccessor.HttpContext);
            if (userId == null)
            {
                throw new ArgumentNullException();
            }

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
            return new DailyMenuViewModel { Name = dailyMenu.Name, Foods = Foods };
        }
     
    }
}
