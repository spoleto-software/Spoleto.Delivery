using System.Text.Json.Serialization;
using Spoleto.Delivery.Providers.Cdek.Converters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Информация о заявке на вызов курьера на забор груза.
    /// </summary>
    /// <remarks>
    /// <see href="https://api-docs.cdek.ru/29948360.html"/>
    /// </remarks>
    public record CourierPickupEntity
    {
        /// <summary>
        /// Идентификатор заявки в ИС СДЭК.
        /// </summary>
        [JsonPropertyName("uuid")]
        public Guid Uuid { get; set; }

        /// <summary>
        /// Номер заявки СДЭК на вызов курьера.
        /// </summary>
        [JsonPropertyName("intake_number")]
        public string? CdekNumber { get; set; }

        /// <summary>
        /// Номер заказа СДЭК.
        /// </summary>
        [JsonPropertyName("cdek_number")]
        public string? OrderCdekNumber { get; set; }

        /// <summary>
        /// Идентификатор заказа в ИС СДЭК.
        /// </summary>
        [JsonPropertyName("order_uuid")]
        public Guid? OrderUuid { get; set; }

        /// <summary>
        /// Дата ожидания курьера.
        /// </summary>
        [JsonPropertyName("intake_date")]
        public DateTime IntakeDate { get; set; }

        /// <summary>
        /// Время начала ожидания курьера.
        /// </summary>
        [JsonPropertyName("intake_time_from")]
        [JsonConverter(typeof(JsonTimeSpanConverter))]
        public TimeSpan IntakeTimeFrom { get; set; }

        /// <summary>
        /// Время окончания ожидания курьера.
        /// </summary>
        [JsonPropertyName("intake_time_to")]
        [JsonConverter(typeof(JsonTimeSpanConverter))]
        public TimeSpan IntakeTimeTo { get; set; }

        /// <summary>
        /// Время начала обеда, должно входить в диапозон [<see cref="IntakeTimeFrom"/>; <see cref="IntakeTimeTo"/>].
        /// </summary>
        [JsonPropertyName("lunch_time_from")]
        [JsonConverter(typeof(JsonTimeSpanConverter))]
        public TimeSpan? LunchTimeFrom { get; set; }

        /// <summary>
        /// Время окончания обеда, должно входить в диапозон [<see cref="IntakeTimeFrom"/>; <see cref="IntakeTimeTo"/>].
        /// </summary>
        [JsonPropertyName("lunch_time_to")]
        [JsonConverter(typeof(JsonTimeSpanConverter))]
        public TimeSpan? LunchTimeTo { get; set; }

        /// <summary>
        /// Описание груза.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Общий вес (в граммах).
        /// </summary>
        [JsonPropertyName("weight")]
        public int? Weight { get; set; }

        /// <summary>
        /// Габариты упаковки. Длина (в сантиметрах).
        /// </summary>
        [JsonPropertyName("length")]
        public int? Length { get; set; }

        /// <summary>
        /// Габариты упаковки. Ширина (в сантиметрах).
        /// </summary>
        [JsonPropertyName("width")]
        public int? Width { get; set; }

        /// <summary>
        /// Габариты упаковки. Высота (в сантиметрах).
        /// </summary>
        [JsonPropertyName("height")]
        public int? Height { get; set; }

        /// <summary>
        /// Комментарий к заявке для курьера.
        /// </summary>
        [JsonPropertyName("comment")]
        public string? Comment { get; set; }

        /// <summary>
        /// Отправитель.
        /// </summary>
        [JsonPropertyName("sender")]
        public CourierPickupContact? Sender { get; set; }

        /// <summary>
        /// Адрес отправителя (забора).
        /// </summary>
        [JsonPropertyName("from_location")]
        public CourierPickupLocation? FromLocation { get; set; }

        /// <summary>
        /// Необходим прозвон отправителя (по умолчанию - false).
        /// </summary>
        [JsonPropertyName("need_call")]
        public bool? NeedCall { get; set; }

        /// <summary>
        /// Статус по заявке.
        /// </summary>
        [JsonPropertyName("statuses")]
        public List<CourierPickupStatus> Statuses { get; set; }

        /// <summary>
        /// Курьеру необходима доверенность (по умолчанию - false).
        /// </summary>
        [JsonPropertyName("courier_power_of_attorney")]
        public bool? CourierPowerOfAttorney { get; set; }

        /// <summary>
        /// Курьеру необходим документ удостоверяющий личность (по умолчанию - false).
        /// </summary>
        [JsonPropertyName("courier_identity_card")]
        public bool? CourierIdentityCard { get; set; }
    }
}