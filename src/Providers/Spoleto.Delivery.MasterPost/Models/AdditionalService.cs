using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost
{
    internal record AdditionalService
    {
        [JsonPropertyName("ADDSERV")]
        public string Name { get; set; }
    }
}
