using System.ComponentModel.DataAnnotations;

namespace FinalCaseForPapara.Dto.CouponDTOs
{
    public class CreateCouponDto
    {
        [StringLength(10, ErrorMessage = "Coupon code must be 10 characters or less !")]
        public string Code { get; set; }
        public int DiscountAmount { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
