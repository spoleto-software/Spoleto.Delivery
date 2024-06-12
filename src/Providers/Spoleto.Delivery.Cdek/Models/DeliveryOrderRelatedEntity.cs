using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Связанные сущности (print).
    /// </summary>
    public record DeliveryOrderRelatedEntity
    {
        /// <summary>
        /// Получает или задает тип связанной сущности.
        /// </summary>
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonEnumValueConverter<PrintType>))]
        public PrintType Type { get; set; }

        /// <summary>
        /// Получает или задает идентификатор сущности, связанной с заказом.
        /// </summary>
        [JsonPropertyName("uuid")]
        public Guid Uuid { get; set; }
    }
}
