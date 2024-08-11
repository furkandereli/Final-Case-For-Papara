using FinalCaseForPapara.Business.Services.OrderDetailServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalCaseForPapara.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailsController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderDetails()
        {
            var response = await _orderDetailService.GetOrderDetailsAsync();

            if(!response.Success)
                return NotFound(response);

            return Ok(response);
        }
    }
}
