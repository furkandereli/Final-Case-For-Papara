using FinalCaseForPapara.Dto.OrderDTOs;

namespace FinalCaseForPapara.Business.Services.OrderServices
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrderDto);
        //Task<List<OrderDto>> GetActiveOrdersAsync(string userId);
        //Task<List<OrderDto>> GetPastOrdersAsync(string userId);
        //Task<OrderDto> GetOrderByIdAsync(int orderId);
        //Task<decimal> GetUserPointsAsync(string userId);
    }
}
