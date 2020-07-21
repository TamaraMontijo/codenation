using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private ICompanyService companyService;
        private IMapper mapper;

        public CompanyController(ICompanyService service, IMapper mapper)
        {
            companyService = service;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<CompanyDTO> Get(int id)
        {
            return Ok(mapper.Map<CompanyDTO>(companyService.FindById(id)));
        }

        [HttpGet]
        public ActionResult<IEnumerable<CompanyDTO>> GetAll(int? accelerationId = null, int? userId = null)
        {
            if (accelerationId != null && userId == null)
            {
                return Ok(mapper.Map<List<CompanyDTO>>(
                    (List<Company>)companyService.FindByAccelerationId((int)accelerationId)));
            }

            if (accelerationId == null && userId != null)
            {
                return Ok(mapper.Map<List<CompanyDTO>>(
                    (List<Company>)companyService.FindByUserId((int)userId)));                
            }

            return NoContent();
        }

        [HttpPost]
        public ActionResult<CompanyDTO> Post([FromBody] CompanyDTO value)
        {
            return Ok(mapper.Map<CompanyDTO>(
                companyService.Save(mapper.Map<Company>(value))));
        }
    }
}
