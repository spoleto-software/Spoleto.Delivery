using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Cdek delivery order request to update.
    /// </summary>
    /// <remarks>
    /// <see href="https://api-docs.cdek.ru/36981178.html"/>
    /// </remarks>
    public record UpdateDeliveryOrderRequest
    {
        /// <summary>
        /// Идентификатор заказа в ИС СДЭК, который нужно изменить.
        /// Обязательное поле, если не заполнено <see cref="CdekNumber"/>.
        /// </summary>
        [JsonPropertyName("uuid")]
        public Guid? Uuid { get; set; }

        /// <summary>
        /// Номер заказа СДЭК, который нужно изменить.
        /// Обязательное поле, если не заполнено <see cref="Uuid"/>.
        /// </summary>
        [JsonPropertyName("cdek_number")]
        public string? CdekNumber { get; set; }

        /// <summary>
        /// Код тарифа (режимы старого и нового тарифа должны совпадать).
        /// </summary>
        [JsonPropertyName("tariff_code")]
        public int? TariffCode { get; set; }

        /// <summary>
        /// Комментарий к заказу.
        /// </summary>
        [JsonPropertyName("comment")]
        public string? Comment { get; set; }

        /// <summary>
        /// Код ПВЗ СДЭК, на который будет произведен забор отправления либо самостоятельный привоз клиентом.
        /// Не может использоваться одновременно с <see cref="FromLocation"/>.
        /// </summary>
        [JsonPropertyName("shipment_point")]
        public string? ShipmentPoint { get; set; }

        /// <summary>
        /// Код ПВЗ СДЭК, на который будет доставлена посылка.
        /// Не может использоваться одновременно с <see cref="ToLocation"/>.
        /// </summary>
        [JsonPropertyName("delivery_point")]
        public string? DeliveryPoint { get; set; }

        /// <summary>
        /// Дополнительный сбор за доставку, который ИМ берет с получателя.
        /// Валюта сбора должна совпадать с валютой наложенного платежа.
        /// </summary>
        [JsonPropertyName("delivery_recipient_cost")]
        public DeliveryRecipientCost? DeliveryRecipientCost { get; set; }

        /// <summary>
        /// Порог стоимости товара для расчета дополнительного сбора за доставку.
        /// </summary>
        [JsonPropertyName("delivery_recipient_cost_adv")]
        public List<DeliveryRecipientCostAdv>? DeliveryRecipientCostAdv { get; set; }

        /// <summary>
        /// Информация об отправителе.
        /// </summary>
        [JsonPropertyName("sender")]
        public ContactBase? Sender { get; set; }

        /// <summary>
        /// Реквизиты реального продавца.
        /// </summary>
        [JsonPropertyName("seller")]
        public Seller? Seller { get; set; }

        /// <summary>
        /// Информация о получателе.
        /// </summary>
        [JsonPropertyName("recipient")]
        public ContactBase? Recipient { get; set; }

        /// <summary>
        /// Адрес получения.
        /// Не может использоваться одновременно с <see cref="DeliveryPoint"/>.
        /// </summary>
        [JsonPropertyName("to_location")]
        public DeliveryOrderLocation? ToLocation { get; set; }

        /// <summary>
        /// Адрес отправки.
        /// Не может использоваться одновременно с <see cref="ShipmentPoint"/>.
        /// </summary>
        [JsonPropertyName("from_location")]
        public UpdateDeliveryOrderLocation? FromLocation { get; set; }

        /// <summary>
        /// Дополнительные услуги.
        /// </summary>
        [JsonPropertyName("services")]
        public List<AdditionalService>? Services { get; set; }

        /// <summary>
        /// Список информации по местам (упаковкам).
        /// </summary>
        [JsonPropertyName("packages")]
        public List<DeliveryOrderPackageRequest>? Packages { get; set; }
    }
}
