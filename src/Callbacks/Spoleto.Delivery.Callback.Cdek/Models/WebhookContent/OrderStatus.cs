using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;
using Spoleto.Delivery.Callback.Cdek.Converters;

namespace Spoleto.Delivery.Callback.Cdek.Models
{
    /// <summary>
    /// Атрибуты события <see cref="CdekWebhookMessageType.ORDER_STATUS"/>.
    /// </summary>
    public record OrderStatus : ICdekWebhookContent
    {
        /// <summary>
        /// Признак возвратного заказа:
        /// true - является возвратной
        /// false - является прямой
        /// </summary>
        [JsonPropertyName("is_return")]
        public bool IsReturn { get; set; }

        /// <summary>
        /// Номер заказа СДЭК.
        /// </summary>
        [JsonPropertyName("cdek_number")]
        public string CdekNumber { get; set; }

        /// <summary>
        /// Номер заказа в ИС Клиента.
        /// </summary>
        [JsonPropertyName("number")]
        public string? Number { get; set; }

        /// <summary>
        /// Код статуса (устаревшее поле).
        /// </summary>
        [JsonPropertyName("status_code")]
        public string StatusCode { get; set; }

        /// <summary>
        /// Код дополнительного статуса (подробнее см. приложение 2).
        /// </summary>
        [JsonPropertyName("status_reason_code")]
        [JsonConverter(typeof(JsonIntEnumConverter<OrderAdditionalStatus>))]
        public OrderAdditionalStatus? StatusReasonCode { get; set; }

        /// <summary>
        /// Дата и время установки статуса.
        /// </summary>
        [JsonPropertyName("status_date_time")]
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime StatusDateTime { get; set; }

        /// <summary>
        /// Наименование города возникновения статуса.
        /// </summary>
        [JsonPropertyName("city_name")]
        public string? CityName { get; set; }

        /// <summary>
        /// Код города возникновения статуса (не возвращается для статуса "Создан").
        /// </summary>
        [JsonPropertyName("city_code")]
        public string? CityCode { get; set; }

        /// <summary>
        /// Код статуса (подробнее см. приложение 1).
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// Признак возвратного заказа.
        /// </summary>
        [JsonPropertyName("is_reverse")]
        public bool IsReverse { get; set; }

        /// <summary>
        /// Признак клиентского возврата.
        /// </summary>
        [JsonPropertyName("is_client_return")]
        public bool IsClientReturn { get; set; }

        /// <summary>
        /// Связанные сущности, массив объектов.
        /// </summary>
        [JsonPropertyName("related_entities")]
        public List<RelatedEntity>? RelatedEntities { get; set; }
    }
}
