using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServerSide.Authentication;
using ServerSide.Dto.ProductDtos;
using ServerSide.Model;
using ServerSide.Service;

namespace ServerSide.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController(ProductService _productService, UserAccessToken userAccessToken) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllProductsByPage([FromQuery] int page = 1, [FromQuery] int size = 20)
        {
            var products = await _productService.GetAllProducts(page, size);
            return products != null ? Ok(products) : NotFound();
        }
        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategoryId(int categoryId, [FromQuery] int page = 1, [FromQuery] int size = 20)
        {
            var products = await _productService.GetProductsByCategoryId(categoryId, page, size);
            return products != null ? Ok(products) : NotFound();
        }

        [HttpGet("store/{storeId}")]
        public async Task<IActionResult> GetProductsByStoreName(int storeId, [FromQuery] int page = 1, [FromQuery] int size = 20)
        {
            var products = await _productService.GetProductsByStoreId(storeId, page, size);
            return products != null ? Ok(products) : NotFound();
        }
        [HttpGet("search")]
        public async Task<IActionResult> GetProductsByProductName([FromQuery] string productName, [FromQuery] int page = 1, [FromQuery] int size = 20)
        {
            var products = await _productService.GetProductsByProductName(productName, page, size);
            return products != null ? Ok(products) : NotFound();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            return product != null ? Ok(product) : NotFound();
        }
        [HttpPost]
        [Authorize(Policy = "StoreOwner")]
        public async Task<IActionResult> AddProduct(ProductAddDto productAddDto)
        {
            if (!userAccessToken.IsAuthenticated(productAddDto.StoreId))
            {
                return Forbid();
            }
            var product = await _productService.AddProduct(productAddDto);
            return product != null ? Ok(product) : BadRequest("Can't add this product");
        }
        [HttpPut("{id}")]
        [Authorize(Policy = "StoreOwner")]
        public async Task<IActionResult> UpdateProduct(int id, ProductUpdateDto productUpdateDto)
        {
            var productReadDto = await _productService.GetProductById(id);
            if (productReadDto == null || !userAccessToken.IsAuthenticated(productReadDto.StoreId))
            {
                return Forbid();
            }
            var product = await _productService.UpdateProduct(id, productUpdateDto);
            return product != null ? Ok(product) : NotFound();
        }
        [HttpDelete("{id}")]
        [Authorize(Policy = "StoreOwner")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var productReadDto = await _productService.GetProductById(id);
            if (productReadDto == null || !userAccessToken.IsAuthenticated(productReadDto.StoreId))
            {
                return Forbid();
            }
            var product = await _productService.DeleteProductById(id);
            return product != null ? Ok(product) : NotFound();
        }

    }
}