using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Информация о транспорте для сопроводительной накладной на товар (СНТ)
    /// </summary>
    public record AccompanyingWaybill
    {
        /// <summary>
        /// Наименование юр.лица клиента, создающего СНТ
        /// </summary>
        [JsonPropertyName("client_name")]
        public string ClientName { get; set; }

        /// <summary>
        /// Номер авиарейса
        /// </summary>
        [JsonPropertyName("flight_number")]
        public string FlightNumber { get; set; }

        /// <summary>
        /// Накладные перевозчика для авиарейса
        /// </summary>
        [JsonPropertyName("air_waybill_numbers")]
        public List<string> AirWaybillNumbers { get; set; }

        /// <summary>
        /// Номера автомобилей
        /// </summary>
        [JsonPropertyName("vehicle_numbers")]
        public List<string> VehicleNumbers { get; set; }

        /// <summary>
        /// ФИО водителя автомобиля
        /// </summary>
        [JsonPropertyName("vehicle_driver")]
        public string VehicleDriver { get; set; }

        /// <summary>
        /// Планируемая дата отправления (формат YYYY-MM-DDThh:mm:ss±hhmm)
        /// </summary>
        [JsonPropertyName("planned_departure_date_time")]
        public DateTime? PlannedDepartureDateTime { get; set; }
    }
}