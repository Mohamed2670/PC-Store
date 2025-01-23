using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using ServerSide.Dto.StoreDtos;
using ServerSide.Service;

namespace ServerSide.Controllers
{
    [ApiController]
    [Route("store")]
    public class StoreController(StoreService _storeService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllStores()
        {
            var stores = await _storeService.GetAllStores();
            return stores != null ? Ok(stores) : NotFound();

        }
        [HttpGet("{name}")]
        public async Task<IActionResult> GetStoreByName(string name)
        {
            var store = await _storeService.GetStoreByName(name);
            return store != null ? Ok(store) : NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> AddStore(StoreAddDto storeAddDto)
        {
            var store = await _storeService.AddStore(storeAddDto);
            return store != null ? Ok(store) : BadRequest("Can't add store");
        }
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteStoreByName(string name)
        {
            var store = await _storeService.DeleteStoreByName(name);
            return store != null ? Ok(store) : BadRequest("Can't delete store");
        }
        [HttpPut("{name}")]
        public async Task<IActionResult> UpdateStore(StoreUpdateDto storeUpdateDto,string name)
        {
            var store = await _storeService.UpdateStore(storeUpdateDto, name);
            return store != null ? Ok(store) : BadRequest("Can't update store");
        }
    }
}