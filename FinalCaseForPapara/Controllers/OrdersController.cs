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
            var response = await _orderService.GetUserPointsAsync();

            if(response.Data is decimal userPoints)
                return Ok(new { Points = userPoints });
            
            else if(response.Data is List<UserPointsDto> userPointsList)
                return Ok(userPointsList);

            return BadRequest(response.Message);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto createOrderDto)
        {
            var response = await _orderService.CreateOrderAsync(createOrderDto);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("ActiveOrders")]
        public async Task<IActionResult> GetActiveOrders()
        {
            var response = await _orderService.GetActiveOrdersAsync();

            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpGet("PastOrders")]
        public async Task<IActionResult> GetPastOrders()
        {
            var response = await _orderService.GetPastOrdersAsync();

            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("ToggleOrderActivity/{id}")]
        public async Task<IActionResult> ToggleOrderActivity(int id)
        {
            var response = await _orderService.ToggleOrderActivityAsync(id);

            if(!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
