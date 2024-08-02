using System.ComponentModel;
using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Причина недозвона
    /// </summary>
    [JsonConverter(typeof(JsonIntEnumConverter<FailedCallReason>))]
    public enum FailedCallReason
    {
        /// <summary>
        /// Телефон занят
        /// </summary>
        [Description("Телефон занят")]
        LineBusy = 1,

        /// <summary>
        /// Абонент не берет трубку
        /// </summary>
        [Description("Абонент не берет трубку")]
        NoAnswer = 2,

        /// <summary>
        /// Абонент недоступен
        /// </summary>
        [Description("Абонент недоступен")]
        SubscriberUnavailable = 3,

        /// <summary>
        /// Неверный номер
        /// </summary>
        [Description("Неверный номер")]
        InvalidNumber = 4,

        /// <summary>
        /// Телефон не указан
        /// </summary>
        [Description("Телефон не указан")]
        NoPhoneNumber = 5,

        /// <summary>
        /// «Тишина»
        /// </summary>
        [Description("«Тишина»")]
        Silence = 6,

        /// <summary>
        /// Сброс
        /// </summary>
        [Description("Сброс")]
        CallDropped = 7,

        /// <summary>
        /// Бросил трубку
        /// </summary>
        [Description("Бросил трубку")]
        HungUp = 8
    }
}
