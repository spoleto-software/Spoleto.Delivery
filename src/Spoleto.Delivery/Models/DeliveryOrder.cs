using Spoleto.Delivery.Helpers;

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
        /// Плановая дата доставки.
        /// </summary>
        public DateTime? PlannedDeliveryDate { get; set; }

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
        /// Исходный ответ в Json/Xml.
        /// </summary>
        public string RawBody { get; set; }

        /// <summary>
        /// Исходные ответы в Json/Xml связанных заказов (например, заказа на вызов курьера).
        /// </summary>
        public List<DeliveryOrderRelatedRawBody> RelatedOrderRawBodies { get; set; }

        /// <summary>
        /// Return the order raw body with related orders raw bodies.
        /// </summary>
        /// <returns></returns>
        public string GetFullRawBody()
        {
            var deliveryOrderFullRawBody = new DeliveryOrderFullRawBody
            {
                DeliveryOrder = RawBody
            };

            if (RelatedOrderRawBodies?.Count > 0)
            {
                deliveryOrderFullRawBody.RelatedOrders = RelatedOrderRawBodies.ToList();
            }

            return JsonHelper.ToRelaxedIndentedJson(deliveryOrderFullRawBody);
        }
    }
}
