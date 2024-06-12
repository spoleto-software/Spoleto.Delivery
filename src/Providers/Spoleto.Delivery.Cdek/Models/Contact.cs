using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Контактное лицо.
    /// </summary>
    public record Contact
    {
        /// <summary>
        /// Название компании.
        /// </summary>
        [JsonPropertyName("company")]
        public string Company { get; set; }

        /// <summary>
        /// ФИО контактного лица.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Электронный адрес, используется для оповещений. Должен соответствовать RFC 2822.
        /// </summary>
        /// <remarks>
        /// Если email указан некорректно, то он будет удалён, а заказ создан.<br/>
        /// Для международных заказов рекомендуется указывать e-mail.
        /// </remarks>
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        /// <summary>
        /// Серия паспорта.
        /// </summary>
        [JsonPropertyName("passport_series")]
        public string? PassportSeries { get; set; }

        /// <summary>
        /// Номер паспорта.
        /// </summary>
        [JsonPropertyName("passport_number")]
        public string? PassportNumber { get; set; }

        /// <summary>
        /// Дата выдачи паспорта.
        /// </summary>
        [JsonPropertyName("passport_date_of_issue")]
        [JsonConverter(typeof(JsonDateOnlyConverter))]
        public DateTime? PassportDateOfIssue { get; set; }

        /// <summary>
        /// Орган выдачи паспорта.
        /// </summary>
        [JsonPropertyName("passport_organization")]
        public string? PassportOrganization { get; set; }

        /// <summary>
        /// ИНН.
        /// </summary>
        /// <remarks>
        /// Может содержать 10, либо 12 символов.
        /// </remarks>
        [JsonPropertyName("tin")]
        public string? Tin { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        [JsonPropertyName("passport_date_of_birth")]
        [JsonConverter(typeof(JsonDateOnlyConverter))]
        public DateTime? PassportDateOfBirth { get; set; }

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
