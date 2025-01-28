using Microsoft.AspNetCore.Mvc;
using ServerSide.Model;
using ServerSide.Repository;

namespace ServerSide.Controllers
{
    [ApiController]
    [Route("category")]
    public class CategoryController(IRepository<Category> _repository) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok( await _repository.GetAll());
        }
    }
}