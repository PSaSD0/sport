namespace sport.Domain.Enums
{
    public enum OrderStatusEnum
    {
        New = 0,        // Новый
        Processing = 1, // В обработке (менеджером)
        Shipped = 2,    // Отправлен
        Delivered = 3,  // Доставлен
        Cancelled = 4   // Отменен
    }
}