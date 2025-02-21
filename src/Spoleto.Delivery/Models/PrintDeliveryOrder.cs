namespace Spoleto.Delivery
{
    /// <summary>
    /// The delivery order number.
    /// </summary>
    public record PrintDeliveryOrder
    {
        /// <summary>
        /// Получает или задает идентификатор заказа в ИС конкретного провайдера (Сдэк, МастерПост).
        /// </summary>
        public Guid? Uuid { get; set; }

        /// <summary>
        /// Номер заказа в ИС конкретного провайдера (Сдэк, МастерПост).
        /// </summary>
        public string? Number { get; set; }
    }
}
