using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    public record Phone
    {
        /// <summary>
        /// Номер телефона. 
        /// Должен передаваться в международном формате: код страны (для России +7) и сам номер (10 и более цифр).
        /// Обязательно, если заказ типа "доставка", иначе не требуется.
        /// </summary>
        [JsonPropertyName("number")]
        public string Number { get; set; }

        /// <summary>
        /// Дополнительная информация (добавочный номер).
        /// </summary>
        [JsonPropertyName("additional")]
        public string? Additional { get; set; }
    }
}
