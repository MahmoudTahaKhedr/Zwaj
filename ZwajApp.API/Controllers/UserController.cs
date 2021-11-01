
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZwajApp.API.Dtos;
using ZwajApp.API.Interfaces;

namespace ZwajApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly IZwajRepository _repo;
        private readonly IMapper _mapper;

        public UserController(IZwajRepository repo,IMapper mapper)
        {
            _repo=repo;
            _mapper=mapper;
        }

        [HttpGet]
        public async Task <IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();
            var usersToDetails=_mapper.Map<IEnumerable<UserForDetailsDto>>(users);
             return Ok(usersToDetails);
            
        }

         [HttpGet("{id}")]
         public async Task <IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUser(id);
            var userToReturn=_mapper.Map<UserForDetailsDto>(user);
             return Ok(userToReturn);
            
        }
        
    }
}