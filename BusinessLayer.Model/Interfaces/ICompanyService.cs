using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Models;


namespace BusinessLayer.Model.Interfaces
{
    public interface ICompanyService
    {
        IEnumerable<CompanyInfo> GetAllCompanies();
        void Insert(Company company);
        void Update(Company company);
        CompanyInfo GetCompanyByCode(string companyCode);
        Task<IEnumerable<CompanyInfo>> GetAllAsyncCompanies();
        Task<bool> InsertAsync(Company company);
        Task<bool> UpdateAsync(Company company);
        Task<CompanyInfo> GetAsyncCompanyByCode(string companyCode);
        Task<bool> DeleteAsync(string companyCode);
    }
}
