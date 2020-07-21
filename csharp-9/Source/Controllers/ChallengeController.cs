using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private IChallengeService challengeService;
        private IMapper mapper;

        public ChallengeController(IChallengeService service, IMapper mapper)
        {
            challengeService = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<ChallengeDTO> GetAll(int? accelerationId, int? userId)
        {
            if (accelerationId != null && userId != null)
            {
                return Ok(mapper.Map<List<ChallengeDTO>>(
                    (List<Models.Challenge>)challengeService.FindByAccelerationIdAndUserId((int)accelerationId, (int)userId))
                    );
            }

            return NoContent();
        }

        [HttpPost]
        public ActionResult<ChallengeDTO> Post([FromBody] ChallengeDTO value)
        {
            return Ok(mapper.Map<ChallengeDTO>(
                challengeService.Save(
                mapper.Map<Challenge.Models.Challenge>(value))));
        }
    }
}
