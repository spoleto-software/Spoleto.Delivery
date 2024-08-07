namespace Spoleto.Delivery.Providers.MasterPost
{
    internal static class DeliveryOrderExtensions
    {
        /// <summary>
        /// Получить ссылку для отслеживания статуса заказа.
        /// </summary>
        public static string GetTrackUrl(this DeliveryOrder deliveryOrder)
        {
            //const string trackUrl = "https://mplogistics.ru/delivery-monitoring?invoice=";

            return null;// $"{trackUrl}{deliveryOrder.Number}";
        }
    }
}
