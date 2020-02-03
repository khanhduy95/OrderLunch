
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

        public async Task<CompanyViewModel> Add(CompanyViewModel companyVm)
        {
            var userId = ExtensionMethod.GetUserId(_httpContextAccessor.HttpContext);
            if (userId != null)
            {
                var company = new Company
                {
                    Name = companyVm.Name,
                    Address = companyVm.Address,
                    HotLine = companyVm.HotLine,
                    CreatorUserId=userId,
                    CreationTime = DateTime.Now
                };
               await _asyncRepository.AddAsync(company);
              //  await _repository.unitOfWork.SaveChangesAsync();
                return companyVm;
            }
            throw new ArgumentNullException();
        }

        public async Task Delete(ObjectID objectID)
        {
            var company = await _asyncRepository.GetByIdAsync(objectID.Id);
            if (company != null)
            {
                await _asyncRepository.DeleteAsync(company);

            }

        }

        public List<CompanyViewModel> GetAll()
        {

            return null;
        }

        public async Task<CompanyViewModel> GetById(int id)
        {
            var query =await _asyncRepository.GetByIdAsync(id);
            if (query == null)
            {
                throw new ArgumentNullException(nameof(CompanyViewModel));
            }
            return new CompanyViewModel(query.Id, query.Name, query.Address, query.HotLine, query.CreationTime,
                                        query.IsActive);
        }

  
        public async Task<CompanyViewModel> Update(CompanyViewModel companyVm)
        {
            var query =await _asyncRepository.GetByIdAsync(companyVm.Id);
            if (query == null)
            {
                throw new ArgumentNullException(nameof(CompanyViewModel));
            }
            await _asyncRepository.UpdateAsync(query);        
            return companyVm;
        }
    }
}
