using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using sport.Domain.Enums;

namespace sport.Domain.Entities
{
    public class Order : EntityBase // Наследуемся от EntityBase
    {
        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public OrderStatusEnum Status { get; set; } = OrderStatusEnum.New;
        public decimal TotalAmount { get; set; }
        public string? Address { get; set; }

        // Связь один-ко-многим (в одном заказе много позиций)
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}