using FinalCaseForPapara.Dto.ProductDTOs;

namespace FinalCaseForPapara.Business.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto> GetProductByIdAsync(string id);
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task DeleteProductAsync(string id);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
    }
}
