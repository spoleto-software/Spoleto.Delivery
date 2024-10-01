using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Callback.Cdek.Models
{
    /// <summary>
    /// Атрибуты события <see cref="CdekWebhookMessageType.ORDER_MODIFIED"/>.
    /// </summary>
    public record OrderModified : ICdekWebhookContent
    {
        // <summary>
        /// Тип изменения заказа. Может принимать значение PLANED_DELIVERY_DATE_CHANGED (добавление плановой даты доставки)  
        /// DELIVERY_SUM_CHANGED (изменение стоимости доставки)
        /// </summary>
        [JsonPropertyName("modification_type")]
        public string ModificationType { get; set; }

        /// <summary>
        /// Новое значение
        /// </summary>
        [JsonPropertyName("new_value")]
        public OrderValue NewValue { get; set; }

    }
}
