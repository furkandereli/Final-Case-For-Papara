using AutoMapper;
using FinalCaseForPapara.Business.Response;
using FinalCaseForPapara.DataAccess.UnitOfWork;
using FinalCaseForPapara.Dto.CategoryDTOs;
using FinalCaseForPapara.Dto.ProductDTOs;
using FinalCaseForPapara.Entity.Entities;

namespace FinalCaseForPapara.Business.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<string>> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);
            await _unitOfWork.CategoryRepository.CreateAsync(category);
            await _unitOfWork.CompleteAsync();
            return new ApiResponse<string>("Category created successfully !", true);
        }

        public async Task<ApiResponse<string>> DeleteCategoryAsync(int id)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (category == null)
                return new ApiResponse<string>("Category not found !", false);

            var hasProducts = await _unitOfWork.ProductCategoryRepository.AnyAsync(pc => pc.CategoryId == id);
            if(hasProducts)
                return new ApiResponse<string>("Cannot delete category because it has associated products !", false);

            _unitOfWork.CategoryRepository.DeleteAsync(category);
            await _unitOfWork.CompleteAsync();
            return new ApiResponse<string>("Category deleted successfully !", true);
        }

        public async Task<ApiResponse<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _unitOfWork.CategoryRepository.GetAllAsync();
            var categoryDtos = _mapper.Map<List<CategoryDto>>(categories);
            return new ApiResponse<List<CategoryDto>>(categoryDtos, "Categories displayed successfully !");
        }

        public async Task<ApiResponse<CategoryDto>> GetCategoryByIdAsync(int id)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            
            if(category == null)
                return new ApiResponse<CategoryDto>("Category not found !", false);

            var categoryDto = _mapper.Map<CategoryDto>(category);
            return new ApiResponse<CategoryDto>(categoryDto, "Category displayed successfully !");
        }

        public async Task<ApiResponse<List<ProductDto>>> GetProductsByCategoryAsync(int id)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (category == null)
                return new ApiResponse<List<ProductDto>>("Category not found !", false);

            var productCategories = await _unitOfWork.ProductCategoryRepository
                .GetAllAsync(pc => pc.CategoryId == id);

            var productIds = productCategories.Select(pc => pc.ProductId).ToList();
            var products = await _unitOfWork.ProductRepository
                .GetAllAsync(p => productIds.Contains(p.Id));

            var productDtos =  _mapper.Map<List<ProductDto>>(products);
            return new ApiResponse<List<ProductDto>>(productDtos, "Products displayed successfully !");
        }

        public async Task<ApiResponse<string>> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(updateCategoryDto.Id);

            if(category == null)
                return new ApiResponse<string>("Category not found !", false);

            _mapper.Map(updateCategoryDto, category);
            await _unitOfWork.CategoryRepository.UpdateAsync(category);
            await _unitOfWork.CompleteAsync();
            return new ApiResponse<string>("Category updated successfully !", true);
        }
    }
}
