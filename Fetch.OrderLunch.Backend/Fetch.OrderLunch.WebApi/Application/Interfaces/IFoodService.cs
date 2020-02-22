
using Fetch.OrderLunch.WebApi.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Interfaces
{
    public interface IFoodService
    {
        Task<PaginatedItemsViewModel<FoodViewModel>> GetFoodByCategory(int id,int pageSize,int pageIndex);
        Task<PaginatedItemsViewModel<FoodViewModel>> GetAll(int pageIndex, int pageSize);
        Task<FoodViewModel> GetFoodById(int id);
        Task<PaginatedItemsViewModel<FoodViewModel>> SearchFoodByFoodName(string foodName, int pageIndex, int pageSize);
        Task Add(FoodInput foodVm);
        Task Update(FoodViewModel foodVm,int id);      
        Task Delete(int foodId);
    }
}
