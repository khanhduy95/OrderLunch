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

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<MenuViewModel> GetMenuById(int supplierId)
        {
            var menu = await _menuRepository.GetAsync(supplierId);
            if (menu == null)
            {
                throw new ArgumentNullException("menu is null");
            }
            var menuVm = new MenuViewModel
            {
                ExprireTime = menu.ExprireTime,
                Foods = menu.Foods
                  .Where(x => x.MenuId == menu.Id)
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

        public async Task Update(MenuViewModel menuVm)
        {
            var menu = await _menuRepository.FindAsync(menuVm.Id);
            if (menu == null)
            {
                throw new ArgumentNullException(nameof(menu));
            }
            menu.CreationTime = DateTime.Now;

            _menuRepository.UpdateMenu(menu);
           await _menuRepository.unitOfWork.SaveChangesAsync();
        }

    }
}
