
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
        Task<List<FoodViewModel>> GetFoodBySupplier(int id);
        
        Task<FoodViewModel> Add(FoodViewModel foodVm);
        Task<FoodViewModel> Update(FoodViewModel foodVm);      
        Task Delete(ObjectID objectID);
    }
}
