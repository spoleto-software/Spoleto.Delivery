using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;

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
        [JsonConverter(typeof(JsonEnumValueConverter<UsageKind>))]
        public UsageKind Usage { get; set; }
    }
}
