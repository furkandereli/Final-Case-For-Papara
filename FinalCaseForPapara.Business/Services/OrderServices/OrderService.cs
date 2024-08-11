using AutoMapper;
using FinalCaseForPapara.Business.Helpers;
using FinalCaseForPapara.Business.Response;
using FinalCaseForPapara.DataAccess.Repositories.OrderRepositories;
using FinalCaseForPapara.DataAccess.UnitOfWork;
using FinalCaseForPapara.Dto.OrderDTOs;
using FinalCaseForPapara.Dto.UserDTOs;
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
        private readonly IOrderRepository _orderRepository;

        public OrderService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            OrderHelper orderHelper,
            IOrderRepository orderRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _orderHelper = new OrderHelper(unitOfWork);
            _orderRepository = orderRepository;
        }

        private string GetUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                throw new UnauthorizedAccessException("Lütfen giriş yapın.");
            return userId;
        }

        private bool IsAdmin()
        {
            return _httpContextAccessor.HttpContext.User.IsInRole("Admin");
        }

        public async Task<ApiResponse<OrderDto>> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            var userId = GetUserId();

            var products = await _orderHelper.ValidateAndGetProductsAsync(createOrderDto.Items);

            var coupon = await _orderHelper.ValidateAndApplyCouponAsync(createOrderDto.CouponCode, userId);

            var user = await _unitOfWork.UserRepository.GetByIdAsync(int.Parse(userId));
            var pointsUsed = user.PointsBalance;

            var totalAmount = _orderHelper.CalculateOrderAmount(products, createOrderDto.Items, pointsUsed, coupon);

            var earnedPoints = _orderHelper.CalculateTotalPointsEarned(products, createOrderDto.Items);

            var order = await _orderHelper.CreateOrderAsync(user.Id, totalAmount, pointsUsed, coupon?.DiscountAmount, createOrderDto.CouponCode, createOrderDto.Items, products);

            await _unitOfWork.OrderRepository.CreateAsync(order);

            user.PointsBalance = earnedPoints;
            await _unitOfWork.UserRepository.UpdateAsync(user);

            await _unitOfWork.CompleteAsync();

            var orderDto = _mapper.Map<OrderDto>(order);
            return new ApiResponse<OrderDto>(orderDto, "Order created successfully !");
        }

        public async Task<ApiResponse<List<OrderDto>>> GetActiveOrdersAsync()
        {
            var userId = GetUserId();
            var isAdmin = IsAdmin();

            var orders = await _orderRepository.GetActiveOrdersAsync(int.Parse(userId), isAdmin);
            var orderDto = _mapper.Map<List<OrderDto>>(orders);
            return new ApiResponse<List<OrderDto>>(orderDto, "Active orders displayed successfully !");
        }

        public async Task<ApiResponse<List<OrderDto>>> GetPastOrdersAsync()
        {
            var userId = GetUserId();
            var isAdmin = IsAdmin();

            var orders = await _orderRepository.GetPastOrdersAsync(int.Parse(userId), isAdmin);
            var orderDto = _mapper.Map<List<OrderDto>>(orders);
            return new ApiResponse<List<OrderDto>>(orderDto, "Past orders displayed successfully !");
        }

        public async Task<ApiResponse<object>> GetUserPointsAsync()
        {
            var userId = GetUserId();
            var isAdmin = IsAdmin();

            if (isAdmin)
            {
                var allUsers = await _unitOfWork.UserRepository.GetAllAsync();
                var userPoints = allUsers.Select(u => new UserPointsDto
                {
                    UserId = u.Id,
                    UserName = $"{u.FirstName} {u.LastName}",
                    PointsBalance = u.PointsBalance
                }).ToList();

                return new ApiResponse<object>(userPoints, "All users' points displayed successfully !");
            }
            else
            {
                var user = await _unitOfWork.UserRepository.GetByIdAsync(int.Parse(userId));
                return new ApiResponse<object>(user.PointsBalance, "User points displayed successfully !");
            }
        }
    }
}
