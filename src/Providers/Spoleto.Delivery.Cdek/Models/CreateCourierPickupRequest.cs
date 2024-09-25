using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;
using Spoleto.Delivery.Providers.Cdek.Converters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// The courier pickup order request to create.
    /// </summary>
    public record CreateCourierPickupRequest
    {
        /// <summary>
        /// Номер заказа СДЭК.
        /// </summary>
        [JsonPropertyName("cdek_number")]
        public string? CdekOrderNumber { get; set; }

        /// <summary>
        /// Идентификатор заказа в ИС СДЭК.
        /// </summary>
        [JsonPropertyName("order_uuid")]
        public Guid? OrderUuid { get; set; }

        /// <summary>
        /// Дата ожидания курьера.
        /// </summary>
        /// <remarks>
        /// Дата ожидания курьера не может быть больше текущей более чем на 31 день.
        /// Заявка, созданная на текущую дату после 15:00 по времени отправителя, может быть выполнена на следующий день.
        /// </remarks>
        [JsonPropertyName("intake_date")]
        [JsonConverter(typeof(JsonDateOnlyConverter))]
        public DateTime IntakeDate { get; set; }

        /// <summary>
        /// Время начала ожидания курьера.
        /// </summary>
        /// <remarks>
        /// Не ранее 9:00 местного времени.
        /// </remarks>
        [JsonPropertyName("intake_time_from")]
        [JsonConverter(typeof(JsonTimeSpanConverter))]
        public TimeSpan IntakeTimeFrom { get; set; }

        /// <summary>
        /// Время окончания ожидания курьера.
        /// </summary>
        /// <remarks>
        /// Не позднее 22:00 местного времени.
        /// </remarks>
        [JsonPropertyName("intake_time_to")]
        [JsonConverter(typeof(JsonTimeSpanConverter))]
        public TimeSpan IntakeTimeTo { get; set; }

        /// <summary>
        /// Время начала обеда, должно входить в диапазон [<see cref="IntakeTimeFrom"/>; <see cref="IntakeTimeTo"/>].
        /// </summary>
        [JsonPropertyName("lunch_time_from")]
        public TimeSpan? LunchTimeFrom { get; set; }

        /// <summary>
        /// Время окончания обеда, должно входить в диапазон [<see cref="IntakeTimeFrom"/>; <see cref="IntakeTimeTo"/>].
        /// </summary>
        [JsonPropertyName("lunch_time_to")]
        public TimeSpan? LunchTimeTo { get; set; }

        /// <summary>
        /// Описание груза.
        /// </summary>
        /// <remarks>
        /// Необходимо заполнять, если не передан номер заказа. Иначе значение берется из заказа.
        /// </remarks>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Общий вес (в граммах).
        /// </summary>
        /// <remarks>
        /// Необходимо заполнять, если не передан номер заказа. Иначе значение берется из заказа.
        /// </remarks>
        [JsonPropertyName("weight")]
        public int? Weight { get; set; }

        /// <summary>
        /// Габариты упаковки. Длина (в сантиметрах).
        /// </summary>
        /// <remarks>
        /// Необходимо заполнять, если не передан номер заказа. Иначе значение берется из заказа.
        /// </remarks>
        [JsonPropertyName("length")]
        public int? Length { get; set; }

        /// <summary>
        /// Габариты упаковки. Ширина (в сантиметрах).
        /// </summary>
        /// <remarks>
        /// Необходимо заполнять, если не передан номер заказа. Иначе значение берется из заказа.
        /// </remarks>
        [JsonPropertyName("width")]
        public int? Width { get; set; }

        /// <summary>
        /// Габариты упаковки. Высота (в сантиметрах).
        /// </summary>
        /// <remarks>
        /// Необходимо заполнять, если не передан номер заказа. Иначе значение берется из заказа.
        /// </remarks>
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
        /// <remarks>
        /// Необходимо заполнять, если не передан номер заказа. Иначе значение берется из заказа.
        /// Если номер заказа передан, данные об отправителе будут взяты из этого заказа.
        /// </remarks>
        [JsonPropertyName("sender")]
        public CourierPickupContact? Sender { get; set; }

        /// <summary>
        /// Адрес отправителя (забора).
        /// </summary>
        /// <remarks>
        /// Необходимо заполнять, если не передан номер заказа. Иначе значение берется из заказа.
        /// </remarks>
        [JsonPropertyName("from_location")]
        public CourierPickupLocation? FromLocation { get; set; }

        /// <summary>
        /// Необходим прозвон отправителя (по умолчанию - false).
        /// </summary>
        [JsonPropertyName("need_call")]
        public bool? NeedCall { get; set; }

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
