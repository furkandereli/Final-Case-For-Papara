using FinalCaseForPapara.Business.Services.CouponServices;
using FinalCaseForPapara.Dto.CouponDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalCaseForPapara.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CouponsController : ControllerBase
    {
        private readonly ICouponService _couponService;

        public CouponsController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCoupons()
        {
            var coupons = await _couponService.GetAllAsync();
            return Ok(coupons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCouponById(int id)
        {
            var coupon = await _couponService.GetCouponById(id);
            return Ok(coupon);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CreateCouponDto createCouponDto)
        {
            await _couponService.CreateCouponAsync(createCouponDto);
            return Ok("Coupon created successfully !");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
            await _couponService.DeleteCouponAsync(id);
            return Ok("Coupon deleted successfully !");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCouponDto)
        {
            await _couponService.UpdateCouponAsync(updateCouponDto);
            return Ok("Coupon updated successfully !");
        }
    }
}
