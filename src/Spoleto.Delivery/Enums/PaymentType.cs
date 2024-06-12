using System.ComponentModel;

namespace Spoleto.Delivery
{
    /// <summary>
    /// Способ Оплаты.
    /// </summary>
    public enum PaymentType
    {
        /// <summary>
        /// Наличными Получатель.
        /// </summary>
        [Description("Наличными Получатель")]
        CashRecipient,

        /// <summary>
        /// Наличными Отправитель.
        /// </summary>
        [Description("Наличными Отправитель")]
        CashSender,

        /// <summary>
        /// По Договору.
        /// </summary>
        [Description("По Договору")]
        ByContract
    }
}
