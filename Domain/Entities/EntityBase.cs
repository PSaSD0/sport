using System;
using System.ComponentModel.DataAnnotations;

namespace sport.Domain.Entities // Убедитесь, что namespace совпадает с вашим проектом
{
    public abstract class EntityBase
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Заполните название")]
        [Display(Name = "Название")]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Дата создания")]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}