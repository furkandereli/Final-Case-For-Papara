namespace FinalCaseForPapara.Dto.ProductDTOs
{
    public class ProductDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int PointsPercentage { get; set; }
        public int MaxPoints { get; set; }
        public bool Stock { get; set; }
        public bool IsActive { get; set; }
    }
}
