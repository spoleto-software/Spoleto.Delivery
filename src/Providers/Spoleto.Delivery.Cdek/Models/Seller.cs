using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Продавец.
    /// </summary>
    public record Seller
    {
        /// <summary>
        /// Наименование истинного продавца.
        /// </summary>
        /// <remarks>
        /// Обязательное свойство, если заполнен <see cref="Inn"/>.
        /// </remarks>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// ИНН истинного продавца.
        /// </summary>
        /// <remarks>
        /// Может содержать 10, либо 12 символов.
        /// </remarks>
        [JsonPropertyName("inn")]
        public string Inn { get; set; }

        /// <summary>
        /// Телефон истинного продавца.
        /// </summary>
        /// <remarks>
        /// Обязательное свойство, если заполнен <see cref="Inn"/>.
        /// </remarks>
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Код формы собственности.
        /// </summary>
        /// <remarks>
        /// Обязательное свойство, если заполнен <see cref="Inn"/>.
        /// </remarks>
        [JsonPropertyName("ownership_form")]
        public int? OwnershipForm { get; set; }

        /// <summary>
        /// Адрес истинного продавца.
        /// </summary>
        /// <remarks>
        /// Используется при печати инвойсов для отображения адреса настоящего продавца товара, либо торгового названия.<br/>
        /// Обязательное свойство, если заказ - международный.<br/>
        /// Только для международных заказов "интернет-магазин".
        /// </remarks>
        [JsonPropertyName("address")]
        public string Address { get; set; }
    }
}
