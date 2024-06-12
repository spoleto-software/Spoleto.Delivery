namespace Spoleto.Delivery
{
    /// <summary>
    /// The delivery order.
    /// </summary>
    public record DeliveryOrder
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
        public string? CisNumber { get;set; }

        /// <summary>
        /// Текущий статус.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Получает или задает ошибки, возникшие в ходе выполнения запроса.
        /// </summary>
        public List<Error>? Errors { get; set; }

        /// <summary>
        /// Получает или задает предупреждения, возникшие в ходе выполнения запроса.
        /// </summary>
        public List<Warning>? Warnings { get; set; }

        /// <summary>
        /// Получает или задает связанные сущности для заказа.
        /// </summary>
        public List<DeliveryOrderRelatedEntity>? RelatedEntities { get; set; }
    }
}
