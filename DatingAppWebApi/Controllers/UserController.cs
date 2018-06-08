using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DatingAppDal.Context;
using DatingAppDal.Repositories.DatingRepo;
using DatingAppWebApi.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingAppWebApi.Controllers
{
    [Authorize]
    [Route("api/Users")]
    public class UserController:Controller
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;
        public UserController(IDatingRepository repo, IMapper mapper)
        {
            _repo= repo;
            _mapper=mapper;
        }

        [HttpGet]
        [HttpOptions]
        public async Task<IActionResult> GetUsers()
        {
            var users= await _repo.GetUsers();
            var UserLists= _mapper.Map<IEnumerable<UserListDto>>(users);
            return Ok(UserLists);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int Id)
        {
            var user= await _repo.GetUser(Id);
            var UserDetails= _mapper.Map<UserDetailsDto>(user);
            return Ok (UserDetails);
        }
    }
}