using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Callback.Cdek.Models
{
    /// <summary>
    /// Атрибуты события <see cref="CdekWebhookMessageType.PRINT_FORM"/>.
    /// </summary>
    public record PrintForm : ICdekWebhookContent
    {
        /// <summary>
        /// Тип печатной формы:
        /// WAYBILL - квитанция к заказу
        /// BARCODE - ШК места к заказу
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Ссылка на скачивание файла:
        /// Формат: https://api.cdek.ru/v2/print/orders/{uuid}.pdf для квитанции
        /// https://api.cdek.ru/v2/print/barcodes/{uuid}.pdf для ШК места
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
