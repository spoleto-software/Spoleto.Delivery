using Spoleto.AddressResolver;
using Spoleto.Delivery.Providers;

namespace Spoleto.Delivery
{
    /// <summary>
    /// The Delivery service factory used to create an instance of <see cref="DeliveryService"/>.
    /// </summary>
    public class DeliveryServiceFactory
    {
        private readonly DeliveryServiceOptions _options = new();
        private readonly List<IDeliveryProvider> _providers = new();

        /// <summary>
        /// Gets the address resolver to be used in delivery providers.
        /// </summary>
        public IAddressResolver AddressResolver { get; private set; }

        /// <summary>
        /// Sets the options of the Delivery service.
        /// </summary>
        /// <param name="options">The Delivery option initializer.</param>
        /// <returns>The <see cref="DeliveryServiceFactory"/> instance is provided to support method chaining capabilities.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="options"/> is null.</exception>
        public DeliveryServiceFactory WithOptions(Action<DeliveryServiceOptions> options)
        {
            if (options is null)
                throw new ArgumentNullException(nameof(options));

            // set the Delivery options and validate it.
            options(_options);
            _options.Validate();

            return this;
        }

        /// <summary>
        /// Sets the <see cref="IAddressResolver"/> to be used by the delivery providers.
        /// </summary>
        /// <param name="addressResolver">The <see cref="IAddressResolver"/> instance.</param>
        /// <returns>The <see cref="DeliveryServiceFactory"/> instance is provided to support method chaining capabilities.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="addressResolver"/> is null.</exception>
        public DeliveryServiceFactory WithAddressResolver(IAddressResolver addressResolver)
        {
            if (addressResolver is null)
                throw new ArgumentNullException(nameof(addressResolver));

            AddressResolver = addressResolver;

            return this;
        }

        /// <summary>
        /// Adds the <see cref="IDeliveryProvider"/> to be used by the Delivery service.
        /// </summary>
        /// <param name="provider">The <see cref="IDeliveryProvider"/> instance.</param>
        /// <returns>The <see cref="DeliveryServiceFactory"/> instance is provided to support method chaining capabilities.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="provider"/> is null.</exception>
        public DeliveryServiceFactory AddProvider(IDeliveryProvider provider)
        {
            if (provider is null)
                throw new ArgumentNullException(nameof(provider));

            _providers.Add(provider);

            return this;
        }

        /// <summary>
        /// Creates the Delivery service instance.
        /// </summary>
        /// <returns>Instance of <see cref="DeliveryService"/>.</returns>
        public IDeliveryService Build() => new DeliveryService(_providers, _options);
    }
}
