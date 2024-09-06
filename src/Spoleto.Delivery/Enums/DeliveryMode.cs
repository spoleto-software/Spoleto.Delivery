using System.ComponentModel;

namespace Spoleto.Delivery
{
    /// <summary>
    /// Режимы (типы) доставки.
    /// </summary>
    public enum DeliveryMode
    {
        /// <summary>
        /// Дверь-дверь
        /// </summary>
        [Description("Дверь-дверь")]
        DoorToDoor = 1,

        /// <summary>
        /// Дверь-склад
        /// </summary>
        [Description("Дверь-склад")]
        DoorToWarehouse = 2,

        /// <summary>
        /// Склад-дверь
        /// </summary>
        [Description("Склад-дверь")]
        WarehouseToDoor = 3,

        /// <summary>
        /// Склад-склад
        /// </summary>
        [Description("Склад-склад")]
        WarehouseToWarehouse = 4,

        /// <summary>
        /// Дверь-постамат
        /// </summary>
        [Description("Дверь-постамат")]
        DoorToPostamat = 6,

        /// <summary>
        /// Склад-постамат
        /// </summary>
        [Description("Склад-постамат")]
        WarehouseToPostamat = 7,

        /// <summary>
        /// Постамат-дверь
        /// </summary>
        [Description("Постамат-дверь")]
        PostamatToDoor = 8,

        /// <summary>
        /// Постамат-склад
        /// </summary>
        [Description("Постамат-склад")]
        PostamatToWarehouse = 9,

        /// <summary>
        /// Постамат-постамат
        /// </summary>
        [Description("Постамат-постамат")]
        PostamatToPostamat = 10
    }
}
