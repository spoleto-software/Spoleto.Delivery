using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Запрос для получения списка населенных пунктов.
    /// </summary>
    public record CityRequest
    {
        /// <summary>
        /// Фильтр для поиска населенных пунктов.
        /// </summary>
        [JsonPropertyName("filter")]
        public string Filter { get; set; }
    }
}
