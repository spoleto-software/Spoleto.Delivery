using System.ComponentModel;

namespace Spoleto.Delivery
{
    /// <summary>
    /// Вид пакета.
    /// </summary>
    public enum PackageType
    {
        /// <summary>
        /// Документ
        /// </summary>
        [Description("Документ")]
        Document,

        /// <summary>
        /// Груз
        /// </summary>
        [Description("Груз")]
        Cargo,

        /// <summary>
        /// Ценный груз
        /// </summary>
        [Description("Ценный груз")]
        ValuableCargo,

        /// <summary>
        /// Опасный груз
        /// </summary>
        [Description("Опасный груз")]
        DangerousCargo
    }
}
