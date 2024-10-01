namespace Spoleto.Delivery.Callback.Cdek.Models
{
    /// <summary>
    /// Тип события.
    /// </summary>
    public enum CdekWebhookMessageType
    {
        /// <summary>
        /// Изменение статуса заказа.
        /// </summary>
        ORDER_STATUS,

        /// <summary>
        /// Готовность печатной формы.
        /// </summary>
        PRINT_FORM,

        /// <summary>
        /// Получение фото документов по заказам.
        /// </summary>
        DOWNLOAD_PHOTO,

        /// <summary>
        /// Получение информации о закрытии преалерта.
        /// </summary>
        PREALERT_CLOSED,

        /// <summary>
        /// Получение информации о транспорте для СНТ.
        /// </summary>
        ACCOMPANYING_WAYBILL,

        /// <summary>
        /// Получение информации об изменении доступности офиса.
        /// </summary>
        OFFICE_AVAILABILITY,

        /// <summary>
        /// Получение информации об изменении заказа.
        /// </summary>
        ORDER_MODIFIED
    }
}

