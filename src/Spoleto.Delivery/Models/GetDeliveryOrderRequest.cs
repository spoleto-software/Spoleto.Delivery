namespace Spoleto.Delivery
{
    /// <summary>
    /// The delivery order request to get.
    /// </summary>
    public record GetDeliveryOrderRequest
    {
        /// <summary>
        /// Получает или задает идентификатор заказа в ИС конкретного провайдера (Сдэк, МастерПост).
        /// </summary>
        public Guid? Uuid { get; set; }

        /// <summary>
        /// Номер заказа в ИС конкретного провайдера (Сдэк, МастерПост).
        /// </summary>
        public string? Number { get; set; }

        /// <summary>
        /// Номер заказа в ИС Клиента.
        /// </summary>
        public string? CisNumber { get; set; }
    }
}
