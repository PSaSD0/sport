namespace sport.Models.Catalog
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoUrl { get; set; }

        public ICollection<Product> Products { get; set; } = new();
    }
}
