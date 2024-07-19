using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Ошибка.
    /// </summary>
    public record Error
    {
        /// <summary>
        /// Код ошибки.
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// Описание ошибки.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }

        public override string ToString() => $"{nameof(Code)}: {Code}. {nameof(Message)}: {Message}";
    }
}
