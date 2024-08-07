namespace Spoleto.Delivery.Providers.Cdek
{
    internal static class DeliveryOrderExtensions
    {
        /// <summary>
        /// Получить ссылку для отслеживания статуса заказа.
        /// </summary>
        public static string GetTrackUrl(this DeliveryOrder deliveryOrder)
        {
            const string trackPath = "/ru/tracking?order_id=";
            var baseUrl = GetBaseUrl();

            return $"{baseUrl}{trackPath}{deliveryOrder.Entity.CdekNumber}";
        }

        private static string GetBaseUrl()
        {
            return "https://www.cdek.ru";
        }
    }
}
