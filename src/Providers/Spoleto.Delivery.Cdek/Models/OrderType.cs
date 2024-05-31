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
        OnlineStore = 1,

        /// <summary>
        /// Обычная доставка.
        /// </summary>
        RegularDelivery = 2
    }
}
