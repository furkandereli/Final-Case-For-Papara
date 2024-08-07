using FinalCaseForPapara.Dto.CategoryDTOs;
using FinalCaseForPapara.Dto.ProductDTOs;

namespace FinalCaseForPapara.Business.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task DeleteCategoryAsync(int id);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task<List<ProductDto>> GetProductsByCategoryAsync(int id);
    }
}
