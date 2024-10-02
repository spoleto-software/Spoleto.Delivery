using System.ComponentModel;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Статус заказа на вызов курьера на забор груза.
    /// </summary>
    /// <remarks>
    /// <see href="https://api-docs.cdek.ru/29948360.html"/>
    /// </remarks>
    public enum PickupStatus
    {
        /// <summary>
        /// Принят.
        /// </summary>
        /// <remarks>
        /// Заявка создана в информационной системе СДЭК, но требуются дополнительные валидации.
        /// </remarks>
        [Description("Принят")]
        ACCEPTED,

        /// <summary>
        /// Создан.
        /// </summary>
        /// <remarks>
        /// Заявка создана в информационной системе СДЭК и прошла необходимые валидации.
        /// </remarks>
        [Description("Создан")]
        CREATED,

        /// <summary>
        /// Отменена.
        /// </summary>
        /// <remarks>
        /// Заявка отменена ИМ после регистрации в системе.
        /// </remarks>
        [Description("Отменена")]
        REMOVED,

        /// <summary>
        /// Готова к назначению.
        /// </summary>
        /// <remarks>
        /// Заявка готова к назначению.
        /// </remarks>
        [Description("Готова к назначению")]
        READY_FOR_APPOINTMENT,

        /// <summary>
        /// Назначен курьер.
        /// </summary>
        /// <remarks>
        /// По заявке назначен курьер.
        /// </remarks>
        [Description("Назначен курьер")]
        APPOINTED_COURIER,

        /// <summary>
        /// Выполнена.
        /// </summary>
        /// <remarks>
        /// Заявка выполнена.
        /// </remarks>
        [Description("Выполнена")]
        DONE,

        /// <summary>
        /// Выявлена проблема.
        /// </summary>
        /// <remarks>
        /// По заявке выявлена проблема.
        /// </remarks>
        [Description("Выявлена проблема")]
        PROBLEM_DETECTED,

        /// <summary>
        /// Требует обработки.
        /// </summary>
        /// <remarks>
        /// Заявка создана в информационной системе СДЭК, но требуется дополнительная обработка.
        /// </remarks>
        [Description("Требует обработки")]
        PROCESSING_REQUIRED,

        /// <summary>
        /// Некорректная заявка.
        /// </summary>
        /// <remarks>
        /// Заявка содержит некорректные данные.
        /// </remarks>
        [Description("Некорректная заявка")]
        INVALID
    }
}
