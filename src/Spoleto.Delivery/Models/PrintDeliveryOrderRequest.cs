namespace Spoleto.Delivery
{
    /// <summary>
    /// The delivery order request to print.
    /// </summary>
    public record PrintDeliveryOrderRequest
    {
        /// <summary>
        /// Gets or sets delivery orders.
        /// </summary>
        public List<PrintDeliveryOrder> DeliveryOrders { get; set; } = [];

        /// <summary>
        /// Gets the additional order data.
        /// </summary>
        public List<DeliveryOrderData> AdditionalProviderData { get; } = [];

        /// <summary>
        /// Adds the additional data to print a delivery order.
        /// </summary>
        public PrintDeliveryOrderRequest WithProviderData(string name, object value)
        {
            AdditionalProviderData.Add(new(name, value));

            return this;
        }
    }
}
