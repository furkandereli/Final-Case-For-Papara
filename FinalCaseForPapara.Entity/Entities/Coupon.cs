namespace FinalCaseForPapara.Entity.Entities
{
    public class Coupon
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public int Amount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
    }
}
