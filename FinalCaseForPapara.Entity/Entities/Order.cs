namespace FinalCaseForPapara.Entity.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public User User { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal CouponAmount { get; set; }
        public string CouponCode { get; set; }
        public decimal PointsUsed { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
