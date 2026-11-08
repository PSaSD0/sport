using sport.Models.Catalog;

namespace sport.Models.Users
{
    public class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int? ProductId { get; set; }     
        public Product Product { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }     
        public bool IsApproved { get; set; }    
        public DateTime CreatedAt { get; set; }
    }
}
