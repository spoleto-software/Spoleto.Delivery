using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Дополнительная услуга.
    /// </summary>
    public record AdditionalService : AdditionalServiceBase
    {
        /// <summary>
        /// Использование.
        /// </summary>
        /// <remarks>
        /// Варианты:
        /// Опционально,
        /// Никогда,
        /// Всегда.
        /// </remarks>
        [JsonPropertyName("USAGE")]
        public UsageKind Usage { get; set; }
    }
}
