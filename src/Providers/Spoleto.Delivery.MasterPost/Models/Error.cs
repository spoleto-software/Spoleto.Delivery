using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Ошибка.
    /// </summary>
    public record Error
    {
        /// <summary>
        /// Код ошибки
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// Описание ошибки
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}