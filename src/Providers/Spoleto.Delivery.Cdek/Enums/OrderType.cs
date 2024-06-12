using System.ComponentModel;
using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Тип заказа.
    /// </summary>
    /// <remarks>
    /// <see href="https://api-docs.cdek.ru/63345519.html"/>
    /// </remarks>
    [JsonConverter(typeof(JsonIntEnumConverter<OrderType>))]
    public enum OrderType
    {
        /// <summary>
        /// Интернет-магазин.
        /// </summary>
        [Description("Интернет-магазин")]
        OnlineStore = 1,

        /// <summary>
        /// Обычная доставка.
        /// </summary>
        [Description("Обычная доставка")]
        RegularDelivery = 2
    }
}
