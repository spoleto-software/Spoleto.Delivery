namespace Spoleto.Delivery.Providers
{
    /// <summary>
    /// The Delivery provider for delivery of goods.
    /// </summary>
    public interface IDeliveryProvider
    {
        /// <summary>
        /// Gets the Delivery provider unique name.
        /// </summary>
        string Name { get; }
    }
}
