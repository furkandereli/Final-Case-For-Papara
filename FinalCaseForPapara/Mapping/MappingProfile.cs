using AutoMapper;
using FinalCaseForPapara.Dto.UserDTOs;
using FinalCaseForPapara.Dto.ProductDTOs;
using FinalCaseForPapara.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using FinalCaseForPapara.Dto.CategoryDTOs;

namespace FinalCaseForPapara.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryNames, 
                opt => opt.MapFrom(src => src.ProductCategories.Select(pc => pc.Category.Name).ToList()));

            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();

            CreateMap<RegisterDto, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email)).ReverseMap();

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom<CustomRoleResolver>());

            CreateMap<User, UpdateUserDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        }
    }

    public class CustomRoleResolver : IValueResolver<User, UserDto, string>
    {
        private readonly UserManager<User> _userManager;

        public CustomRoleResolver(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public string Resolve(User source, UserDto destination, string destMember, ResolutionContext context)
        {
            var roles = _userManager.GetRolesAsync(source).Result;
            return roles.FirstOrDefault();
        }
    }
}
