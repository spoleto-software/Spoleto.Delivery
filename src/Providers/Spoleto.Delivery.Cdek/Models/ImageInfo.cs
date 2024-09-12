using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Фото.
    /// </summary>
    public record ImageInfo
    {
        /// <summary>
        /// Ссылка на фото.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}