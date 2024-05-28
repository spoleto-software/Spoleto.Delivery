namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Вид вложимого.
    /// </summary>
    internal enum CargoPlaceType
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
