using AutoMapper;
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

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            var coupon = _mapper.Map<Coupon>(createCouponDto);
            await _unitOfWork.CouponRepository.CreateAsync(coupon);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteCouponAsync(int id)
        {
            var coupon = await _unitOfWork.CouponRepository.GetByIdAsync(id);

            if (coupon == null)
                throw new KeyNotFoundException("Coupon not found !");

            await _unitOfWork.CouponRepository.DeleteAsync(coupon);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<List<CouponDto>> GetAllAsync()
        {
            var coupons = await _unitOfWork.CouponRepository.GetAllAsync();
            return _mapper.Map<List<CouponDto>>(coupons);
        }

        public async Task<CouponDto> GetCouponById(int id)
        {
            var coupon = await _unitOfWork.CouponRepository.GetByIdAsync(id);
            return _mapper.Map<CouponDto>(coupon);
        }

        public async Task ToggleCouponActivity(int id)
        {
            var coupon = await _unitOfWork.CouponRepository.GetByIdAsync(id);

            if (coupon == null)
                throw new KeyNotFoundException("Coupon not found !");

            coupon.IsActive = !coupon.IsActive;
            await _unitOfWork.CouponRepository.UpdateAsync(coupon);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            var coupon = await _unitOfWork.CouponRepository.GetByIdAsync(updateCouponDto.Id);

            if (coupon == null)
                throw new KeyNotFoundException("Coupon not found !");

            _mapper.Map(updateCouponDto, coupon);
            await _unitOfWork.CouponRepository.UpdateAsync(coupon);
            await _unitOfWork.CompleteAsync();
        }
    }
}
