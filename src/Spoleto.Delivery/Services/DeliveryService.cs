using System.Collections.Specialized;
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

        #region Cities
        /// <inheritdoc/>
        public List<City> GetCities(CityRequest cityRequest)
            => GetCities(_defaultProvider, cityRequest);

        /// <inheritdoc/>
        public List<City> GetCities(string providerName, CityRequest cityRequest)
        {
            if (providerName is null)
                throw new ArgumentNullException(nameof(providerName));

            if (!TryGetDeliveryProvider(providerName, out var provider))
                throw new DeliveryProviderNotFoundException(providerName);

            return GetCities(provider, cityRequest);
        }

        /// <inheritdoc/>
        public List<City> GetCities(DeliveryProviderName providerName, CityRequest cityRequest)
            => GetCities(providerName.ToString(), cityRequest);

        /// <inheritdoc/>
        public List<City> GetCities(IDeliveryProvider provider, CityRequest cityRequest)
        {
            if (provider is null)
                throw new ArgumentNullException(nameof(provider));

            if (cityRequest is null)
                throw new ArgumentNullException(nameof(cityRequest));

            return provider.GetCities(cityRequest);
        }

        /// <inheritdoc/>
        public Task<List<City>> GetCitiesAsync(CityRequest cityRequest)
            => GetCitiesAsync(_defaultProvider, cityRequest);

        /// <inheritdoc/>
        public Task<List<City>> GetCitiesAsync(string providerName, CityRequest cityRequest)
        {
            if (providerName is null)
                throw new ArgumentNullException(nameof(providerName));

            if (!TryGetDeliveryProvider(providerName, out var provider))
                throw new DeliveryProviderNotFoundException(providerName);

            return GetCitiesAsync(provider, cityRequest);
        }

        /// <inheritdoc/>
        public Task<List<City>> GetCitiesAsync(DeliveryProviderName providerName, CityRequest cityRequest)
            => GetCitiesAsync(providerName.ToString(), cityRequest);

        /// <inheritdoc/>
        public Task<List<City>> GetCitiesAsync(IDeliveryProvider provider, CityRequest cityRequest)
        {
            if (provider is null)
                throw new ArgumentNullException(nameof(provider));

            if (cityRequest is null)
                throw new ArgumentNullException(nameof(cityRequest));

            return provider.GetCitiesAsync(cityRequest);
        }
        #endregion

        #region Tariffs
        /// <inheritdoc/>
        public List<Tariff> GetTariffs(TariffRequest tariffRequest)
            => GetTariffs(_defaultProvider, tariffRequest);

        /// <inheritdoc/>
        public List<Tariff> GetTariffs(string providerName, TariffRequest tariffRequest)
        {
            if (providerName is null)
                throw new ArgumentNullException(nameof(providerName));

            if (!TryGetDeliveryProvider(providerName, out var provider))
                throw new DeliveryProviderNotFoundException(providerName);

            return GetTariffs(provider, tariffRequest);
        }

        /// <inheritdoc/>
        public List<Tariff> GetTariffs(DeliveryProviderName providerName, TariffRequest tariffRequest)
            => GetTariffs(providerName.ToString(), tariffRequest);

        /// <inheritdoc/>
        public List<Tariff> GetTariffs(IDeliveryProvider provider, TariffRequest tariffRequest)
        {
            if (provider is null)
                throw new ArgumentNullException(nameof(provider));

            if (tariffRequest is null)
                throw new ArgumentNullException(nameof(tariffRequest));

            return provider.GetTariffs(tariffRequest);
        }

        /// <inheritdoc/>
        public Task<List<Tariff>> GetTariffsAsync(TariffRequest tariffRequest)
            => GetTariffsAsync(_defaultProvider, tariffRequest);

        /// <inheritdoc/>
        public Task<List<Tariff>> GetTariffsAsync(string providerName, TariffRequest tariffRequest)
        {
            if (providerName is null)
                throw new ArgumentNullException(nameof(providerName));

            if (!TryGetDeliveryProvider(providerName, out var provider))
                throw new DeliveryProviderNotFoundException(providerName);

            return GetTariffsAsync(provider, tariffRequest);
        }

        /// <inheritdoc/>
        public Task<List<Tariff>> GetTariffsAsync(DeliveryProviderName providerName, TariffRequest tariffRequest)
            => GetTariffsAsync(providerName.ToString(), tariffRequest);

        /// <inheritdoc/>
        public Task<List<Tariff>> GetTariffsAsync(IDeliveryProvider provider, TariffRequest tariffRequest)
        {
            if (provider is null)
                throw new ArgumentNullException(nameof(provider));

            if (tariffRequest is null)
                throw new ArgumentNullException(nameof(tariffRequest));

            return provider.GetTariffsAsync(tariffRequest);
        }
        #endregion

        #region DeliveryOrder
        /// <inheritdoc/>
        public DeliveryOrder CreateDeliveryOrder(DeliveryOrderRequest deliveryOrderRequest)
            => CreateDeliveryOrder(_defaultProvider, deliveryOrderRequest);

        /// <inheritdoc/>
        public DeliveryOrder CreateDeliveryOrder(string providerName, DeliveryOrderRequest deliveryOrderRequest)
        {
            if (providerName is null)
                throw new ArgumentNullException(nameof(providerName));

            if (!TryGetDeliveryProvider(providerName, out var provider))
                throw new DeliveryProviderNotFoundException(providerName);

            return CreateDeliveryOrder(provider, deliveryOrderRequest);
        }

        /// <inheritdoc/>
        public DeliveryOrder CreateDeliveryOrder(DeliveryProviderName providerName, DeliveryOrderRequest deliveryOrderRequest)
            => CreateDeliveryOrder(providerName.ToString(), deliveryOrderRequest);

        /// <inheritdoc/>
        public DeliveryOrder CreateDeliveryOrder(IDeliveryProvider provider, DeliveryOrderRequest deliveryOrderRequest)
        {
            if (provider is null)
                throw new ArgumentNullException(nameof(provider));

            if (deliveryOrderRequest is null)
                throw new ArgumentNullException(nameof(deliveryOrderRequest));

            return provider.CreateDeliveryOrder(deliveryOrderRequest);
        }

        /// <inheritdoc/>
        public Task<DeliveryOrder> CreateDeliveryOrderAsync(DeliveryOrderRequest deliveryOrderRequest)
            => CreateDeliveryOrderAsync(_defaultProvider, deliveryOrderRequest);

        /// <inheritdoc/>
        public Task<DeliveryOrder> CreateDeliveryOrderAsync(string providerName, DeliveryOrderRequest deliveryOrderRequest)
        {
            if (providerName is null)
                throw new ArgumentNullException(nameof(providerName));

            if (!TryGetDeliveryProvider(providerName, out var provider))
                throw new DeliveryProviderNotFoundException(providerName);

            return CreateDeliveryOrderAsync(provider, deliveryOrderRequest);
        }

        /// <inheritdoc/>
        public Task<DeliveryOrder> CreateDeliveryOrderAsync(DeliveryProviderName providerName, DeliveryOrderRequest deliveryOrderRequest)
            => CreateDeliveryOrderAsync(providerName.ToString(), deliveryOrderRequest);

        /// <inheritdoc/>
        public Task<DeliveryOrder> CreateDeliveryOrderAsync(IDeliveryProvider provider, DeliveryOrderRequest deliveryOrderRequest)
        {
            if (provider is null)
                throw new ArgumentNullException(nameof(provider));

            if (deliveryOrderRequest is null)
                throw new ArgumentNullException(nameof(deliveryOrderRequest));

            return provider.CreateDeliveryOrderAsync(deliveryOrderRequest);
        }
        #endregion

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
