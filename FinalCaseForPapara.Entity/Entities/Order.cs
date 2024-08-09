using System.ComponentModel.DataAnnotations;

namespace FinalCaseForPapara.Entity.Entities
{
    public class Order
    {
        public int Id { get; set; }
        [MaxLength(9)]
        public string OrderNumber { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal? CouponAmount { get; set; }
        public string? CouponCode { get; set; }
        public decimal? PointsUsed { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsActive { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
