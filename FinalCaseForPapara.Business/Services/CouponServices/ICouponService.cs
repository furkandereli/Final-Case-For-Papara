using FinalCaseForPapara.Dto.CouponDTOs;

namespace FinalCaseForPapara.Business.Services.CouponServices
{
    public interface ICouponService
    {
        Task<List<CouponDto>> GetAllAsync();
        Task<CouponDto> GetCouponById(int id);
        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task DeleteCouponAsync(int id);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task ToggleCouponActivity(int id);
    }
}
