using Microsoft.AspNetCore.Identity;
using sport.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace sport.Domain.Entities
{
    public class Review : EntityBase
    {
        [Required]
        public string? UserId { get; set; } // ID пользователя из Identity
        public IdentityUser? User { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [MaxLength(1000)]
        public string? Text { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; } // Оценка от 1 до 5

        public bool IsApproved { get; set; } // Для модерации админом
    }
}