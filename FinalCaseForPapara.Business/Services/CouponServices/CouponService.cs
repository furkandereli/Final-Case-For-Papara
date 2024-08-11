using AutoMapper;
using FinalCaseForPapara.Business.Response;
using FinalCaseForPapara.DataAccess.UnitOfWork;
using FinalCaseForPapara.Dto.CouponDTOs;
using FinalCaseForPapara.Entity.Entities;

namespace FinalCaseForPapara.Business.Services.CouponServices
{
    public class CouponService : ICouponService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CouponService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<string>> CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            var coupon = _mapper.Map<Coupon>(createCouponDto);
            coupon.IsActive = true;
            await _unitOfWork.CouponRepository.CreateAsync(coupon);
            await _unitOfWork.CompleteAsync();
            return new ApiResponse<string>("Coupon created successfully !", true);
        }

        public async Task<ApiResponse<string>> DeleteCouponAsync(int id)
        {
            var coupon = await _unitOfWork.CouponRepository.GetByIdAsync(id);

            if (coupon == null)
                return new ApiResponse<string>("Coupon not found !", false);

            await _unitOfWork.CouponRepository.DeleteAsync(coupon);
            await _unitOfWork.CompleteAsync();
            return new ApiResponse<string>("Coupon deleted successfully !", true);
        }

        public async Task<ApiResponse<List<CouponDto>>> GetAllAsync()
        {
            var coupons = await _unitOfWork.CouponRepository.GetAllAsync();
            var couponDtos = _mapper.Map<List<CouponDto>>(coupons);
            return new ApiResponse<List<CouponDto>>(couponDtos, "Coupons displayed successfully !");
        }

        public async Task<ApiResponse<CouponDto>> GetCouponById(int id)
        {
            var coupon = await _unitOfWork.CouponRepository.GetByIdAsync(id);
            var couponDto =  _mapper.Map<CouponDto>(coupon);
            return new ApiResponse<CouponDto>(couponDto, "Coupon displayed successfully !");
        }

        public async Task<ApiResponse<string>> ToggleCouponActivity(int id)
        {
            var coupon = await _unitOfWork.CouponRepository.GetByIdAsync(id);

            if (coupon == null)
                return new ApiResponse<string>("Coupon not found !", false);

            coupon.IsActive = !coupon.IsActive;
            await _unitOfWork.CouponRepository.UpdateAsync(coupon);
            await _unitOfWork.CompleteAsync();
            return new ApiResponse<string>("Coupon toggled successfully !", true);
        }

        public async Task<ApiResponse<string>> UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            var coupon = await _unitOfWork.CouponRepository.GetByIdAsync(updateCouponDto.Id);

            if (coupon == null)
                return new ApiResponse<string>("Coupon not found !", false);

            _mapper.Map(updateCouponDto, coupon);
            await _unitOfWork.CouponRepository.UpdateAsync(coupon);
            await _unitOfWork.CompleteAsync();
            return new ApiResponse<string>("Coupon updated successfully !", true);
        }
    }
}
