using System.ComponentModel;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Статус квитанции.
    /// </summary>
    /// <remarks>
    /// <see href="https://apidoc.cdek.ru/#tag/Pechatnaya-forma-nakladnoj-i-ShK/operation/waybillGet"/>
    /// </remarks>
    public enum PrintingOrderStatusCode
    {
        /// <summary>
        /// Принят.
        /// </summary>
        /// <remarks>
        /// Запрос на формирование квитанции принят.
        /// </remarks>
        [Description("Принят")]
        ACCEPTED,

        /// <summary>
        /// Некорректный запрос.
        /// </summary>
        /// <remarks>
        /// Некорректный запрос на формирование квитанции.
        /// </remarks>
        [Description("Некорректный запрос")]
        INVALID,

        /// <summary>
        /// Формируется.
        /// </summary>
        /// <remarks>
        /// Файл с квитанцией формируется.
        /// </remarks>
        [Description("Формируется")]
        PROCESSING,

        /// <summary>
        /// Сформирован.
        /// </summary>
        /// <remarks>
        /// Файл с квитанцией и ссылка на скачивание файла сформированы.
        /// </remarks>
        [Description("Сформирован")]
        READY,

        /// <summary>
        /// Удален.
        /// </summary>
        /// <remarks>
        /// Истекло время жизни ссылки на скачивание файла с квитанцией.
        /// </remarks>
        [Description("Удален")]
        REMOVED
    }
}
