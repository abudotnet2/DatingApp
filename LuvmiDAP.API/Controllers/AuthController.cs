using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LuvmiDAP.API.Data;
using LuvmiDAP.API.Model;
using LuvmiDAP.API.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LuvmiDAP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration config;

        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            this._repo = repo;
            this.config = config;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto  model)
        {
            // validate request

            if (await _repo.UserExist(model.Username.ToLower()))
                return BadRequest("User already exist");

            var _user = new User()
            {
                Username = model.Username
            };

            await _repo.Register(_user, model.Password);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDto model)
        {
            var user = await _repo.Login(model.Username.ToLower(), model.Password);

            if (user == null) return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
                 new Claim(ClaimTypes.Name , user.Username),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(config.GetSection("AppSettings:token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDesc = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = cred
            };

            var _token = new JwtSecurityTokenHandler().WriteToken(new JwtSecurityTokenHandler().CreateToken(tokenDesc));

            return Ok(new { token = _token });
        }
    }
}