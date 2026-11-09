using System.ComponentModel.DataAnnotations;

namespace sport.Models
{
    public class ReviewViewModel
    {
        [Required(ErrorMessage = "Введите текст отзыва")]
        [Display(Name = "Ваш отзыв")]
        [MaxLength(1000, ErrorMessage = "Отзыв слишком длинный")]
        public string? Text { get; set; }

        [Required(ErrorMessage = "Поставьте оценку")]
        [Range(1, 5, ErrorMessage = "Оценка должна быть от 1 до 5")]
        [Display(Name = "Оценка (1-5)")]
        public int Rating { get; set; } = 5; // По умолчанию 5 звезд
    }
}