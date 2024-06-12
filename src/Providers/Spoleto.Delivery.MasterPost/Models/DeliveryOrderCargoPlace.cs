using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Класс для представления информации о грузо-месте в созданном заказе.
    /// </summary>
    public record DeliveryOrderCargoPlace : CargoPlace
    {
        /// <summary>
        /// Место.
        /// </summary>
        [JsonPropertyName("PLACE_NUM")]
        public string? Number { get; set; }

        /// <summary>
        /// Серийный номер места фактический.
        /// </summary>
        [JsonPropertyName("PLACE_SN")]
        public string? SerialNumber { get; set; }
    }
}
