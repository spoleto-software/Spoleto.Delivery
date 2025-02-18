using System.ComponentModel;
using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Дополнительный тип заказа.
    /// </summary>
    /// <remarks>
    /// <see href="https://api-docs.cdek.ru/63345519.html"/>
    /// </remarks>
    [JsonConverter(typeof(JsonIntEnumConverter<AdditionalOrderType>))]
    public enum AdditionalOrderType
    {
        /// <summary>
        /// Сборный груз (LTL)
        /// </summary>
        [Description("Сборный груз (LTL)")]
        LTL = 2,

        /// <summary>
        /// Форвард (Forward)
        /// </summary>
        [Description("Форвард (Forward)")]
        Forward = 4,

        /// <summary>
        /// Форвард. Экспресс (Forward. Express)
        /// </summary>
        [Description("Форвард. Экспресс (Forward. Express)")]
        ForwardExpress = 9,

        /// <summary>
        /// Фулфилмент. Приход
        /// </summary>
        [Description("Фулфилмент. Приход")]
        FulfillmentReceipt = 6,

        /// <summary>
        /// Фулфилмент. Отгрузка
        /// </summary>
        [Description("Фулфилмент. Отгрузка")]
        FulfillmentShipment = 7,

        /// <summary>
        /// Доставка шин по тарифу "Экономичный экспресс"
        /// </summary>
        [Description("Доставка шин по тарифу \"Экономичный экспресс\"")]
        TireEconomyExpressDelivery = 10,

        /// <summary>
        /// Доставка в рамках одного офиса "Один офис (ИМ)" (при условии, что офис отправителя и получателя совпадают)
        /// </summary>
        [Description("Доставка в рамках одного офиса \"Один офис (ИМ)\" (при условии, что офис отправителя и получателя совпадают)")]
        OneOffice = 11,

        /// <summary>
        /// CDEK.Shopping
        /// </summary>
        [Description("CDEK.Shopping")]
        CdekShopping = 14
    }
}
