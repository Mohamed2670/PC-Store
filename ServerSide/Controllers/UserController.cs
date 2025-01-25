using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServerSide.Authentication;
using ServerSide.Dto.UserDtos;
using ServerSide.Service;

namespace ServerSide.Controllers
{
    [ApiController]
    [Route("user")]
    [Authorize(Policy = "Admin")]


    public class UserController(UserService _userService,UserAccessToken userAccessToken) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return users != null ? Ok(users) : NotFound();

        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUserById(int id)
        {
            if (!userAccessToken.IsAuthenticatedUser(id))
            {
                return Unauthorized();
            }
            var user = await _userService.GetUserById(id);
            return user != null ? Ok(user) : NotFound();
        }
        [HttpGet("by-email/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmail(email);
            return user != null ? Ok(user) : NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(UserAddDto userAddDto)
        {
            var user = await _userService.GetUserByEmail(userAddDto.Email);
            if (user == null)
            {
                return BadRequest("User already exists");
            }
            user = await _userService.AddUser(userAddDto);

            return user != null ? Ok(user) : NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            var userDeleted = await _userService.DeleteUserById(id);
            return userDeleted != null ? Ok(userDeleted) : NotFound();
        }
        [HttpPut("{email}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateUser(UserUpdateDto userUpdateDto, string email)
        {
            
            var user = await _userService.GetUserByEmail(email);
            if (user == null)
            {
                return BadRequest("User does not exist");
            }
            if (!userAccessToken.IsAuthenticatedUser(user.Id))
            {
                return Unauthorized();
            }
            var userUpdated = await _userService.UpdateUser(userUpdateDto, email);
            return Ok(userUpdated);
        }
    }
}