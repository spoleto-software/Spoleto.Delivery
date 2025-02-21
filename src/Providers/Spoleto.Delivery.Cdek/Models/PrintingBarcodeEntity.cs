using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Информация о ШК месте к заказу.
    /// </summary>
    public record PrintingBarcodeEntity
    {
        /// <summary>
        /// Идентификатор ШК места к заказу в ИС СДЭК.
        /// </summary>
        [JsonPropertyName("uuid")]
        public Guid Uuid { get; set; }

        /// <summary>
        /// Список заказов.
        /// </summary>
        [JsonPropertyName("orders")]
        public List<PrintingOrder> Orders { get; set; }

        /// <summary>
        /// Число копий на листе.
        /// </summary>
        [JsonPropertyName("copy_count")]
        public int? CopyCount { get; set; }

        /// <summary>
        /// Формат печати.
        /// </summary>
        [JsonPropertyName("format")]
        [JsonConverter(typeof(JsonEnumValueConverter<PrintingBarcodeFormat>))]
        public PrintingBarcodeFormat Format { get; set; }

        /// <summary>
        /// Ссылка на скачивание файла.
        /// </summary>
        /// <remarks>
        /// Содержится в ответе только в статусе "Сформирован" Формат: https://api.cdek.ru/v2/print/barcodes/{uuid}.pdf<br/>
        /// Для получения файла с ШК к заказу/заказам воспользуйтесь методом "Скачивание готового ШК".
        /// </remarks>
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        /// <summary>
        /// Язык печатной формы.
        /// </summary>
        /// <remarks>
        /// Возможные языки в кодировке ISO - 639-3:<br/>
        /// "RUS" "ENG" "DEU" "ITA" "TUR" "CES" "KOR" "LIT" "LAV".
        /// </remarks>
        [JsonPropertyName("lang")]
        public string Lang { get; set; }

        /// <summary>
        /// Статус файла.
        /// </summary>
        [JsonPropertyName("statuses")]
        public List<PrintingOrderStatus> Statuses { get; set; }
    }
}
