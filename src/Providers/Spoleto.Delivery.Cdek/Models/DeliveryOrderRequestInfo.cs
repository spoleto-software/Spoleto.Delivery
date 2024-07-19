using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;
using Spoleto.Delivery.Providers.Cdek.Converters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Информация о запросе над заказом.
    /// </summary>
    public record DeliveryOrderRequestInfo
    {
        /// <summary>
        /// Получает или задает идентификатор запроса в ИС СДЭК.
        /// </summary>
        [JsonPropertyName("request_uuid")]
        public Guid? RequestUuid { get; set; }

        /// <summary>
        /// Получает или задает тип запроса.
        /// </summary>
        [JsonPropertyName("type")]
        public RequestType Type { get; set; }

        /// <summary>
        /// Получает или задает дату и время установки текущего состояния запроса.
        /// Формат yyyy-MM-dd'T'HH:mm:ssZ.
        /// </summary>
        [JsonPropertyName("date_time")]
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Получает или задает текущее состояние запроса.
        /// </summary>
        [JsonPropertyName("state")]
        [JsonConverter(typeof(JsonEnumValueConverter<RequestState>))]
        public RequestState State { get; set; }

        /// <summary>
        /// Получает или задает ошибки, возникшие в ходе выполнения запроса.
        /// </summary>
        [JsonPropertyName("errors")]
        public List<Error> Errors { get; set; }

        /// <summary>
        /// Получает или задает предупреждения, возникшие в ходе выполнения запроса.
        /// </summary>
        [JsonPropertyName("warnings")]
        public List<Warning> Warnings { get; set; }
    }


}
