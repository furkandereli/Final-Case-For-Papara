using FinalCaseForPapara.Business.Response;
using FinalCaseForPapara.Dto.OrderDTOs;

namespace FinalCaseForPapara.Business.Services.OrderServices
{
    public interface IOrderService
    {
        Task<ApiResponse<OrderDto>> CreateOrderAsync(CreateOrderDto createOrderDto);
        Task<ApiResponse<List<OrderDto>>> GetActiveOrdersAsync();
        Task<ApiResponse<List<OrderDto>>> GetPastOrdersAsync();
        Task<ApiResponse<object>> GetUserPointsAsync();
    }
}
