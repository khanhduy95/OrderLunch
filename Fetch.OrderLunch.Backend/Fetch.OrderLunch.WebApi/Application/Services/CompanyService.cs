
using Fetch.OrderLunch.WebApi;
using Fetch.OrderLunch.Core.Entities.CompanyAggregate;
using Fetch.OrderLunch.Core.Interfaces;
using Fetch.OrderLunch.WebApi.Application.Interfaces;
using Fetch.OrderLunch.WebApi.Application.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Fetch.OrderLunch.WebApi.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IAsyncRepository<Company> _asyncRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CompanyService(
            IAsyncRepository<Company> asyncRepository, 
            IHttpContextAccessor httpContextAccessor)
        {
            _asyncRepository = asyncRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task Add(CompanyViewModel companyVm)
        {
            var userId = ExtensionMethod.GetUserId(_httpContextAccessor.HttpContext);
            if (userId == null)
            {
                throw new ArgumentNullException("UserId is null");
            }
            var company = new Company
            {
                Name = companyVm.Name,
                Address = companyVm.Address,
                HotLine = companyVm.HotLine,
                CreatorUserId = userId,
                CreationTime = DateTime.Now
            };
            await _asyncRepository.AddAsync(company);
            await _asyncRepository.unitOfWork.SaveChangesAsync();           
        }

        public async Task Delete(ObjectID objectID)
        {
            var company = await _asyncRepository.GetByIdAsync(objectID.Id);
            if (company != null)
            {
                await _asyncRepository.DeleteAsync(company);

            }
        }

        public async Task<IEnumerable<CompanyViewModel>> GetAll()
        {
            var companies = await _asyncRepository.ListAllAsync();
            var company = companies.Select(x => new CompanyViewModel
            {
                Id=x.Id,
                Name=x.Name,
                Address=x.Address,
                HotLine=x.HotLine
            });

            return company;
        }

        public async Task<CompanyViewModel> GetCompanyById(int id)
        {
            var query =await _asyncRepository.GetByIdAsync(id);
            if (query == null)
            {
                throw new ArgumentNullException(nameof(CompanyViewModel));
            }
            return new CompanyViewModel
            {
                Id = query.Id,
                Name = query.Name,
                Address = query.Address,
                HotLine = query.HotLine
            };
        }

  
        public async Task Update(CompanyViewModel companyVm)
        {
            var query =await _asyncRepository.GetByIdAsync(companyVm.Id);
            if (query == null)
            {
                throw new ArgumentNullException(nameof(CompanyViewModel));
            }
            query.Name = companyVm.Name;
            query.Address = companyVm.Address;
            query.HotLine = companyVm.HotLine;

            await _asyncRepository.UpdateAsync(query);
            await _asyncRepository.unitOfWork.SaveChangesAsync();
        }
    }
}
