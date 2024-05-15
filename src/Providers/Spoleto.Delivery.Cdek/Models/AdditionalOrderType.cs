using System.Text.Json.Serialization;
using Spoleto.Delivery.Converters;

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
        LTL = 2,

        /// <summary>
        /// Forward
        /// </summary>
        Forward = 4,

        /// <summary>
        /// Фулфилмент. Приход
        /// </summary>
        FulfillmentReceipt = 6,

        /// <summary>
        /// Фулфилмент. Отгрузка
        /// </summary>
        FulfillmentShipment = 7,

        /// <summary>
        /// Доставка шин по тарифу "Экономичный экспресс"
        /// </summary>
        TireEconomyExpressDelivery = 10
    }
}
