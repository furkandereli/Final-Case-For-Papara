using AutoMapper;
using FinalCaseForPapara.Dto.ProductDTOs;
using FinalCaseForPapara.Entity.Entities;

namespace FinalCaseForPapara.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
        }
    }
}
