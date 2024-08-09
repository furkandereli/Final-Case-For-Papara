using AutoMapper;
using FinalCaseForPapara.Business.Helpers;
using FinalCaseForPapara.DataAccess.UnitOfWork;
using FinalCaseForPapara.Dto.OrderDTOs;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FinalCaseForPapara.Business.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly OrderHelper _orderHelper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, OrderHelper orderHelper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _orderHelper = new OrderHelper(unitOfWork);
        }

        public async Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                throw new UnauthorizedAccessException("Please log in");

            var products = await _orderHelper.ValidateAndGetProductsAsync(createOrderDto.Items);

            var coupon = await _orderHelper.ValidateAndApplyCouponAsync(createOrderDto.CouponCode, userId);

            var user = await _unitOfWork.UserRepository.GetByIdAsync(int.Parse(userId));
            var pointsUsed = user.PointsBalance;

            var totalAmount = _orderHelper.CalculateOrderAmount(products, createOrderDto.Items, pointsUsed, coupon);

            var order = _orderHelper.CreateOrder(user.Id,totalAmount, pointsUsed, coupon?.DiscountAmount, createOrderDto.CouponCode, createOrderDto.Items, products);

            await _unitOfWork.OrderRepository.CreateAsync(order);

            user.PointsBalance = 0;
            await _unitOfWork.UserRepository.UpdateAsync(user);

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<OrderDto>(order);
        }    
        
    }
}
