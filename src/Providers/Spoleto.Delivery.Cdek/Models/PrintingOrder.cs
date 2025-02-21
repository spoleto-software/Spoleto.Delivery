using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Номер накладной на печать.
    /// </summary>
    public record PrintingOrder
    {
        /// <summary>
        /// Идентификатор заказа в ИС СДЭК.
        /// </summary>
        [JsonPropertyName("order_uuid")]
        public string? OrderUuid { get; set; }

        /// <summary>
        /// Номер заказа СДЭК.
        /// </summary>
        [JsonPropertyName("cdek_number")]
        public int? CdekNumber { get; set; }
    }
}
