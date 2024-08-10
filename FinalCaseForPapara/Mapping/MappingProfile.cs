using AutoMapper;
using FinalCaseForPapara.Dto.UserDTOs;
using FinalCaseForPapara.Dto.ProductDTOs;
using FinalCaseForPapara.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using FinalCaseForPapara.Dto.CategoryDTOs;
using FinalCaseForPapara.Dto.CouponDTOs;
using FinalCaseForPapara.Dto.OrderDTOs;
using FinalCaseForPapara.Dto.OrderDetailDTOs;

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

            CreateMap<Coupon, CouponDto>().ReverseMap();
            CreateMap<Coupon, CreateCouponDto>().ReverseMap();
            CreateMap<Coupon, UpdateCouponDto>().ReverseMap();

            CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));

            CreateMap<OrderDetail, OrderDetailDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Order.Id));

            CreateMap<CreateOrderDto, Order>()
                .ForMember(dest => dest.OrderNumber, opt => opt.Ignore())
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.Items.Select(item => new OrderDetail
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                }).ToList()));

            CreateMap<OrderItemDto, OrderDetail>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));
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
