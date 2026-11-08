namespace sport.Domain.Entities
{
    public class Brand : EntityBase
    {
        public string? Description { get; set; }
        public string? LogoPath { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}