using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }
        // GET api/<controller>
        public async Task<IEnumerable<CompanyDto>> GetAll()
        {
            var items = await _companyService.GetAllAsyncCompanies();
            return _mapper.Map<IEnumerable<CompanyDto>>(items);
        }

        // GET api/<controller>/5
        public async Task<CompanyDto> Get(string companyCode)
        {
            var item = await _companyService.GetAsyncCompanyByCode(companyCode);
            return _mapper.Map<CompanyDto>(item);
        }

        // POST api/<controller>
        public async Task<IHttpActionResult> Post(Company company)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            await _companyService.InsertAsync(company);
            return Ok();
        }

        // PUT api/<controller>/5
        public async Task<IHttpActionResult> Put(string id, Company company)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            if (id != company.CompanyCode)
                return BadRequest("Not a valid model");
            await _companyService.UpdateAsync(company);
            return Ok();
        }

        // DELETE api/<controller>/5
        public async Task<IHttpActionResult> Delete(string id)
        {
            var item = await _companyService.GetAsyncCompanyByCode(id);
            if (item == null) return NotFound();
            await _companyService.DeleteAsync(id);
            return Ok();
        }
    }
}