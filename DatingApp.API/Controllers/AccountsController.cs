using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Database.Entities;
using DatingApp.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Namespace;
using System.Security.Cryptography;
using System.Text;
using DatingApp.API.Services;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseApiController
    {
        private readonly ITokenServices  _tokenService;
        private readonly DataContext _context;
        public AccountsController(DataContext context, ITokenServices tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }
        [HttpPost("register")]
        public ActionResult<string> Register(RegisterDto registerDto)
        {
            if(!ModelState.IsValid){
                return BadRequest("Username can not empty!");
            }
            registerDto.Username.ToLower();
            if(_context.Users.Any(u => u.Username == registerDto.Username)){
                return BadRequest("Username is existed!");
            }
            
            using var hmac = new HMACSHA512();
            var user = new User
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };
            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(new UserResponseDto
            {
                Username = user.Username,
                Token = _tokenService.CreateToken(user)
            });
        }

        [HttpPost("login")]
        public ActionResult<string> Login(LoginDto loginDto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == loginDto.Username.ToLower());
            if(user == null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for(var i = 0; i < computedHash.Length; i++)
            {
                if(computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
            }

            return Ok(new UserResponseDto
            {
                Username = user.Username,
                Token = _tokenService.CreateToken(user)
            });
        }


    }
}