using FinalCaseForPapara.Business.Response;
using FinalCaseForPapara.Dto.ProductDTOs;

namespace FinalCaseForPapara.Business.Services.ProductServices
{
    public interface IProductService
    {
        Task<ApiResponse<List<ProductDto>>> GetAllAsync();
        Task<ApiResponse<ProductDto>> GetProductByIdAsync(int id);
        Task<ApiResponse<string>> CreateProductAsync(CreateProductDto createProductDto);
        Task<ApiResponse<string>> DeleteProductAsync(int id);
        Task<ApiResponse<string>> UpdateProductAsync(UpdateProductDto updateProductDto);
        Task<ApiResponse<string>> ToggleStockStatusAsync(int id);
        Task<ApiResponse<string>> ToggleActiveStatusAsync(int id);
    }
}
