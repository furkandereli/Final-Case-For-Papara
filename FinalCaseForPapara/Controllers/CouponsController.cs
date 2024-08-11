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
            var response = await _couponService.GetAllAsync();

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCouponById(int id)
        {
            var response = await _couponService.GetCouponById(id);

            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CreateCouponDto createCouponDto)
        {
            var response = await _couponService.CreateCouponAsync(createCouponDto);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ToggleCouponActivity(int id)
        {
            var response = await _couponService.ToggleCouponActivity(id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
            var response = await _couponService.DeleteCouponAsync(id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCouponDto)
        {
            var response = await _couponService.UpdateCouponAsync(updateCouponDto);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
