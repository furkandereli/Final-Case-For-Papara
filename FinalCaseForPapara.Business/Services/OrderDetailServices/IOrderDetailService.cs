using FinalCaseForPapara.Dto.OrderDetailDTOs;

namespace FinalCaseForPapara.Business.Services.OrderDetailServices
{
    public interface IOrderDetailService
    {
        Task<List<OrderDetailDto>> GetOrderDetailsAsync();
    }
}
