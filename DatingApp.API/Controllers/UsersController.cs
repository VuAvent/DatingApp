using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DatingApp.API.Controllers;
using DatingApp.API.Database.Entities;
using DatingApp.API.Database.Repository;
using DatingApp.API.DTOs;
using DatingApp.API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Namespace;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<MemberDto>> Get()
        {
            return Ok(_userRepository.GetMembers());
        }
        [Authorize]
        [HttpGet("{username}")]
        public ActionResult<MemberDto> Get (string username)
        {
            var member = _userRepository.GetMemberByUsername(username);
            if(member == null){
                return NotFound();
            }
            return Ok(_mapper.Map<MemberDto>(member));        
        }
    }
}