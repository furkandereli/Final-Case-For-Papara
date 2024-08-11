using FinalCaseForPapara.Business.Response;
using FinalCaseForPapara.Dto.OrderDetailDTOs;

namespace FinalCaseForPapara.Business.Services.OrderDetailServices
{
    public interface IOrderDetailService
    {
        Task<ApiResponse<List<OrderDetailDto>>> GetOrderDetailsAsync();
    }
}
