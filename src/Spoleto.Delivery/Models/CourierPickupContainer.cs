namespace Spoleto.Delivery
{
    /// <summary>
    /// The courier pickup order with its raw body.
    /// </summary>
    public record CourierPickupContainer
    {
        public CourierPickupContainer(CourierPickup? courierPickup, string rawBody)
        {
            CourierPickup = courierPickup;
            RawBody = rawBody;
        }

        /// <summary>
        /// Получает или задает заявку на вызов курьера.
        /// </summary>
        public CourierPickup? CourierPickup { get; }

        /// <summary>
        /// Исходный ответ в Json/Xml.
        /// </summary>
        public string RawBody { get; }
    }
}
