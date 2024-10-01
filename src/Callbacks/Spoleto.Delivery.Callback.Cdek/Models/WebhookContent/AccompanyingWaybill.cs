using System.Text.Json.Serialization;
using Spoleto.Delivery.Callback.Cdek.Converters;

namespace Spoleto.Delivery.Callback.Cdek.Models
{
    /// <summary>
    /// Атрибуты события <see cref="CdekWebhookMessageType.ACCOMPANYING_WAYBILL"/>.
    /// </summary>
    public record AccompanyingWaybill : ICdekWebhookContent
    {
        /// <summary>
        /// Номер заказа СДЭК.
        /// </summary>
        [JsonPropertyName("cdek_number")]
        public string CdekNumber { get; set; }

        /// <summary>
        /// Наименование юр.лица клиента, создающего СНТ.
        /// </summary>
        [JsonPropertyName("client_name")]
        public string ClientName { get; set; }

        /// <summary>
        /// Номер авиарейса.
        /// </summary>
        [JsonPropertyName("flight_number")]
        public string? FlightNumber { get; set; }

        /// <summary>
        /// Накладные перевозчика для авиарейса.
        /// </summary>
        [JsonPropertyName("air_waybill_numbers")]
        public List<string>? AirWaybillNumbers { get; set; }

        /// <summary>
        /// Номера транспортных средств.
        /// </summary>
        [JsonPropertyName("vehicle_numbers")]
        public List<string>? VehicleNumbers { get; set; }

        /// <summary>
        /// Водитель транспортного средства.
        /// </summary>
        [JsonPropertyName("vehicle_driver")]
        public string? VehicleDriver { get; set; }

        /// <summary>
        /// Плановая дата и время отправления (формат YYYY-MM-DDThh:mm:ss±hhmm).
        /// </summary>
        [JsonPropertyName("planned_departure_date_time")]
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime PlannedDepartureDateTime { get; set; }
    }
}
