using System.ComponentModel.DataAnnotations;

namespace sport.Domain.Entities
{
    public class Category : EntityBase
    {
        // В EntityBase уже есть Id, Title, DateCreated
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}