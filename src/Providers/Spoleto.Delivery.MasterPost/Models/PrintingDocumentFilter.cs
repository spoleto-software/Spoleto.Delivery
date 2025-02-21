using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Фильтр для поиска накладных для печати.
    /// </summary>
    public record PrintingDocumentFilter
    {
        /// <summary>
        /// Список номеров накладных для печати.
        /// </summary>
        [JsonPropertyName("filter")]
        public List<string> Filter { get; } = [];
    }
}
