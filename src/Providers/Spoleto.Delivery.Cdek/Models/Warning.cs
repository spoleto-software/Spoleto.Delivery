using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    public record Warning
    {
        /// <summary>
        /// Получает или задает код предупреждения.
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// Получает или задает описание предупреждения.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
