using System.Threading.Tasks;
using _6MKT.Identity.Api.Models.Request;
using _6MKT.Identity.Domain.Entities;
using _6MKT.Identity.Domain.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _6MKT.Identity.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserAddRequest user)
        {
            var userEntity = _mapper.Map<UserEntity>(user);
            var result = await _userService.AddAsync(userEntity);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest login)
        {
            var userEntity = _mapper.Map<UserEntity>(login);
            var result = await _userService.LoginAsync(userEntity);
            return Ok(result);
        }
    }
}
