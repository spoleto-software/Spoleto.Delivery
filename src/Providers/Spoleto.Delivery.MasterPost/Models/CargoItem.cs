using System.Text.Json.Serialization;

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
