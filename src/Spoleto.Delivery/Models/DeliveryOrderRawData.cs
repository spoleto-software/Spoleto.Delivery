namespace Spoleto.Delivery
{
    /// <summary>
    /// Структура для всех исходных ответов на запросы на создание заказов на доставку вместе с его связанными заказами (например, заказ на вызов курьера).
    /// </summary>
    public record DeliveryOrderRawData
    {
        public DeliveryOrderRawData(string deliveryOrder)
        {
            DeliveryOrder = deliveryOrder;
        }

        /// <summary>
        /// Исходный ответ заказа в Json/Xml.
        /// </summary>
        public string DeliveryOrder { get; }

        /// <summary>
        /// Исходные ответы связанных заказов в Json/Xml.
        /// </summary>
        public List<DeliveryOrderRelatedRawBody>? RelatedOrders { get; set; }
    }
}
