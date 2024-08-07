using FinalCaseForPapara.Dto.ProductDTOs;

namespace FinalCaseForPapara.Business.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto> GetProductByIdAsync(int id);
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task DeleteProductAsync(int id);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task ToggleStockStatusAsync(int id);
        Task ToggleActiveStatusAsync(int id);
    }
}
