using Spoleto.Delivery.Helpers;

namespace Spoleto.Delivery
{
    public record DeliveryOrderContainer
    {
        public DeliveryOrderContainer(DeliveryOrder? deliveryOrder, string rawBody)
        {
            DeliveryOrder = deliveryOrder;
            RawData = new(rawBody);
        }

        public DeliveryOrder? DeliveryOrder { get; }

        /// <summary>
        /// Исходные ответы основного заказа и его связанных заказов в Json/Xml.
        /// </summary>
        public DeliveryOrderRawData RawData { get; }

        public void AddRelatedOrder(string type, string rawBody)
        {
            RawData.RelatedOrders ??= [];
            RawData.RelatedOrders.Add(new() { Type = type, RawBody = rawBody });
        }

        public void RemoveRelatedOrder(string type)
        {
            if (RawData.RelatedOrders == null)
            {
                return;
            }

            RawData.RelatedOrders.RemoveAll(x => x.Type == type);

            if (RawData.RelatedOrders.Count == 0)
            {
                RawData.RelatedOrders = null;
            }
        }

        public void ClearRelatedOrders()
        {
            if (RawData.RelatedOrders == null)
            {
                return;
            }

            RawData.RelatedOrders = null;
        }

        /// <summary>
        /// Returns the order raw body with related orders raw bodies.
        /// </summary>
        public string GetFullRawBody() => JsonHelper.ToRelaxedIndentedJson(RawData);
    }
}
