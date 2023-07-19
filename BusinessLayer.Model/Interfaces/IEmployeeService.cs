using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Models;


namespace BusinessLayer.Model.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeInfo> GetAll();
        bool Insert(Employee employee);
        bool Update(Employee employee);
        EmployeeInfo GetEmployeeByCode(string employeeCode);
        bool Delete(string employeeCode);
    }
}
