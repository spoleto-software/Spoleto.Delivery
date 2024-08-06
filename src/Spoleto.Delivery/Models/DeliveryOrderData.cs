namespace Spoleto.Delivery
{
    /// <summary>
    /// Additional data for specified delivery provider.
    /// </summary>
    public record struct DeliveryOrderData
    {
        public DeliveryOrderData(string name, object value)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Value = value ?? throw new ArgumentNullException(nameof(value));

            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException($"{nameof(Name)} in the {nameof(DeliveryOrderData)} cannot be empty.");
        }

        /// <summary>
        /// Gets the name of the additinal data.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the value of the additinal data.
        /// </summary>
        public object Value { get; }

        /// <summary>
        /// Gets the value
        /// </summary>
        public TValue GetValue<TValue>() => (TValue)Value;
    }
}
