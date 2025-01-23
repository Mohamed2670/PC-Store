using Microsoft.AspNetCore.Mvc;
using ServerSide.Dto.ProductDtos;
using ServerSide.Model;
using ServerSide.Service;

namespace ServerSide.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController(ProductService _productService) : ControllerBase
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            return product != null ? Ok(product) : NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductAddDto productAddDto)
        {
            var product = await _productService.AddProduct(productAddDto);
            return product != null ? Ok(product) : BadRequest("Can't add this product");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductUpdateDto productUpdateDto)
        {
            var product = await _productService.UpdateProduct(id, productUpdateDto);
            return product != null ? Ok(product) : NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productService.DeleteProductById(id);
            return product != null ? Ok(product) : NotFound();
        }

    }
}