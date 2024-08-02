using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Класс для представления локации (местоположения) для обновления заказа на доставку.
    /// </summary>
    /// <remarks>
    /// <see href="https://api-docs.cdek.ru/36981178.html"/>
    /// </remarks>
    public record UpdateDeliveryOrderLocation
    {
        /// <summary>
        /// Строка адреса.
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; }
    }
}
