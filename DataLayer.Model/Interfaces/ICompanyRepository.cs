using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Models;


namespace DataAccessLayer.Model.Interfaces
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAll();
        Company GetByCode(string companyCode);
        bool SaveCompany(Company company);
        Task<IEnumerable<Company>> GetAsyncAll();
        Task<Company> GetAsyncByCode(string companyCode);
        Task<bool> SaveAsyncCompany(Company company);
        Task<bool> DeleteAsyncCompany(string companyCode);
    }
}
