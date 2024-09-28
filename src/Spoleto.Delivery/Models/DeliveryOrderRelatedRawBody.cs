namespace Spoleto.Delivery
{
    /// <summary>
    /// Связанные заказы (например, заказ на вызов курьера) для заказа на доставку.
    /// </summary>
    public record DeliveryOrderRelatedRawBody
    {
        /// <summary>
        /// Получает или задает тип связанного заказа.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Исходный ответ в Json/Xml.
        /// </summary>
        public string RawBody { get; set; }
    }
}
