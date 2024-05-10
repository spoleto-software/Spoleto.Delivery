using System.Collections.Specialized;
using Spoleto.Delivery.Exceptions;
using Spoleto.Delivery.Providers;

namespace Spoleto.Delivery.Services
{
    /// <summary>
    /// The Delivery service serves as an abstraction layer for delivery of goods.
    /// </summary>
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryProvider _defaultProvider;
        private readonly OrderedDictionary _providers;

        /// <summary>
        /// The constructor with parameters.
        /// </summary>
        /// <param name="providers">The list of supported Delivery providers.</param>
        /// <param name="options">The Delivery service options.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="providers"/> or <paramref name="options"/> are null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="providers"/> is empty.</exception>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the default Delivery provider cannot be found.</exception>
        public DeliveryService(IEnumerable<IDeliveryProvider> providers, DeliveryServiceOptions options)
        {
            if (providers is null)
                throw new ArgumentNullException(nameof(providers));

            if (!providers.Any())
                throw new ArgumentException("You have to specify at least one Delivery provider, the Delivery provider list is empty.", nameof(providers));

            if (options is null)
                throw new ArgumentNullException(nameof(options));

            // Validates if the options are valid:
            options.Validate();

            Options = options;

            // Inits the providers dictionary:
            _providers = new OrderedDictionary(providers.Count());
            foreach (var provider in providers)
            {
                _providers.Add(provider.Name, provider);
            }

            // Checks if the default Delivery provider exist:
            if (!TryGetDeliveryProvider(options.DefaultProvider, out var value))
                throw new DeliveryProviderNotFoundException(options.DefaultProvider);

            // Sets the default provider:
            _defaultProvider = value;
        }

        /// <summary>
        /// Gets the Delivery service options instance
        /// </summary>
        public DeliveryServiceOptions Options { get; }

        /// <summary>
        /// Gets the list of Delivery providers attached to this Delivery service.
        /// </summary>
        public IEnumerable<IDeliveryProvider> Providers
        {
            get
            {
                foreach (IDeliveryProvider provider in _providers.Values)
                    yield return provider;
            }
        }

        /// <summary>
        /// Gets the default Delivery provider attached to this Delivery service.
        /// </summary>
        public IDeliveryProvider DefaultProvider => _defaultProvider;

        private bool TryGetDeliveryProvider(string providerName, out IDeliveryProvider deliveryProvider)
        {
            if (_providers[providerName] is not IDeliveryProvider provider)
            {
                deliveryProvider = null;
                return false;
            }

            deliveryProvider = provider;
            return true;
        }
    }
}
