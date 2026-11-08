namespace sport.Domain.Entities
{
    public class Promotion : EntityBase
    {
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public DateTime? ValidUntil { get; set; } // До какой даты действует
    }
}