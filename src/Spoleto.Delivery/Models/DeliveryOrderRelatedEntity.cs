﻿namespace Spoleto.Delivery
{
    /// <summary>
    /// Связанные сущности заказа на доставку.
    /// </summary>
    public record DeliveryOrderRelatedEntity
    {
        /// <summary>
        /// Получает или задает тип связанной сущности.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Получает или задает идентификатор сущности, связанной с заказом.
        /// </summary>
        public Guid Uuid { get; set; }

        /// <summary>
        /// Дата и время создания сущности, связанной с заказом.
        /// </summary>
        public DateTime? CreateTime { get; set; }
    }
}
