namespace FinalCaseForPapara.Dto.CouponDTOs
{
    public class CreateCouponDto
    {
        public string Code { get; set; }
        public int DiscountAmount { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
