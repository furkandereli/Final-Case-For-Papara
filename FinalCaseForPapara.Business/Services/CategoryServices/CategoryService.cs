using AutoMapper;
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

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);
            await _unitOfWork.CategoryRepository.CreateAsync(category);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);           
            if (category == null)
                throw new KeyNotFoundException("Category not found !");

            var hasProducts = await _unitOfWork.ProductCategoryRepository.AnyAsync(pc => pc.CategoryId == id);
            if(hasProducts)
                throw new InvalidOperationException("Cannot delete category because it has associated products.");

            _unitOfWork.CategoryRepository.DeleteAsync(category);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var categories = await _unitOfWork.CategoryRepository.GetAllAsync();
            return _mapper.Map<List<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            
            if(category == null)
                throw new KeyNotFoundException("Category not found !");

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<List<ProductDto>> GetProductsByCategoryAsync(int id)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (category == null)
                throw new KeyNotFoundException("Category not found");

            var productCategories = await _unitOfWork.ProductCategoryRepository
                .GetAllAsync(pc => pc.CategoryId == id);

            var productIds = productCategories.Select(pc => pc.ProductId).ToList();
            var products = await _unitOfWork.ProductRepository
                .GetAllAsync(p => productIds.Contains(p.Id));

            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(updateCategoryDto.Id);

            if(category == null)
                throw new KeyNotFoundException("Category not found !");

            _mapper.Map(updateCategoryDto, category);
            _unitOfWork.CategoryRepository.UpdateAsync(category);
            await _unitOfWork.CompleteAsync();
        }
    }
}
