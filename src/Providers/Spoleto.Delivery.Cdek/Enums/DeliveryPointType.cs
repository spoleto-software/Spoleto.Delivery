using System.ComponentModel;
using System.Text.Json.Serialization;
using Spoleto.Common.Attributes;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Тип офиса, склада, пункта выдачи.
    /// </summary>
    [JsonConverter(typeof(JsonEnumValueConverter<DeliveryPointType>))]
    public enum DeliveryPointType
    {
        /// <summary>
        /// Все ПВЗ независимо от их типа.
        /// </summary>
        [Description("Все ПВЗ")]
        [JsonEnumValue("ALL")]
        All,

        /// <summary>
        /// Склады (пункты выдачи заказов).
        /// </summary>
        [Description("Склад")]
        [JsonEnumValue("PVZ")]
        Pvz,

        /// <summary>
        /// Постаматы.
        /// </summary>
        [Description("Постамат")]
        [JsonEnumValue("POSTAMAT")]
        Postamat
    }
}
