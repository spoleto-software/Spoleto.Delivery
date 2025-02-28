﻿using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;
using Spoleto.Delivery.Providers.Cdek.Converters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Связанная с заказом сущность.
    /// </summary>
    public record DeliveryOrderRelatedEntity
    {
        /// <summary>
        /// Тип сущности, связанной с заказом.
        /// Может принимать значения:
        /// return_order, direct_order, waybill, barcode, reverse_order, delivery,
        /// client_return_order, client_direct_order.
        /// </summary>
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonEnumValueConverter<OrderRelatedEntityType>))]
        public OrderRelatedEntityType Type { get; set; }

        /// <summary>
        /// Идентификатор сущности, связанной с заказом.
        /// </summary>
        [JsonPropertyName("uuid")]
        public Guid Uuid { get; set; }

        /// <summary>
        /// Ссылка на скачивание печатной формы в статусе "Сформирован".
        /// Только для types: waybill, barcode.
        /// URL может не отображаться, если ссылка на скачивание ПФ еще не сформирована.
        /// </summary>
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        /// <summary>
        /// Номер заказа СДЭК.
        /// Может возвращаться для types: return_order, direct_order, reverse_order, client_return_order, client_direct_order.
        /// </summary>
        [JsonPropertyName("cdek_number")]
        public string? CdekNumber { get; set; }

        /// <summary>
        /// Дата доставки, согласованная с получателем.
        /// Только для типа: delivery.
        /// </summary>
        [JsonPropertyName("date")]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Время начала ожидания курьера (согласованное с получателем).
        /// Только для типа: delivery.
        /// </summary>
        [JsonPropertyName("time_from")]
        [JsonConverter(typeof(JsonTimeSpanConverter))]
        public TimeSpan? TimeFrom { get; set; }

        /// <summary>
        /// Время окончания ожидания курьера (согласованное с получателем).
        /// Только для типа: delivery.
        /// </summary>
        [JsonPropertyName("time_to")]
        [JsonConverter(typeof(JsonTimeSpanConverter))]
        public TimeSpan? TimeTo { get; set; }

        /// <summary>
        /// Дата и время создания сущности, связанной с заказом.
        /// </summary>
        [JsonPropertyName("create_time")]
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime? CreateTime { get; set; }
    }
}
