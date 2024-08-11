using AutoMapper;
using FinalCaseForPapara.Business.Response;
using FinalCaseForPapara.DataAccess.UnitOfWork;
using FinalCaseForPapara.Dto.ProductDTOs;
using FinalCaseForPapara.Entity.Entities;

namespace FinalCaseForPapara.Business.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<string>> CreateProductAsync(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);

            if(createProductDto.CategoryIds != null && createProductDto.CategoryIds.Any())
            {
                product.ProductCategories = new List<ProductCategory>();
                foreach(var categoryId in createProductDto.CategoryIds)
                {
                    product.ProductCategories.Add(new ProductCategory() { CategoryId = categoryId });
                }
            }

            await _unitOfWork.ProductRepository.CreateAsync(product);
            await _unitOfWork.CompleteAsync();
            return new ApiResponse<string>("Product created successfully !", true);
        }

        public async Task<ApiResponse<string>> DeleteProductAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            
            if (product == null)
                return new ApiResponse<string>("Product not found !", false);

            _unitOfWork.ProductRepository.DeleteAsync(product);
            await _unitOfWork.CompleteAsync();
            return new ApiResponse<string>("Product deleted successfully !", true);
        }

        public async Task<ApiResponse<List<ProductDto>>> GetAllAsync()
        {
            var products = await _unitOfWork.ProductRepository.GetProductsWithCategoriesAsync();
            var productDtos = _mapper.Map<List<ProductDto>>(products);
            return new ApiResponse<List<ProductDto>>(productDtos, "Products displayed successfully !");
        }

        public async Task<ApiResponse<ProductDto>> GetProductByIdAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetProductsByIdWithCategoriesAsync(id);

            if (product == null)
                return new ApiResponse<ProductDto>("Product not found !", false);

            var productDto = _mapper.Map<ProductDto>(product);
            return new ApiResponse<ProductDto>(productDto, "Product displayed successfully !");
        }

        public async Task<ApiResponse<string>> ToggleActiveStatusAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);

            if(product != null)
            {
                product.IsActive = !product.IsActive;
                await _unitOfWork.ProductRepository.UpdateAsync(product);
                await _unitOfWork.CompleteAsync();
                return new ApiResponse<string>("Product activity toggled successfully !", true);
            }

            return new ApiResponse<string>("Product not found !", false);
        }

        public async Task<ApiResponse<string>> ToggleStockStatusAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);

            if (product != null)
            {
                product.Stock = !product.Stock;
                await _unitOfWork.ProductRepository.UpdateAsync(product);
                await _unitOfWork.CompleteAsync();
                return new ApiResponse<string>("Product stock toggled successfully !", true);
            }

            return new ApiResponse<string>("Product not found !", false);
        }

        public async Task<ApiResponse<string>> UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(updateProductDto.Id);

            if (product == null)
                return new ApiResponse<string>("Product not found !", false);

            _mapper.Map(updateProductDto, product);
            await _unitOfWork.ProductRepository.UpdateAsync(product);
            await _unitOfWork.CompleteAsync();
            return new ApiResponse<string>("Product updated successfully !", true);
        }
    }
}
