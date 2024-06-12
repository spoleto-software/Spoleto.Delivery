using System.ComponentModel;
using System.Text.Json.Serialization;
using Spoleto.Common.Attributes;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Способ Оплаты.
    /// </summary>
    [JsonConverter(typeof(JsonEnumValueConverter<PaymentType>))]
    public enum PaymentType
    {
        /// <summary>
        /// Наличными Получатель.
        /// </summary>
        [Description("Наличными Получатель")]
        [JsonEnumValue("Наличными Получатель")]
        CashRecipient,

        /// <summary>
        /// Наличными Отправитель.
        /// </summary>
        [Description("Наличными Отправитель")]
        [JsonEnumValue("Наличными Отправитель")]
        CashSender,

        /// <summary>
        /// По Договору.
        /// </summary>
        [Description("По Договору")]
        [JsonEnumValue("По Договору")]
        ByContract
    }
}
