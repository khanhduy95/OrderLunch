
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

namespace Fetch.OrderLunch.WebApi.Application.Services
{
    public class DailyMenuService : IDailyMenuService
    {
        private readonly IDailyMenuRepository _dailyMenuRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DailyMenuService(IDailyMenuRepository dailyMenuRepository,
                                IHttpContextAccessor httpContextAccessor)
        {
            _dailyMenuRepository = dailyMenuRepository ?? throw new ArgumentNullException(nameof(dailyMenuRepository));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public async Task AddFoodToDailyMenu(ObjectID objectID)
        {
            var userId = ExtensionMethod.GetUserId(_httpContextAccessor.HttpContext);
            if (userId == null)
            {
                throw new ArgumentNullException();
            }
            var dailyMenu =await _dailyMenuRepository.GetAsync(userId);
            dailyMenu.AddFoodToDailyMenu(objectID.Id,dailyMenu.Id);

            await _dailyMenuRepository.AddAsync(dailyMenu);
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
            };
            await _dailyMenuRepository.AddAsync(dailyMenu);
            await _dailyMenuRepository.unitOfWork.SaveChangesAsync();
        }

        public async Task<DailyMenuViewModel> GetDailyMenuById()
        {
           

            return null;

        }
     
    }
}
