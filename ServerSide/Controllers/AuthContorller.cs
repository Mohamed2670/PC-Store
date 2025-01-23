using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ServerSide.Dto.UserDtos;
using ServerSide.Service;

namespace ServerSide.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController(UserService _userService) : ControllerBase

    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserAddDto userAddDto)
        {
            var oldUser = await _userService.GetUserByEmail(userAddDto.Email);
            if(oldUser!=null)
            {
                return BadRequest("This email is already exist");
            }
            userAddDto.Password = BCrypt.Net.BCrypt.HashPassword(userAddDto.Password);
            var user = await _userService.AddUser(userAddDto);
            return Ok(user);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var token = await _userService.Login(userLoginDto);
            return token != null ? Ok(token) : BadRequest("Invalid email or password");
        }
    }


}