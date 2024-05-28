using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost
{
    internal record CargoArticle
    {
        /// <summary>
        /// ОценочнаяСтоимость
        /// </summary>
        [JsonPropertyName("ART_EST_PRICE")]
        public decimal EstimatedPrice { get; set; }
    }
}
