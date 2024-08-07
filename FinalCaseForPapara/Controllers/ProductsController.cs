using FinalCaseForPapara.Business.Services.ProductServices;
using FinalCaseForPapara.Dto.ProductDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalCaseForPapara.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GettAllProducts()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return Ok("Product created successfully !");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok("Product deleted successfully !");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return Ok("Product updated successfully !");
        }

        [HttpPut("ToggleStock/{id}")]
        public async Task<IActionResult> ToggleStockStatus(int id)
        {
            await _productService.ToggleStockStatusAsync(id);
            return Ok("Product stock status toggled successfully !");
        }

        [HttpPut("ToggleActive/{id}")]
        public async Task<IActionResult> ToggleActiveStatus(int id)
        {
            await _productService.ToggleActiveStatusAsync(id);
            return Ok("Product active status toggled successfully !");
        }
    }
}
