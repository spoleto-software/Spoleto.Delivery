namespace Spoleto.Delivery.Providers.Cdek
{
    internal static class DeliveryOrderExtensions
    {
        /// <summary>
        /// Получить ссылку для отслеживания статуса заказа.
        /// </summary>
        public static string GetTrackUrl(this DeliveryOrder deliveryOrder)
        {
            const string trackUrl = "https://www.cdek.ru/ru/tracking?order_id=";

            return $"{trackUrl}{deliveryOrder.Entity.CdekNumber}";
        }
    }
}
