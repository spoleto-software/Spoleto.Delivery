using System.ComponentModel;

namespace Spoleto.Delivery
{
    /// <summary>
    /// The delivery order type.
    /// </summary>
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