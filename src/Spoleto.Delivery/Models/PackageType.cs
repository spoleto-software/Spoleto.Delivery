namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Вид пакета.
    /// </summary>
    public enum PackageType
    {
        /// <summary>
        /// Документ
        /// </summary>
        Document,

        /// <summary>
        /// Груз
        /// </summary>
        Cargo,

        /// <summary>
        /// Ценный груз
        /// </summary>
        ValuableCargo,

        /// <summary>
        /// Опасный груз
        /// </summary>
        DangerousCargo
    }
}
