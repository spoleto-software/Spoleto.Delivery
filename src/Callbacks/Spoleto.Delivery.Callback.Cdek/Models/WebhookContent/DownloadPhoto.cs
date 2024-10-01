using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Callback.Cdek.Models
{
    /// <summary>
    /// Атрибуты события <see cref="CdekWebhookMessageType.DOWNLOAD_PHOTO"/>.
    /// </summary>
    public record DownloadPhoto : ICdekWebhookContent
    {
        /// <summary>
        /// Номер заказа СДЭК.
        /// </summary>
        [JsonPropertyName("cdek_number")]
        public string CdekNumber { get; set; }

        /// <summary>
        /// Ссылка на скачивание файла:
        /// Формат: https://photo-docs.production.cdek.ru/archives/qWErtY
        /// </summary>
        [JsonPropertyName("link")]
        public string Link { get; set; }
    }
}
