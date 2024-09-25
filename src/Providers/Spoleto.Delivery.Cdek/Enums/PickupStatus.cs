using System.ComponentModel;
using System.Text.Json.Serialization;
using Spoleto.Common.Attributes;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Статус заказа на вызов курьера на забор груза.
    /// </summary>
    /// <remarks>
    /// <see href="https://api-docs.cdek.ru/29948360.html"/>
    /// </remarks>
    [JsonConverter(typeof(JsonEnumValueConverter<PickupStatus>))]
    public enum PickupStatus
    {
        /// <summary>
        /// Принят.
        /// </summary>
        /// <remarks>
        /// Заявка создана в информационной системе СДЭК, но требуются дополнительные валидации.
        /// </remarks>
        [JsonEnumValue("ACCEPTED")]
        [Description("Принят")]
        Accepted,

        /// <summary>
        /// Создан.
        /// </summary>
        /// <remarks>
        /// Заявка создана в информационной системе СДЭК и прошла необходимые валидации.
        /// </remarks>
        [JsonEnumValue("CREATED")]
        [Description("Создан")]
        Created,

        /// <summary>
        /// Отменена.
        /// </summary>
        /// <remarks>
        /// Заявка отменена ИМ после регистрации в системе.
        /// </remarks>
        [JsonEnumValue("REMOVED")]
        [Description("Отменена")]
        Removed,

        /// <summary>
        /// Готова к назначению.
        /// </summary>
        /// <remarks>
        /// Заявка готова к назначению.
        /// </remarks>
        [JsonEnumValue("READY_FOR_APPOINTMENT")]
        [Description("Готова к назначению")]
        ReadyForAppointment,

        /// <summary>
        /// Назначен курьер.
        /// </summary>
        /// <remarks>
        /// По заявке назначен курьер.
        /// </remarks>
        [JsonEnumValue("APPOINTED_COURIER")]
        [Description("Назначен курьер")]
        AppointedCourier,

        /// <summary>
        /// Выполнена.
        /// </summary>
        /// <remarks>
        /// Заявка выполнена.
        /// </remarks>
        [JsonEnumValue("DONE")]
        [Description("Выполнена")]
        Done,

        /// <summary>
        /// Выявлена проблема.
        /// </summary>
        /// <remarks>
        /// По заявке выявлена проблема.
        /// </remarks>
        [JsonEnumValue("PROBLEM_DETECTED")]
        [Description("Выявлена проблема")]
        ProblemDetected,

        /// <summary>
        /// Требует обработки.
        /// </summary>
        /// <remarks>
        /// Заявка создана в информационной системе СДЭК, но требуется дополнительная обработка.
        /// </remarks>
        [JsonEnumValue("PROCESSING_REQUIRED")]
        [Description("Требует обработки")]
        ProcessingRequired,

        /// <summary>
        /// Некорректная заявка.
        /// </summary>
        /// <remarks>
        /// Заявка содержит некорректные данные.
        /// </remarks>
        [JsonEnumValue("INVALID")]
        [Description("Некорректная заявка")]
        Invalid
    }
}
