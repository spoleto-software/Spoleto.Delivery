using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Товар.
    /// </summary>
    public record CargoItem : CargoItemBase
    {
        /// <summary>
        /// Криптохвост
        /// </summary>
        [JsonPropertyName("ART_MARK_TAIL")]
        public string ArticleMarkingTail { get; set; }
    }
}
