using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public IEnumerable<EmployeeInfo> GetAll()
        {
            var res = _employeeRepository.GetAll();
            return _mapper.Map<IEnumerable<EmployeeInfo>>(res);
        }
        public bool Insert(Employee employee)
        {
            return _employeeRepository.SaveEmployee(employee);
        }
        public bool Update(Employee employee)
        {
            return _employeeRepository.SaveEmployee(employee);
        }

        public EmployeeInfo GetEmployeeByCode(string employeeCode)
        {
            var result = _employeeRepository.GetByCode(employeeCode);
            return _mapper.Map<EmployeeInfo>(result);
        }
        public bool Delete(string employeeCode)
        {
            return _employeeRepository.DeleteEmployee(employeeCode);
        }
    }
}
