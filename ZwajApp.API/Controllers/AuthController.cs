using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZwajApp.API.Dtos;
using ZwajApp.API.Interfaces;
using ZwajApp.API.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace ZwajApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController:ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;

        public AuthController(IAuthRepository repo,IConfiguration config)
        {
            _repo=repo;
            _config=config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto ){
            //validtion
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();
            if(await _repo.UserExists(userForRegisterDto.Username))
            return BadRequest("هذا المستخدم مستخدم من قبل");
            var userToCreate=new User{
                UserName=userForRegisterDto.Username
            };

            var CreatedUser= await _repo.Register(userToCreate,userForRegisterDto.Password);
            return StatusCode(201);
            
        }

         [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto ){
            var userForRepo=await _repo.Login(userForLoginDto.Username.ToLower(),userForLoginDto.Password);
            if(userForRepo==null)return Unauthorized();

           var claims = new[]{
               new Claim(ClaimTypes.NameIdentifier,userForRepo.id.ToString()),
               new Claim(ClaimTypes.Name,userForRepo.UserName)
           };
         
            var key= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds =new SigningCredentials(key,SecurityAlgorithms.HmacSha512);
            var tokenDescriptor = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(claims),
                Expires= DateTime.Now.AddDays(1),
                SigningCredentials=creds          
                };

                var tokenHandler = new  JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new{
                token=tokenHandler.WriteToken(token)
            });
            
        }
    }
}