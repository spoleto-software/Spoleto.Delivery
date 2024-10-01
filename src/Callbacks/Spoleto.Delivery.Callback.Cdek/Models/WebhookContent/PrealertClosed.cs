using System.Text.Json.Serialization;
using Spoleto.Delivery.Callback.Cdek.Converters;

namespace Spoleto.Delivery.Callback.Cdek.Models
{
    /// <summary>
    /// Атрибуты события <see cref="CdekWebhookMessageType.PREALERT_CLOSED"/>.
    /// </summary>
    public record PrealertClosed : ICdekWebhookContent
    {
        /// <summary>
        /// Номер СДЭК закрытого преалерта.
        /// </summary>
        [JsonPropertyName("prealert_number")]
        public string PrealertNumber { get; set; }

        /// <summary>
        /// Дата закрытия.
        /// </summary>
        [JsonPropertyName("closed_date")]
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime ClosedDate { get; set; }

        /// <summary>
        /// Фактический ПВЗ, в который были переданы заказы.
        /// </summary>
        [JsonPropertyName("fact_shipment_point")]
        public string FactShipmentPoint { get; set; }
    }
}
