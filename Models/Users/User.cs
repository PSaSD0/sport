using sport.Models.Orders;

namespace sport.Models.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; } 
        public DateTime CreatedAt { get; set; }

        public ICollection<Order> Orders { get; set; } = new();
        public ICollection<Review> Reviews { get; set; } = new();
    }
}
