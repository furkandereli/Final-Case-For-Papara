using FinalCaseForPapara.Dto.OrderDTOs;

namespace FinalCaseForPapara.Business.Services.OrderServices
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrderDto);
        Task<List<OrderDto>> GetActiveOrdersAsync();
        Task<List<OrderDto>> GetPastOrdersAsync();
        Task<object> GetUserPointsAsync();
    }
}
