using System.Collections.Specialized;
using Spoleto.Delivery.Providers;

namespace Spoleto.Delivery
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

        #region Additional services
        /// <inheritdoc/>
        public List<AdditionalService> GetAdditionalServices(Tariff tariff)
            => GetAdditionalServices(_defaultProvider, tariff);

        /// <inheritdoc/>
        public List<AdditionalService> GetAdditionalServices(string providerName, Tariff tariff)
        {
            if (providerName is null)
                throw new ArgumentNullException(nameof(providerName));

            if (!TryGetDeliveryProvider(providerName, out var provider))
                throw new DeliveryProviderNotFoundException(providerName);

            return GetAdditionalServices(provider, tariff);
        }

        /// <inheritdoc/>
        public List<AdditionalService> GetAdditionalServices(DeliveryProviderName providerName, Tariff tariff)
            => GetAdditionalServices(providerName.ToString(), tariff);

        /// <inheritdoc/>
        public List<AdditionalService> GetAdditionalServices(IDeliveryProvider provider, Tariff tariff)
        {
            if (provider is null)
                throw new ArgumentNullException(nameof(provider));

            if (tariff is null)
                throw new ArgumentNullException(nameof(tariff));

            return provider.GetAdditionalServices(tariff);
        }

        /// <inheritdoc/>
        public Task<List<AdditionalService>> GetAdditionalServicesAsync(Tariff tariff)
            => GetAdditionalServicesAsync(_defaultProvider, tariff);

        /// <inheritdoc/>
        public Task<List<AdditionalService>> GetAdditionalServicesAsync(string providerName, Tariff tariff)
        {
            if (providerName is null)
                throw new ArgumentNullException(nameof(providerName));

            if (!TryGetDeliveryProvider(providerName, out var provider))
                throw new DeliveryProviderNotFoundException(providerName);

            return GetAdditionalServicesAsync(provider, tariff);
        }

        /// <inheritdoc/>
        public Task<List<AdditionalService>> GetAdditionalServicesAsync(DeliveryProviderName providerName, Tariff tariff)
            => GetAdditionalServicesAsync(providerName.ToString(), tariff);

        /// <inheritdoc/>
        public Task<List<AdditionalService>> GetAdditionalServicesAsync(IDeliveryProvider provider, Tariff tariff)
        {
            if (provider is null)
                throw new ArgumentNullException(nameof(provider));

            if (tariff is null)
                throw new ArgumentNullException(nameof(tariff));

            return provider.GetAdditionalServicesAsync(tariff);
        }
        #endregion

        #region DeliveryOrder
        /// <inheritdoc/>
        public DeliveryOrder CreateDeliveryOrder(CreateDeliveryOrderRequest deliveryOrderRequest)
            => CreateDeliveryOrder(_defaultProvider, deliveryOrderRequest);

        /// <inheritdoc/>
        public DeliveryOrder CreateDeliveryOrder(string providerName, CreateDeliveryOrderRequest deliveryOrderRequest)
        {
            if (providerName is null)
                throw new ArgumentNullException(nameof(providerName));

            if (!TryGetDeliveryProvider(providerName, out var provider))
                throw new DeliveryProviderNotFoundException(providerName);

            return CreateDeliveryOrder(provider, deliveryOrderRequest);
        }

        /// <inheritdoc/>
        public DeliveryOrder CreateDeliveryOrder(DeliveryProviderName providerName, CreateDeliveryOrderRequest deliveryOrderRequest)
            => CreateDeliveryOrder(providerName.ToString(), deliveryOrderRequest);

        /// <inheritdoc/>
        public DeliveryOrder CreateDeliveryOrder(IDeliveryProvider provider, CreateDeliveryOrderRequest deliveryOrderRequest)
        {
            if (provider is null)
                throw new ArgumentNullException(nameof(provider));

            if (deliveryOrderRequest is null)
                throw new ArgumentNullException(nameof(deliveryOrderRequest));

            return provider.CreateDeliveryOrder(deliveryOrderRequest);
        }

        /// <inheritdoc/>
        public Task<DeliveryOrder> CreateDeliveryOrderAsync(CreateDeliveryOrderRequest deliveryOrderRequest)
            => CreateDeliveryOrderAsync(_defaultProvider, deliveryOrderRequest);

        /// <inheritdoc/>
        public Task<DeliveryOrder> CreateDeliveryOrderAsync(string providerName, CreateDeliveryOrderRequest deliveryOrderRequest)
        {
            if (providerName is null)
                throw new ArgumentNullException(nameof(providerName));

            if (!TryGetDeliveryProvider(providerName, out var provider))
                throw new DeliveryProviderNotFoundException(providerName);

            return CreateDeliveryOrderAsync(provider, deliveryOrderRequest);
        }

        /// <inheritdoc/>
        public Task<DeliveryOrder> CreateDeliveryOrderAsync(DeliveryProviderName providerName, CreateDeliveryOrderRequest deliveryOrderRequest)
            => CreateDeliveryOrderAsync(providerName.ToString(), deliveryOrderRequest);

        /// <inheritdoc/>
        public Task<DeliveryOrder> CreateDeliveryOrderAsync(IDeliveryProvider provider, CreateDeliveryOrderRequest deliveryOrderRequest)
        {
            if (provider is null)
                throw new ArgumentNullException(nameof(provider));

            if (deliveryOrderRequest is null)
                throw new ArgumentNullException(nameof(deliveryOrderRequest));

            return provider.CreateDeliveryOrderAsync(deliveryOrderRequest);
        }

        /// <inheritdoc/>
        public DeliveryOrder GetDeliveryOrder(GetDeliveryOrderRequest deliveryOrderRequest)
            => GetDeliveryOrder(_defaultProvider, deliveryOrderRequest);

        /// <inheritdoc/>
        public DeliveryOrder GetDeliveryOrder(string providerName, GetDeliveryOrderRequest deliveryOrderRequest)
        {
            if (providerName is null)
                throw new ArgumentNullException(nameof(providerName));

            if (!TryGetDeliveryProvider(providerName, out var provider))
                throw new DeliveryProviderNotFoundException(providerName);

            return GetDeliveryOrder(provider, deliveryOrderRequest);
        }

        /// <inheritdoc/>
        public DeliveryOrder GetDeliveryOrder(DeliveryProviderName providerName, GetDeliveryOrderRequest deliveryOrderRequest)
            => GetDeliveryOrder(providerName.ToString(), deliveryOrderRequest);

        /// <inheritdoc/>
        public DeliveryOrder GetDeliveryOrder(IDeliveryProvider provider, GetDeliveryOrderRequest deliveryOrderRequest)
        {
            if (provider is null)
                throw new ArgumentNullException(nameof(provider));

            if (deliveryOrderRequest is null)
                throw new ArgumentNullException(nameof(deliveryOrderRequest));

            return provider.GetDeliveryOrder(deliveryOrderRequest);
        }

        /// <inheritdoc/>
        public Task<DeliveryOrder> GetDeliveryOrderAsync(GetDeliveryOrderRequest deliveryOrderRequest)
            => GetDeliveryOrderAsync(_defaultProvider, deliveryOrderRequest);

        /// <inheritdoc/>
        public Task<DeliveryOrder> GetDeliveryOrderAsync(string providerName, GetDeliveryOrderRequest deliveryOrderRequest)
        {
            if (providerName is null)
                throw new ArgumentNullException(nameof(providerName));

            if (!TryGetDeliveryProvider(providerName, out var provider))
                throw new DeliveryProviderNotFoundException(providerName);

            return GetDeliveryOrderAsync(provider, deliveryOrderRequest);
        }

        /// <inheritdoc/>
        public Task<DeliveryOrder> GetDeliveryOrderAsync(DeliveryProviderName providerName, GetDeliveryOrderRequest deliveryOrderRequest)
            => GetDeliveryOrderAsync(providerName.ToString(), deliveryOrderRequest);

        /// <inheritdoc/>
        public Task<DeliveryOrder> GetDeliveryOrderAsync(IDeliveryProvider provider, GetDeliveryOrderRequest deliveryOrderRequest)
        {
            if (provider is null)
                throw new ArgumentNullException(nameof(provider));

            if (deliveryOrderRequest is null)
                throw new ArgumentNullException(nameof(deliveryOrderRequest));

            return provider.GetDeliveryOrderAsync(deliveryOrderRequest);
        }

        /// <inheritdoc/>
        public DeliveryOrder UpdateDeliveryOrder(UpdateDeliveryOrderRequest deliveryOrderRequest)
            => UpdateDeliveryOrder(_defaultProvider, deliveryOrderRequest);

        /// <inheritdoc/>
        public DeliveryOrder UpdateDeliveryOrder(string providerName, UpdateDeliveryOrderRequest deliveryOrderRequest)
        {
            if (providerName is null)
                throw new ArgumentNullException(nameof(providerName));

            if (!TryGetDeliveryProvider(providerName, out var provider))
                throw new DeliveryProviderNotFoundException(providerName);

            return UpdateDeliveryOrder(provider, deliveryOrderRequest);
        }

        /// <inheritdoc/>
        public DeliveryOrder UpdateDeliveryOrder(DeliveryProviderName providerName, UpdateDeliveryOrderRequest deliveryOrderRequest)
            => UpdateDeliveryOrder(providerName.ToString(), deliveryOrderRequest);

        /// <inheritdoc/>
        public DeliveryOrder UpdateDeliveryOrder(IDeliveryProvider provider, UpdateDeliveryOrderRequest deliveryOrderRequest)
        {
            if (provider is null)
                throw new ArgumentNullException(nameof(provider));

            if (deliveryOrderRequest is null)
                throw new ArgumentNullException(nameof(deliveryOrderRequest));

            return provider.UpdateDeliveryOrder(deliveryOrderRequest);
        }

        /// <inheritdoc/>
        public Task<DeliveryOrder> UpdateDeliveryOrderAsync(UpdateDeliveryOrderRequest deliveryOrderRequest)
            => UpdateDeliveryOrderAsync(_defaultProvider, deliveryOrderRequest);

        /// <inheritdoc/>
        public Task<DeliveryOrder> UpdateDeliveryOrderAsync(string providerName, UpdateDeliveryOrderRequest deliveryOrderRequest)
        {
            if (providerName is null)
                throw new ArgumentNullException(nameof(providerName));

            if (!TryGetDeliveryProvider(providerName, out var provider))
                throw new DeliveryProviderNotFoundException(providerName);

            return UpdateDeliveryOrderAsync(provider, deliveryOrderRequest);
        }

        /// <inheritdoc/>
        public Task<DeliveryOrder> UpdateDeliveryOrderAsync(DeliveryProviderName providerName, UpdateDeliveryOrderRequest deliveryOrderRequest)
            => UpdateDeliveryOrderAsync(providerName.ToString(), deliveryOrderRequest);

        /// <inheritdoc/>
        public Task<DeliveryOrder> UpdateDeliveryOrderAsync(IDeliveryProvider provider, UpdateDeliveryOrderRequest deliveryOrderRequest)
        {
            if (provider is null)
                throw new ArgumentNullException(nameof(provider));

            if (deliveryOrderRequest is null)
                throw new ArgumentNullException(nameof(deliveryOrderRequest));

            return provider.UpdateDeliveryOrderAsync(deliveryOrderRequest);
        }

        /// <inheritdoc/>
        public DeliveryOrder DeleteDeliveryOrder(string orderId)
            => DeleteDeliveryOrder(_defaultProvider, orderId);

        /// <inheritdoc/>
        public DeliveryOrder DeleteDeliveryOrder(string providerName, string orderId)
        {
            if (providerName is null)
                throw new ArgumentNullException(nameof(providerName));

            if (!TryGetDeliveryProvider(providerName, out var provider))
                throw new DeliveryProviderNotFoundException(providerName);

            return DeleteDeliveryOrder(provider, orderId);
        }

        /// <inheritdoc/>
        public DeliveryOrder DeleteDeliveryOrder(DeliveryProviderName providerName, string orderId)
            => DeleteDeliveryOrder(providerName.ToString(), orderId);

        /// <inheritdoc/>
        public DeliveryOrder DeleteDeliveryOrder(IDeliveryProvider provider, string orderId)
        {
            if (provider is null)
                throw new ArgumentNullException(nameof(provider));

            if (orderId is null)
                throw new ArgumentNullException(nameof(orderId));

            return provider.DeleteDeliveryOrder(orderId);
        }

        /// <inheritdoc/>
        public Task<DeliveryOrder> DeleteDeliveryOrderAsync(string orderId)
            => DeleteDeliveryOrderAsync(_defaultProvider, orderId);

        /// <inheritdoc/>
        public Task<DeliveryOrder> DeleteDeliveryOrderAsync(string providerName, string orderId)
        {
            if (providerName is null)
                throw new ArgumentNullException(nameof(providerName));

            if (!TryGetDeliveryProvider(providerName, out var provider))
                throw new DeliveryProviderNotFoundException(providerName);

            return DeleteDeliveryOrderAsync(provider, orderId);
        }

        /// <inheritdoc/>
        public Task<DeliveryOrder> DeleteDeliveryOrderAsync(DeliveryProviderName providerName, string orderId)
            => DeleteDeliveryOrderAsync(providerName.ToString(), orderId);

        /// <inheritdoc/>
        public Task<DeliveryOrder> DeleteDeliveryOrderAsync(IDeliveryProvider provider, string orderId)
        {
            if (provider is null)
                throw new ArgumentNullException(nameof(provider));

            if (orderId is null)
                throw new ArgumentNullException(nameof(orderId));

            return provider.DeleteDeliveryOrderAsync(orderId);
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
