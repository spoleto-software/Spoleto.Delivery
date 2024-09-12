namespace Spoleto.Delivery
{
    /// <summary>
    /// Тип офиса, склада, пункта выдачи.
    /// </summary>
    public enum DeliveryPointType
    {
        /// <summary>
        /// Все ПВЗ независимо от их типа.
        /// </summary>
        All,

        /// <summary>
        /// Склады (пункты выдачи заказов).
        /// </summary>
        Pvz,


        /// <summary>
        /// Постаматы.
        /// </summary>
        Postamat
    }
}
