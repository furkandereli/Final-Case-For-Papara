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
            var response = await _productService.GetAllAsync();

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var response = await _productService.GetProductByIdAsync(id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            var response = await _productService.CreateProductAsync(createProductDto);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var response = await _productService.DeleteProductAsync(id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var response = await _productService.UpdateProductAsync(updateProductDto);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("ToggleStock/{id}")]
        public async Task<IActionResult> ToggleStockStatus(int id)
        {
            var response = await _productService.ToggleStockStatusAsync(id);
            
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("ToggleActive/{id}")]
        public async Task<IActionResult> ToggleActiveStatus(int id)
        {
            var response = await _productService.ToggleActiveStatusAsync(id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
