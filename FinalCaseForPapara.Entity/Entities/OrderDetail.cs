namespace FinalCaseForPapara.Entity.Entities
{
    public class OrderDetail
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public Order Order { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public decimal Price { get; set; }
    }
}
