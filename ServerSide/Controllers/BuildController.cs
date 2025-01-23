using Microsoft.AspNetCore.Mvc;
using ServerSide.Dto.BuildDtos;
using ServerSide.Model;
using ServerSide.Service;

namespace ServerSide.Controllers
{
    [ApiController]
    [Route("build")]
    public class BuildController(BuildService buildService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBuildsByUserId(int userId)
        {
            var builds = await buildService.GetAllBuildsByUserId(userId);
            return builds != null ? Ok(builds) : NotFound();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBuildById(int id)
        {
            var build = await buildService.GetBuildById(id);
            return build != null ? Ok(build) : NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> AddBuild(BuildAddDto buildAddDto)
        {
            var build = await buildService.AddBuild(buildAddDto);
            return build != null ? Ok(build) : BadRequest("Can't add this build");
        }
        [HttpPut()]
        public async Task<IActionResult> UpdateBuild(BuildUpdateDto buildUpdateDto)
        {
            var build = await buildService.UpdateBuild(buildUpdateDto);
            return build != null ? Ok(build) : NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuild(int id)
        {
            var build = await buildService.DeleteBuildById(id);
            return build != null ? Ok(build) : NotFound();
        }
        
    }
}