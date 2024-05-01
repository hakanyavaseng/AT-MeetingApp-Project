using MeetingApp.Entity.DTOs.User;
using MeetingApp.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService service)
        {
            _userService = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromForm] UserAddDto userAddDto)
        {
            if (userAddDto == null)
                return BadRequest(ModelState);
            bool success = await _userService.CreateUserAsync(userAddDto);

            if (success)
                return Ok();
            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            if (userLoginDto is null)
                return BadRequest();
            if(!userLoginDto.Password.Equals(userLoginDto.PasswordConfirm))
                return BadRequest(ModelState);

            return Ok(await _userService.LoginAsync(userLoginDto));
        }
    }
}
