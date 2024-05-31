using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Дополнительная услуга.
    /// </summary>
    public record AdditionalServiceBase
    {
        /// <summary>
        /// Доп. услуга.
        /// </summary>
        [JsonPropertyName("ADDSERV")]
        public string Name { get; set; }
    }
}
