using FinalCaseForPapara.Business.Services.UserServices;
using FinalCaseForPapara.Dto.UserDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalCaseForPapara.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _userService.GetAllUserAsync();

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var response = await _userService.GetUserByIdAsync(id);

            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var response = await _userService.DeleteUserAsync(id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto updateUserDto)
        {
            var response = await _userService.UpdateUserAsync(updateUserDto);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var response = await _userService.RegisterAsync(registerDto);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var token = await _userService.LoginAsync(loginDto);
            return Ok(new { Token = token });
        }

        [HttpPost("CreateAdminUser")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAdminUser([FromBody] RegisterDto registerDto)
        {
            var response = await _userService.AddAdminUserAsync(registerDto);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
