using AutoMapper;
using ExpenceTracker.Dtos;
using ExpenceTracker.Filters;
using ExpenceTracker.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenceTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        
        private readonly IUsersService _usersService;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IUsersService usersService, IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _usersService = usersService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get informations about users
        /// </summary>

        [HttpGet("getAllUsers")]
        public async Task<ActionResult<UserDTO>> GetAllUsers()
        {
            BaseResponse<UserDTO> response = new ();

            var users = await _usersService.ListAsync();

            response.Data = _mapper.Map<IList<UserDTO>>(users.Data).ToList();
            response.Count = users.Count;
            return Ok(response);
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            var user = await _usersService.GetByIdAsync(id);
            var response = _mapper.Map<UserDTO>(user);
            return Ok(response);
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var user = _userRepository.Authenticate(model.Name, model.Password);
            if (user == null){
                return BadRequest(new {message = "UserName or password is incorrect"});
            }

            return Ok(user);
        }
    }
}
