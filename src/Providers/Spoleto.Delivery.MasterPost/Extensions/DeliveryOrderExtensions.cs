namespace Spoleto.Delivery.Providers.MasterPost
{
    internal static class DeliveryOrderExtensions
    {
        /// <summary>
        /// Получить ссылку для отслеживания статуса заказа.
        /// </summary>
        public static string GetTrackUrl(this DeliveryOrder deliveryOrder, string serviceUrl)
        {
            const string trackPath = "/mp_api/hs/api/v1/tracking?dn=";
            var baseUrl = GetBaseUrl(serviceUrl);

            return $"{baseUrl}{trackPath}{deliveryOrder.Number}";
        }

        private static string GetBaseUrl(string fullUri)
        {
            var uri = new Uri(fullUri);
            var baseUrl = $"{uri.Scheme}://{uri.Host}";
            if (!uri.IsDefaultPort)
            {
                baseUrl += $":{uri.Port}";
            }

            return baseUrl;
        }
    }
}
