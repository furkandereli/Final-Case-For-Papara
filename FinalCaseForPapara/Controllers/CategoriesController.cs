using Azure;
using FinalCaseForPapara.Business.Services.CategoryServices;
using FinalCaseForPapara.Dto.CategoryDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalCaseForPapara.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var response = await _categoryService.GetAllAsync();
            
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var response = await _categoryService.GetCategoryByIdAsync(id);

            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpGet("Products/{id}")]
        public async Task<IActionResult> GetProductsByCategoryId(int id)
        {
            var response = await _categoryService.GetProductsByCategoryAsync(id);

            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var response = await _categoryService.CreateCategoryAsync(createCategoryDto);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var response = await _categoryService.DeleteCategoryAsync(id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var response = await _categoryService.UpdateCategoryAsync(updateCategoryDto);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
