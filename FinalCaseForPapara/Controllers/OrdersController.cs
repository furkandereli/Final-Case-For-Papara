using FinalCaseForPapara.Business.Services.OrderServices;
using FinalCaseForPapara.Dto.OrderDTOs;
using FinalCaseForPapara.Dto.UserDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalCaseForPapara.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("PointsBalance")]
        public async Task<IActionResult> GetUserPoints()
        {
            var result = await _orderService.GetUserPointsAsync();

            if(result is decimal userPoints)
                return Ok(new { Points = userPoints });
            
            else if(result is List<UserPointsDto> userPointsList)
                return Ok(userPointsList);

            return BadRequest("Invalid request");
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto createOrderDto)
        {
            await _orderService.CreateOrderAsync(createOrderDto);
            return Ok("Order created successfully !");
        }

        [HttpGet("ActiveOrders")]
        public async Task<IActionResult> GetActiveOrders()
        {
            var activeOrders = await _orderService.GetActiveOrdersAsync();
            return Ok(activeOrders);
        }

        [HttpGet("PastOrders")]
        public async Task<IActionResult> GetPastOrders()
        {
            var pastOrders = await _orderService.GetPastOrdersAsync();
            return Ok(pastOrders);
        }
    }
}
