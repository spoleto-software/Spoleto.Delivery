using System.ComponentModel;
using Spoleto.Common.JsonConverters;
using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Режимы (типы) доставки.
    /// </summary>
    [JsonConverter(typeof(JsonIntEnumConverter<DeliveryMode>))]
    public enum DeliveryMode
    {
        /// <summary>
        /// Дверь-дверь
        /// </summary>
        [Description("Дверь-дверь")]
        DoorDoor = 1,

        /// <summary>
        /// Дверь-склад
        /// </summary>
        [Description("Дверь-склад")]
        DoorWarehouse = 2,

        /// <summary>
        /// Склад-дверь
        /// </summary>
        [Description("Склад-дверь")]
        WarehouseDoor = 3,

        /// <summary>
        /// Склад-склад
        /// </summary>
        [Description("Склад-склад")]
        WarehouseWarehouse = 4,

        /// <summary>
        /// Дверь-постамат
        /// </summary>
        [Description("Дверь-постамат")]
        DoorPostamat = 6,

        /// <summary>
        /// Склад-постамат
        /// </summary>
        [Description("Склад-постамат")]
        WarehousePostamat = 7,

        /// <summary>
        /// Постамат-дверь
        /// </summary>
        [Description("Постамат-дверь")]
        PostamatDoor = 8,

        /// <summary>
        /// Постамат-склад
        /// </summary>
        [Description("Постамат-склад")]
        PostamatWarehouse = 9,

        /// <summary>
        /// Постамат-постамат
        /// </summary>
        [Description("Постамат-постамат")]
        PostamatPostamat = 10
    }
}
