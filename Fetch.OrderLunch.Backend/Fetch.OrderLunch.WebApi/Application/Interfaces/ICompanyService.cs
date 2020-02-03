
using Fetch.OrderLunch.WebApi.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Interfaces
{
    public interface ICompanyService
    {
        List<CompanyViewModel> GetAll();
        Task<CompanyViewModel> GetById(int id);
        Task<CompanyViewModel> Add(CompanyViewModel companyVm);
        Task<CompanyViewModel> Update(CompanyViewModel companyVm);         
        Task Delete(ObjectID objectID);       
    }
}
