namespace FinalCaseForPapara.Dto.OrderDTOs
{
    public class CreateOrderDto
    {
        public List<OrderItemDto> Items { get; set; }
        public string? CouponCode { get; set; }
        public string CreditCardNumber { get; set; }
    }
}
