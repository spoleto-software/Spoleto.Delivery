namespace Spoleto.Delivery.Callback.Common.Models
{
    public class DeliveryOrderViewModel
    {
        /// <summary>
        /// Id заказа в ИС Транспортной компании.
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        /// Текущий статус.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Статус является финальным.
        /// </summary>
        public bool StatusIsFinal { get; set; }
    }
}
