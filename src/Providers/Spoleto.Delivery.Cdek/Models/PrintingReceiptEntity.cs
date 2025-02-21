using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Информация о квитанции к заказу.
    /// </summary>
    public record PrintingReceiptEntity
    {
        /// <summary>
        /// Идентификатор квитанции к заказу в ИС СДЭК.
        /// </summary>
        [JsonPropertyName("uuid")]
        public Guid Uuid { get; set; }

        /// <summary>
        /// Список заказов.
        /// </summary>
        [JsonPropertyName("orders")]
        public List<PrintingOrder> Orders { get; set; }

        /// <summary>
        /// Число копий одной квитанции на листе.
        /// </summary>
        [JsonPropertyName("copy_count")]
        public int? CopyCount { get; set; }

        /// <summary>
        /// Форма квитанции. По умолчанию будет выбрана форма на русском языке.
        /// </summary>
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonEnumValueConverter<PrintingReceiptType>))]
        public PrintingReceiptType Type { get; set; }

        /// <summary>
        /// Ссылка на скачивание файла.
        /// </summary>
        /// <remarks>
        /// Содержится в ответе только в статусе "Сформирован" Формат: https://api.cdek.ru/v2/print/barcodes/{uuid}.pdf<br/>
        /// Для получения файла с ШК к заказу/заказам воспользуйтесь методом "Скачивание готового ШК"
        /// </remarks>
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        /// <summary>
        /// Статус квитанции.
        /// </summary>
        [JsonPropertyName("statuses")]
        public List<PrintingOrderStatus> Statuses { get; set; }
    }
}
