namespace FinalCaseForPapara.Entity.Entities
{
    public class Coupon
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Amount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
    }
}
