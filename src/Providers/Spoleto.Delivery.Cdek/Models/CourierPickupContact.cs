using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Контактное лицо для оформления заявки на вызов курьера на забор груза.
    /// </summary>
    public record CourierPickupContact
    {
        /// <summary>
        /// Название компании.
        /// </summary>
        [JsonPropertyName("company")]
        public string? Company { get; set; }

        /// <summary>
        /// ФИО контактного лица.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Список телефонов.
        /// </summary>
        /// <remarks>
        /// Не более 10 номеров.<br/>
        /// Обязательно, если заказ типа "доставка", 
        /// иначе не требуется.
        /// </remarks>
        [JsonPropertyName("phones")]
        public List<Phone>? Phones { get; set; }

        /// <summary>
        /// Тип отправителя.
        /// Возможные значения: 
        /// LEGAL_ENTITY - юридическое лицо, 
        /// INDIVIDUAL - физическое лицо.
        /// </summary>
        [JsonPropertyName("contragent_type")]
        [JsonConverter(typeof(JsonEnumValueConverter<ContragentType>))]
        public ContragentType? ContragentType { get; set; }
    }
}
