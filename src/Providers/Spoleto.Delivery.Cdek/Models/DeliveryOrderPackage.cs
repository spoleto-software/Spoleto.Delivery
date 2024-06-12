using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Класс для представления информации о пакете
    /// </summary>
    /// <remarks>
    /// <see href="https://api-docs.cdek.ru/63345519.html"/>
    /// </remarks>
    public record DeliveryOrderPackage : Package
    {
        /// <summary>
        /// Номер упаковки (можно использовать порядковый номер упаковки заказа или номер заказа), уникален в пределах заказа.<br/>
        /// Идентификатор заказа в ИС Клиента
        /// </summary>
        [JsonPropertyName("number")]
        public string Number { get; set; }

        /// <summary>
        /// Комментарий к упаковке.
        /// </summary>
        /// <remarks>
        /// Обязательно и только для заказа типа "доставка".
        /// </remarks>
        [JsonPropertyName("comment")]
        public string? Comment { get; set; }

        /// <summary>
        /// Позиции товаров в упаковке
        /// </summary>
        /// <remarks>
        /// Только для заказов "интернет-магазин".<br/>
        /// Максимум 126 уникальных позиций в заказе.<br/>
        /// Общее количество товаров в заказе может быть от 1 до 999999.
        /// </remarks>
        public List<DeliveryPackageItem>? Items { get; set; }
    }
}
