using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost
{
    public record AdditionalDeliveryOrder
    {
        /// <summary>
        /// Номер ДН.
        /// </summary>
        [JsonPropertyName("DN_NUM")]
        public string Number { get; set; }

        /// <summary>
        /// Тип ДН.
        /// </summary>
        /// <remarks>Тип доставки накладной. Например, Доставка упаковки или Доставка по резерву.</remarks>
        [JsonPropertyName("DN_TYPE")]
        public string Type { get; set; }
    }
}
