using AutoMapper;
using FinalCaseForPapara.Dto.AuthDTOs;
using FinalCaseForPapara.Dto.ProductDTOs;
using FinalCaseForPapara.Entity.Entities;

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
        }
    }
}
