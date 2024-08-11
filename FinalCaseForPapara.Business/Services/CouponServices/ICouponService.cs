using FinalCaseForPapara.Business.Response;
using FinalCaseForPapara.Dto.CouponDTOs;

namespace FinalCaseForPapara.Business.Services.CouponServices
{
    public interface ICouponService
    {
        Task<ApiResponse<List<CouponDto>>> GetAllAsync();
        Task<ApiResponse<CouponDto>> GetCouponById(int id);
        Task<ApiResponse<string>> CreateCouponAsync(CreateCouponDto createCouponDto);
        Task<ApiResponse<string>> DeleteCouponAsync(int id);
        Task<ApiResponse<string>> UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task<ApiResponse<string>> ToggleCouponActivity(int id);
    }
}
