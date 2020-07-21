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
    public class SubmissionController : ControllerBase
    {
        private ISubmissionService submissionService;
        private IMapper mapper;

        public SubmissionController(ISubmissionService service, IMapper mapper)
        {
            submissionService = service;
            this.mapper = mapper;
        }

        [HttpGet("higherScore")]
        public ActionResult<SubmissionDTO> GetHigherScore(int? challengeId = null)
        {
            if (challengeId != null)
            {
                return Ok(
                    submissionService.FindHigherScoreByChallengeId(
                        (int) challengeId)
                    );
            }

            return NoContent();
        }

        [HttpGet]
        public ActionResult<IEnumerable<SubmissionDTO>> GetAll(int? challengeId = null, int? accelerationId = null)
            {
                if (challengeId != null && accelerationId != null)
                {
                    return Ok(mapper.Map<List<SubmissionDTO>>(
                      (List<Submission>)submissionService
                        .FindByChallengeIdAndAccelerationId(
                          (int)challengeId,
                          (int)accelerationId
                        )
                    ));
                }

                return NoContent();
            }

        [HttpPost]
        public ActionResult<SubmissionDTO> Post([FromBody] SubmissionDTO value)
        {
            return Ok(
                mapper.Map<SubmissionDTO>(
                    submissionService.Save(mapper.Map<Submission>(value)
                    )));
        }
    }
}
