using Spoleto.Delivery.Providers;

namespace Spoleto.Delivery.Services
{
    /// <summary>
    /// The Delivery service serves as an abstraction layer for delivery of goods.
    /// </summary>
    public interface IDeliveryService
    {
        /// <summary>
        /// Gets the list of delivery providers attached to this delivery service.
        /// </summary>
        IEnumerable<IDeliveryProvider> Providers { get; }

        /// <summary>
        /// Gets the default delivery provider attached to this delivery service.
        /// </summary>
        IDeliveryProvider DefaultProvider { get; }

        #region Cities
        /// <summary>
        /// Gets cities.
        /// </summary>
        /// <param name="cityRequest">The city filter request.</param>
        /// <returns>The list of cities.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        List<City> GetCities(CityRequest cityRequest);

        /// <summary>
        /// Gets cities.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="cityRequest">The city filter request.</param>
        /// <returns>The list of cities.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        List<City> GetCities(string providerName, CityRequest cityRequest);

        /// <summary>
        /// Gets cities.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="cityRequest">The city filter request.</param>
        /// <returns>The list of cities.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        List<City> GetCities(DeliveryProviderName providerName, CityRequest cityRequest);

        /// <summary>
        /// Gets cities.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="cityRequest">The city filter request.</param>
        /// <returns>The list of cities.</returns>
        List<City> GetCities(IDeliveryProvider provider, CityRequest cityRequest);

        /// <summary>
        /// Async gets cities.
        /// </summary>
        /// <param name="cityRequest">The city filter request.</param>
        /// <returns>The list of cities.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        Task<List<City>> GetCitiesAsync(CityRequest cityRequest);

        /// <summary>
        /// Async gets cities.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="cityRequest">The city filter request.</param>
        /// <returns>The list of cities.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<List<City>> GetCitiesAsync(string providerName, CityRequest cityRequest);

        /// <summary>
        /// Async gets cities.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="cityRequest">The city filter request.</param>
        /// <returns>The list of cities.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<List<City>> GetCitiesAsync(DeliveryProviderName providerName, CityRequest cityRequest);

        /// <summary>
        /// Async gets cities.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="cityRequest">The city filter request.</param>
        /// <returns>The list of cities.</returns>
        Task<List<City>> GetCitiesAsync(IDeliveryProvider provider, CityRequest cityRequest);
        #endregion

        #region Tariffs
        /// <summary>
        /// Gets tariffs.
        /// </summary>
        /// <param name="deliveryOrderRequest">The tariff request.</param>
        /// <returns>The list of tariffs.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        List<Tariff> GetTariffs(TariffRequest tariffRequest);

        /// <summary>
        /// Gets tariffs.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The tariff request.</param>
        /// <returns>The list of tariffs.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        List<Tariff> GetTariffs(string providerName, TariffRequest tariffRequest);

        /// <summary>
        /// Gets tariffs.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The tariff request.</param>
        /// <returns>The list of tariffs.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        List<Tariff> GetTariffs(DeliveryProviderName providerName, TariffRequest tariffRequest);

        /// <summary>
        /// Gets tariffs.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="deliveryOrderRequest">The tariff request.</param>
        /// <returns>The list of tariffs.</returns>
        List<Tariff> GetTariffs(IDeliveryProvider provider, TariffRequest tariffRequest);

        /// <summary>
        /// Async gets tariffs.
        /// </summary>
        /// <param name="deliveryOrderRequest">The tariff request.</param>
        /// <returns>The list of tariffs.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        Task<List<Tariff>> GetTariffsAsync(TariffRequest tariffRequest);

        /// <summary>
        /// Async gets tariffs.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The tariff request.</param>
        /// <returns>The list of tariffs.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<List<Tariff>> GetTariffsAsync(string providerName, TariffRequest tariffRequest);

        /// <summary>
        /// Async gets tariffs.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The tariff request.</param>
        /// <returns>The list of tariffs.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<List<Tariff>> GetTariffsAsync(DeliveryProviderName providerName, TariffRequest tariffRequest);

        /// <summary>
        /// Async gets tariffs.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="deliveryOrderRequest">The tariff request.</param>
        /// <returns>The list of tariffs.</returns>
        Task<List<Tariff>> GetTariffsAsync(IDeliveryProvider provider, TariffRequest tariffRequest);
        #endregion

        #region DeliveryOrder
        /// <summary>
        /// Creates a tariff.
        /// </summary>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        DeliveryOrder CreateDeliveryOrder(DeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Creates a delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        DeliveryOrder CreateDeliveryOrder(string providerName, DeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Creates a delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        DeliveryOrder CreateDeliveryOrder(DeliveryProviderName providerName, DeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Creates a delivery order.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        DeliveryOrder CreateDeliveryOrder(IDeliveryProvider provider, DeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Async creates a delivery order.
        /// </summary>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        Task<DeliveryOrder> CreateDeliveryOrderAsync(DeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Async creates a delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<DeliveryOrder> CreateDeliveryOrderAsync(string providerName, DeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Async creates a delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<DeliveryOrder> CreateDeliveryOrderAsync(DeliveryProviderName providerName, DeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Async creates a delivery order.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        Task<DeliveryOrder> CreateDeliveryOrderAsync(IDeliveryProvider provider, DeliveryOrderRequest deliveryOrderRequest);
        #endregion
    }
}
