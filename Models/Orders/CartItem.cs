using sport.Models.Catalog;
using sport.Models.Users;

namespace sport.Models.Orders
{
    public class CartItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
    }
}
