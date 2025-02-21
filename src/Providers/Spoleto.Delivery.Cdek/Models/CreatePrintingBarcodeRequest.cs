using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Запрос для формирования ШК места в формате pdf к заказу/заказам.
    /// </summary>
    /// <remarks>
    /// Во избежание перегрузки платформы нельзя передавать более 100 номеров заказов в одном запросе.
    /// </remarks>
    public record CreatePrintingBarcodeRequest
    {
        /// <summary>
        /// Список заказов.
        /// </summary>
        [JsonPropertyName("orders")]
        public List<PrintingOrder> Orders { get; set; } = [];

        /// <summary>
        /// Число копий.
        /// </summary>
        /// <remarks>
        /// По умолчанию: 1.
        /// </remarks>
        [JsonPropertyName("copy_count")]
        public int? CopyCount { get; set; }

        /// <summary>
        /// Формат печати.
        /// </summary>
        [JsonPropertyName("format")]
        [JsonConverter(typeof(JsonEnumValueConverter<PrintingBarcodeFormat>))]
        public PrintingBarcodeFormat? Format { get; set; }

        /// <summary>
        /// Язык печатной формы.
        /// </summary>
        /// <remarks>
        /// Возможные языки в кодировке ISO - 639-3:<br/>
        /// Русский - RUS,<br/>
        /// Английский - ENG.
        /// </remarks>
        [JsonPropertyName("lang")]
        public string? Lang { get; set; }
    }
}
