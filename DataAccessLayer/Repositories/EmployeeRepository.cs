﻿using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using BusinessLayer.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly IDbWrapper<Employee> _employeeDbWrapper;
        public EmployeeRepository(IDbWrapper<Employee> employeeDbWrapper) {
            _employeeDbWrapper = employeeDbWrapper;
        }
        public IEnumerable<Employee> GetAll()
        {
            return _employeeDbWrapper.FindAll();
        }

        public Employee GetByCode(string employeeCode)
        {
            return _employeeDbWrapper.Find(t => t.EmployeeCode.Equals(employeeCode))?.FirstOrDefault();
        }

        public bool SaveEmployee(Employee employee)
        {
            var itemRepo = _employeeDbWrapper.Find(t =>
                t.SiteId.Equals(employee.SiteId) && t.CompanyCode.Equals(employee.CompanyCode) && t.EmployeeCode.Equals(employee.EmployeeCode))?.FirstOrDefault();
            if (itemRepo != null)
            {
                itemRepo.EmployeeName = employee.EmployeeName;
                itemRepo.Occupation = employee.Occupation;
                itemRepo.EmployeeStatus = employee.EmployeeStatus;
                itemRepo.EmailAddress = employee.EmailAddress;
                itemRepo.Phone = employee.Phone;
                return _employeeDbWrapper.Update(itemRepo);
            } 

            return _employeeDbWrapper.Insert(employee);
        }
        public bool DeleteEmployee(string employeeCode)
        {
            return _employeeDbWrapper.Delete(t => t.EmployeeCode.Equals(employeeCode));
        }
    }
}
