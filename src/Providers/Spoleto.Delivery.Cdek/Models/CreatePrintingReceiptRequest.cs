using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Запрос для формирования квитанции в формате pdf к заказу/заказам.
    /// </summary>
    /// <remarks>
    /// Во избежание перегрузки платформы нельзя передавать более 100 номеров заказов в одном запросе.
    /// </remarks>
    public record CreatePrintingReceiptRequest
    {
        /// <summary>
        /// Список заказов.
        /// </summary>
        [JsonPropertyName("orders")]
        public List<PrintingOrder> Orders { get; set; } = [];

        /// <summary>
        /// Число копий одной квитанции на листе.
        /// </summary>
        /// <remarks>
        /// Рекомендовано указывать не менее 2, одна приклеивается на груз, вторая остается у отправителя.<br/>
        /// По умолчанию: 2.
        /// </remarks>
        [JsonPropertyName("copy_count")]
        public int? CopyCount { get; set; }

        /// <summary>
        /// Форма квитанции. По умолчанию будет выбрана форма на русском языке.
        /// </summary>
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonEnumValueConverter<PrintingReceiptType>))]
        public PrintingReceiptType? Type { get; set; }
    }
}
