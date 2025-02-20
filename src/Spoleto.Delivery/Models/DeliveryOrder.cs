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
        public string? CisNumber { get; set; }

        /// <summary>
        /// Текущий статус.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Флаг, что заказа на доставку был удалён.
        /// </summary>
        public bool IsRemoved { get; set; }

        /// <summary>
        /// Плановая дата доставки.
        /// </summary>
        public DateTime? PlannedDeliveryDate { get; set; }

        /// <summary>
        /// Дата доставки.
        /// </summary>
        public DateTime? DeliveryDate { get; set; }

        /// <summary>
        /// Ссылка для отслеживания заказа.
        /// </summary>
        public string TrackUrl { get; set; }

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

        /// <summary>
        /// Информация о заявке на вызов курьера на забор груза, если информация по вызову курьера была передана в момент создания заказа на доставку.
        /// </summary>
        public CourierPickup? CourierPickup { get; set; }

        /// <summary>
        /// Сумма страхования.
        /// </summary>
        public decimal? SumInsured { get; set; }

        /// <summary>
        /// Итоговая стоимость заказа (итого с НДС и со всеми дополнительными услугами).
        /// </summary>
        public decimal? TotalSum { get; set; }

        /// <summary>
        /// Дополнительные услуги.
        /// </summary>
        public List<AdditionalService>? Services { get; set; }
    }
}
