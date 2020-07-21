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
    public class AccelerationController : ControllerBase
    {
        private IAccelerationService accelerationService;
        private IMapper mapper;

        public AccelerationController(IAccelerationService service, IMapper mapper)
        {
            accelerationService = service;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<AccelerationDTO> Get(int id)
        {
            return Ok(mapper.Map<AccelerationDTO>(accelerationService.FindById(id)));
        }

        [HttpGet]
        public ActionResult<IEnumerable<AccelerationDTO>> GetAll(int? companyId = null)
        {
            if (companyId == null)
                return NoContent();
            return Ok(mapper.Map<List<AccelerationDTO>>(
                (List<Acceleration>)accelerationService.FindByCompanyId((int)companyId)
                ));
        }

        [HttpPost]
        public ActionResult<AccelerationDTO> Post([FromBody] AccelerationDTO value)
        {
            return Ok(mapper.Map<AccelerationDTO>(
                accelerationService.Save(mapper.Map<Acceleration>(value))
                ));
        }
    }
}
