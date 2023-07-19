using BusinessLayer.Model.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using System.Threading.Tasks;


namespace BusinessLayer.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        public IEnumerable<CompanyInfo> GetAllCompanies()
        {
            var res = _companyRepository.GetAll();
            return _mapper.Map<IEnumerable<CompanyInfo>>(res);
        }
        public void Insert(Company company)
        {
            _companyRepository.SaveCompany(company);
        }
        public void Update(Company company)
        {
            _companyRepository.SaveCompany(company);
        }

        public CompanyInfo GetCompanyByCode(string companyCode)
        {
            var result = _companyRepository.GetByCode(companyCode);
            return _mapper.Map<CompanyInfo>(result);
        }
        public async Task<IEnumerable<CompanyInfo>> GetAllAsyncCompanies()
        {
            var res = await _companyRepository.GetAsyncAll();
            return _mapper.Map<IEnumerable<CompanyInfo>>(res);
        }
        public async Task<bool> InsertAsync(Company company)
        {
            return await _companyRepository.SaveAsyncCompany(company);
        }
        public async Task<bool> UpdateAsync(Company company)
        {
            return await _companyRepository.SaveAsyncCompany(company);
        }

        public async Task<CompanyInfo> GetAsyncCompanyByCode(string companyCode)
        {
            var result = await _companyRepository.GetAsyncByCode(companyCode);
            return _mapper.Map<CompanyInfo>(result);
        }
        public async Task<bool> DeleteAsync(string companyCode) {
            return await _companyRepository.DeleteAsyncCompany(companyCode);
        }
    }
}
