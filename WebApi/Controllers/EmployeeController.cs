using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using WebApi.Models;
using log4net;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            // Initialize log4net
            log.Info("Logging initialized");
        }
        // GET api/<controller>
        public IEnumerable<EmployeeDto> GetAll()
        {
            var items = _employeeService.GetAll();
            log.Info("Read All Employees");
            return _mapper.Map<IEnumerable<EmployeeDto>>(items);
        }

        // GET api/<controller>/5
        public EmployeeDto Get(string employeeCode)
        {
            var item = _employeeService.GetEmployeeByCode(employeeCode);
            log.Info($"Read One Employee with code {employeeCode}");
            return _mapper.Map<EmployeeDto>(item);
        }

        // POST api/<controller>
        public IHttpActionResult Post(Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            try
            {
                if(_employeeService.Insert(employee) ) return Ok();
                log.Error("Failed in creating new Employee");
                return BadRequest("Failed in creating new Employee.");
            }
            catch (System.Exception e)
            {
                log.Error($"Failed in creating new Employee: '{e}'");
            }
            return BadRequest("Failed in creating new Employee.");
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(string id, Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            if (id != employee.EmployeeCode)
            {
                log.Error($"Not equal  id:{id} with employee code {employee.EmployeeCode}");
                return BadRequest($"Not equal  id:{id} with employee code {employee.EmployeeCode}");
            }
            try
            {
                if (_employeeService.Update(employee)) return Ok();
                log.Error("Failed in updating new Employee");
                return BadRequest("Failed in updating new Employee.");
            }
            catch (System.Exception e)
            {
                log.Error($"Failed in updating Employee: '{e}' with employee code {employee.EmployeeCode}");
            }

            return BadRequest($"Failed in updating Employee with employee code {employee.EmployeeCode}");
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(string id)
        {
            var item = _employeeService.GetEmployeeByCode(id);
            if (item == null) return NotFound();
            try
            {
                if (_employeeService.Delete(id)) return Ok();
                log.Error($"Failed in removing Employee with employee code {id}");
                return BadRequest("Failed in updating new Employee.");
            }
            catch (System.Exception e)
            {
                log.Error($"Failed in removing Employee: '{e}' with employee code {id}");
            }
            return BadRequest($"Failed in removing Employee with employee code {id}");
        }
    }
}