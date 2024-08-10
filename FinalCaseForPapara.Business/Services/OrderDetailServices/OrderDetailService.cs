using AutoMapper;
using FinalCaseForPapara.DataAccess.UnitOfWork;
using FinalCaseForPapara.Dto.OrderDetailDTOs;
using FinalCaseForPapara.Entity.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FinalCaseForPapara.Business.Services.OrderDetailServices
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderDetailService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<OrderDetailDto>> GetOrderDetailsAsync()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                throw new UnauthorizedAccessException("Lütfen giriş yapın.");

            var isAdmin = _httpContextAccessor.HttpContext.User.IsInRole("Admin");

            List<OrderDetail> orderDetails;

            if (isAdmin)
                orderDetails = await _unitOfWork.OrderDetailRepository.GetAllAsync(null, od => od.Product, od => od.Order);
            else
                orderDetails = await _unitOfWork.OrderDetailRepository.GetAllAsync(od => od.Order.UserId == int.Parse(userId), od => od.Product, od => od.Order);

            return _mapper.Map<List<OrderDetailDto>>(orderDetails);
        }
    }
}
