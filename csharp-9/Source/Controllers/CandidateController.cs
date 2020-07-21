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
    public class CandidateController : ControllerBase
    {
        private ICandidateService candidateService;
        private IMapper mapper;

        public CandidateController(ICandidateService service, IMapper mapper)
        {
            candidateService = service;
            this.mapper = mapper;
        }

        [HttpGet("{userId}/{accelerationId}/{companyId}")]
        public ActionResult<CandidateDTO> Get(int userId, int accelerationId, int companyId)
        {
            return Ok(
                mapper.Map<CandidateDTO>(
                    candidateService.FindById(userId, accelerationId, companyId))
                );
        }

        [HttpGet]
        public ActionResult<IEnumerable<CandidateDTO>> GetAll(int? companyId = null, int? accelerationId = null)
        {
            if (companyId != null && accelerationId == null)
            {
                return Ok(mapper.Map<List<CandidateDTO>>(
                    (List<Candidate>)candidateService.FindByCompanyId((int) companyId)
                    ));
            }

            if (companyId == null && accelerationId != null)
            {
                return Ok(mapper.Map<List<CandidateDTO>>(
                    (List<Candidate>)candidateService.FindByAccelerationId((int) accelerationId)
                    ));
            }

            return NoContent();            
        }

        [HttpPost]
        public ActionResult<CandidateDTO> Post([FromBody] CandidateDTO value)
        {
            return Ok(mapper.Map<CandidateDTO>(
                candidateService.Save(
                    mapper.Map<Candidate>(value)
                    )));
        }
    }
}
