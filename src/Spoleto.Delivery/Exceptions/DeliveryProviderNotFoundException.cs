namespace Spoleto.Delivery
{
    /// <summary>
    /// The exception thrown when no Delivery provider has been found.
    /// </summary>
    [Serializable]
    public class DeliveryProviderNotFoundException : Exception
    {
        private static readonly string _exceptionMessage = $"There is no Delivery provider with the name <{{0}}>.{Environment.NewLine}Make sure you have registered this provider in the Delivery service.";

        /// <summary>
        /// Gets the Delivery provider name.
        /// </summary>
        public string DeliveryProviderName { get; }

        /// <inheritdoc/>
        public DeliveryProviderNotFoundException(string providerName)
            : this(string.Format(_exceptionMessage, providerName), providerName) { }

        /// <inheritdoc/>
        public DeliveryProviderNotFoundException(string message, string providerName)
            : base(message)
        {
            DeliveryProviderName = providerName;
        }
    }
}
