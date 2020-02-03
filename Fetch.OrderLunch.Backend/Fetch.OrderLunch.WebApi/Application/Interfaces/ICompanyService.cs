
using Fetch.OrderLunch.WebApi.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyViewModel>> GetAll();
        Task<CompanyViewModel> GetCompanyById(int id);
        Task Add(CompanyViewModel companyVm);
        Task Update(CompanyViewModel companyVm);         
        Task Delete(ObjectID objectID);       
    }
}
