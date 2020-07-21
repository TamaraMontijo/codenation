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
    public class UserController : ControllerBase
    {
        private IUserService userService;
        private IMapper mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            userService = service;
            this.mapper = mapper;
        }

        // GET api/user
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetAll(string accelerationName = null, int? companyId = null)
        {
            List<UserDTO> mappedUsers = new List<UserDTO>();

            if (accelerationName != null && companyId == null)
                return Ok(mapper.Map<List<UserDTO>>(
                    (List<User>)userService.FindByAccelerationName(accelerationName))
                    );
            if (accelerationName == null && companyId != null)
                return Ok(mapper.Map<List<UserDTO>>(
                    (List<User>)userService.FindByCompanyId((int)companyId))
                    );
            return NoContent();
        }

        // GET api/user/{id}
        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {
            return Ok(mapper.Map<UserDTO>(
                userService.FindById(id))
                );
        }

        // POST api/user
        [HttpPost]
        public ActionResult<UserDTO> Post([FromBody] UserDTO value)
        {
            return Ok(mapper.Map<UserDTO>(
                userService.Save(mapper.Map<User>(value))
                ));
        }   
     
    }
}
