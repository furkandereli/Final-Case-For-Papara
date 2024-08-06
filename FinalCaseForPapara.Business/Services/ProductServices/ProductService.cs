using AutoMapper;
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

        public async Task CreateProductAsync(CreateProductDto createProductDto)
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

            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteProductAsync(string id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            
            if (product == null)
                throw new KeyNotFoundException("Product not found !");

            _unitOfWork.ProductRepository.DeleteAsync(product);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var products = await _unitOfWork.ProductRepository.GetProductsWithCategoriesAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductByIdAsync(string id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);

            if (product == null)
                throw new KeyNotFoundException("Product not found !");

            return _mapper.Map<ProductDto>(product);
        }

        public async Task ToggleActiveStatusAsync(string id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);

            if(product != null)
            {
                product.IsActive = !product.IsActive;
                await _unitOfWork.ProductRepository.UpdateAsync(product);
                await _unitOfWork.CompleteAsync();
            }

            throw new KeyNotFoundException("Product not found !");
        }

        public async Task ToggleStockStatusAsync(string id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);

            if (product != null)
            {
                product.Stock = !product.Stock;
                await _unitOfWork.ProductRepository.UpdateAsync(product);
                await _unitOfWork.CompleteAsync();
            }

            throw new KeyNotFoundException("Product not found !");
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(updateProductDto.Id);

            if (product == null)
                throw new KeyNotFoundException("Product not found !");

            _mapper.Map(updateProductDto, product);
            _unitOfWork.ProductRepository.UpdateAsync(product);
            await _unitOfWork.CompleteAsync();
        }
    }
}
