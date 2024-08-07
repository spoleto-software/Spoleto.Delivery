using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Класс для представления информации о пакете
    /// </summary>
    /// <remarks>
    /// <see href="https://api-docs.cdek.ru/63345519.html"/>
    /// </remarks>
    public record DeliveryOrderPackageBase : Package
    {
        /// <summary>
        /// Номер упаковки (можно использовать порядковый номер упаковки заказа или номер заказа), уникален в пределах заказа.<br/>
        /// Идентификатор заказа в ИС Клиента
        /// </summary>
        [JsonPropertyName("number")]
        public string CisNumber { get; set; }

        /// <summary>
        /// Комментарий к упаковке.
        /// </summary>
        /// <remarks>
        /// Обязательно и только для заказа типа "доставка".
        /// </remarks>
        [JsonPropertyName("comment")]
        public string? Comment { get; set; }
    }
}
