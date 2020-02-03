using Fetch.OrderLunch.WebApi.Application.Interfaces;
using Fetch.OrderLunch.WebApi.Application.Models;
using Fetch.OrderLunch.Core.Entities.SupplierAggregate;
using Fetch.OrderLunch.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IAsyncRepository<Menu> _asyncMenuRepository;
        private readonly IAsyncRepository<Food> _asyncFoodRepository;

        public MenuService(IMenuRepository menuRepository,
                           IAsyncRepository<Menu> asyncMenuRepository,
                           IAsyncRepository<Food> asyncFoodRepository)
        {
            _menuRepository = menuRepository;
            _asyncMenuRepository = asyncMenuRepository;
            _asyncFoodRepository = asyncFoodRepository;
        }

        public async Task<MenuViewModel> GetMenuById(int supplierId)
        {
            var menu = await _menuRepository.GetAsync(supplierId);
            if (menu != null)
            {
                var menuVm = new MenuViewModel
                {
                    Foods = menu.Foods
                    .Select(x =>
                        new FoodViewModel
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Description = x.Description,
                            Price = x.Price
                        })
                    .ToList()
                };
                return menuVm;
            }
            throw new ArgumentNullException("menu is null");
        }

        public Task Update(MenuViewModel menuVm)
        {
            throw new NotImplementedException();
        }

        //public async Task<MenuViewModel> GetMenuById(int supplierId)
        //{
        //    var menu = await _menuRepository.GetAsync(supplierId);
        //    if (menu != null)
        //    {
        //        var menuVm = new MenuViewModel
        //        {
        //            Foods = menu.Foods
        //            .Select(x =>
        //                new FoodViewModel
        //                {
        //                    Id=x.Id,
        //                    Name=x.Name,
        //                    Description=x.Description,
        //                    Price=x.Price
        //                })
        //            .ToList()
        //        };
        //        return menuVm;
        //    }
        //    throw new ArgumentNullException("menu is null");
        //}

        //public async Task Update(MenuViewModel menuVm)
        //{
        //    var menu = await _asyncMenuRepository.GetByIdAsync(menuVm.Id);
        //    if (menu == null)
        //    {
        //        throw new ArgumentNullException(nameof(menu));
        //    }           
        //    menu.CreationTime = DateTime.Now;
        //    await _asyncMenuRepository.unitOfWork.SaveChangesAsync();
        //}

    }
}
