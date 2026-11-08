namespace sport.Models.Catalog
{
    public class ProductSize
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Size { get; set; }  // "S", "M", "L"
    }
}
