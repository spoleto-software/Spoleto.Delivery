using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Callback.Cdek.Models
{
    /// <summary>
    /// Связанная сущность.
    /// </summary>
    public record RelatedEntity
    {
        /// <summary>
        /// Тип связанной сущности, может принимать значения:
        /// direct_order - прямой заказ```
        /// client_direct_order - прямой заказ, по которому оформлен клиентский возврат
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Номер заказа СДЭК
        /// </summary>
        [JsonPropertyName("cdek_number")]
        public string CdekNumber { get; set; }

        /// <summary>
        /// Идентификатор связанной сущности
        /// </summary>
        [JsonPropertyName("uuid")]
        public Guid Uuid { get; set; }
    }
}
