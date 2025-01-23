using Microsoft.AspNetCore.Mvc;
using ServerSide.Authentication;
using ServerSide.Dto.BuildDtos;
using ServerSide.Model;
using ServerSide.Service;

namespace ServerSide.Controllers
{
    [ApiController]
    [Route("build")]
    public class BuildController(BuildService _buildService, UserAccessToken userAccessToken) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBuildsByUserId([FromQuery] int userId)
        {
            if (!userAccessToken.IsAuthenticatedUser(userId))
            {
                return Unauthorized();
            }
            var builds = await _buildService.GetAllBuildsByUserId(userId);
            return builds != null ? Ok(builds) : NotFound();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBuildById([FromQuery] int id)
        {
            var build = await _buildService.GetBuildById(id);
            if (build == null || !userAccessToken.IsAuthenticatedUser(build.UserId))
            {
                return Unauthorized();
            }
            return build != null ? Ok(build) : NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> AddBuild(BuildAddDto buildAddDto)
        {

            var build = await _buildService.AddBuild(buildAddDto);
            return build != null ? Ok(build) : BadRequest("Can't add this build");
        }
        [HttpPut()]
        public async Task<IActionResult> UpdateBuild(BuildUpdateDto buildUpdateDto)
        {
            var build = await _buildService.UpdateBuild(buildUpdateDto);
            return build != null ? Ok(build) : NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuild(int id)
        {
            var buildUser = await _buildService.GetBuildById(id);
            if (buildUser == null || !userAccessToken.IsAuthenticatedUser(buildUser.UserId))
            {
                return Unauthorized();
            }
            var build = await _buildService.DeleteBuildById(id);
            return build != null ? Ok(build) : NotFound();
        }

    }
}