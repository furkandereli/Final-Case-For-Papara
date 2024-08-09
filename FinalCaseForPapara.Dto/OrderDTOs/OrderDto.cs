using FinalCaseForPapara.Dto.OrderDetailDTOs;

namespace FinalCaseForPapara.Dto.OrderDTOs
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal? CouponAmount { get; set; }
        public string? CouponCode { get; set; }
        public decimal PointsUsed { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsActive { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }
    }
}
