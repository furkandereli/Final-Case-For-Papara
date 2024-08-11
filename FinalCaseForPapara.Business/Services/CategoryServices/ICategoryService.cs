using FinalCaseForPapara.Business.Response;
using FinalCaseForPapara.Dto.CategoryDTOs;
using FinalCaseForPapara.Dto.ProductDTOs;

namespace FinalCaseForPapara.Business.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<ApiResponse<List<CategoryDto>>> GetAllAsync();
        Task<ApiResponse<CategoryDto>> GetCategoryByIdAsync(int id);
        Task<ApiResponse<string>> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task<ApiResponse<string>> DeleteCategoryAsync(int id);
        Task<ApiResponse<string>> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task<ApiResponse<List<ProductDto>>> GetProductsByCategoryAsync(int id);
    }
}
