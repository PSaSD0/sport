using sport.Domain.Entities;
using sport.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace sport.Domain.Entities
{
    public class Product : EntityBase
    {
        [Display(Name = "Краткое описание")]
        [MaxLength(3000)]
        public string? ShortDescription { get; set; }

        [Display(Name = "Полное описание")]
        public string? Description { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Титульная картинка")]
        public string? Photo { get; set; }

        [Display(Name = "Размер")]
        public SizeEnum Size { get; set; }

        [Display(Name = "Новинка?")]
        public bool IsNew { get; set; } 

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public int? BrandId { get; set; }
        public Brand? Brand { get; set; }
    }
}