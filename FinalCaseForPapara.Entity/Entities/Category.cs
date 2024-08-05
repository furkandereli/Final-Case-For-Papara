namespace FinalCaseForPapara.Entity.Entities
{
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Tags { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}
