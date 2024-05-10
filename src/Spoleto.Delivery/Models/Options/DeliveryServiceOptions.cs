
namespace Spoleto.Delivery
{
    /// <summary>
    /// The options for configuring the Delivery service
    /// </summary>
    public record DeliveryServiceOptions
    {
        /// <summary>
        /// Gets or sets the name of the default Delivery provider.
        /// </summary>
        public string DefaultProvider { get; set; }

        /// <summary>
        /// Checks that all the settings within the options are configured properly.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when <see cref="DefaultProvider"/> is not specified.</exception>
        public void Validate()
        {
            if (String.IsNullOrWhiteSpace(DefaultProvider))
                throw new ArgumentException("You have to specify a valid Delivery provider to be used as the default.", nameof(DefaultProvider));
        }
    }
}
