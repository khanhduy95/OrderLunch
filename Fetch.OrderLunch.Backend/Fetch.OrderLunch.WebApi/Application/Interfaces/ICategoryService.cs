using Fetch.OrderLunch.WebApi.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAll();
        Task<CategoryViewModel> GetById(int id);
        Task Add(CategoryViewModel categoryVm);
        Task Update(CategoryViewModel categoryVm);
        Task HardDelete(ObjectID objectID);
        Task Delete(ObjectID objectID);
    }
}
