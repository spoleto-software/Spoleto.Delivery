using Spoleto.Delivery.Providers;

namespace Spoleto.Delivery
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

        #region DeliveryPoints
        /// <summary>
        /// Gets delivery points.
        /// </summary>
        /// <param name="deliveryPointRequest">The delivery point filter request.</param>
        /// <returns>The list of delivery points.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        List<DeliveryPoint> GetDeliveryPoints(DeliveryPointRequest deliveryPointRequest);

        /// <summary>
        /// Gets delivery points.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryPointRequest">The delivery point filter request.</param>
        /// <returns>The list of delivery points.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        List<DeliveryPoint> GetDeliveryPoints(string providerName, DeliveryPointRequest deliveryPointRequest);

        /// <summary>
        /// Gets delivery points.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryPointRequest">The delivery point filter request.</param>
        /// <returns>The list of delivery points.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        List<DeliveryPoint> GetDeliveryPoints(DeliveryProviderName providerName, DeliveryPointRequest deliveryPointRequest);

        /// <summary>
        /// Gets delivery points.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="deliveryPointRequest">The delivery point filter request.</param>
        /// <returns>The list of delivery points.</returns>
        List<DeliveryPoint> GetDeliveryPoints(IDeliveryProvider provider, DeliveryPointRequest deliveryPointRequest);

        /// <summary>
        /// Async gets delivery points.
        /// </summary>
        /// <param name="deliveryPointRequest">The delivery point filter request.</param>
        /// <returns>The list of delivery points.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        Task<List<DeliveryPoint>> GetDeliveryPointsAsync(DeliveryPointRequest deliveryPointRequest);

        /// <summary>
        /// Async gets delivery points.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryPointRequest">The delivery point filter request.</param>
        /// <returns>The list of delivery points.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<List<DeliveryPoint>> GetDeliveryPointsAsync(string providerName, DeliveryPointRequest deliveryPointRequest);

        /// <summary>
        /// Async gets delivery points.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryPointRequest">The delivery point filter request.</param>
        /// <returns>The list of delivery points.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<List<DeliveryPoint>> GetDeliveryPointsAsync(DeliveryProviderName providerName, DeliveryPointRequest deliveryPointRequest);

        /// <summary>
        /// Async gets delivery points.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="deliveryPointRequest">The delivery point filter request.</param>
        /// <returns>The list of delivery points.</returns>
        Task<List<DeliveryPoint>> GetDeliveryPointsAsync(IDeliveryProvider provider, DeliveryPointRequest deliveryPointRequest);
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

        #region Additional services
        /// <summary>
        /// Gets all available additional services for the selected delivery tariff.
        /// </summary>
        /// <param name="tariff">The selected tariff.</param>
        /// <returns>List of <see cref="AdditionalService"/>.</returns>
        List<AdditionalService> GetAdditionalServices(Tariff tariff);

        /// <summary>
        /// Gets all available additional services for the selected delivery tariff.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="tariff">The selected tariff.</param>
        /// <returns>List of <see cref="AdditionalService"/>.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        List<AdditionalService> GetAdditionalServices(string providerName, Tariff tariff);

        /// <summary>
        /// Gets all available additional services for the selected delivery tariff.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="tariff">The selected tariff.</param>
        /// <returns>List of <see cref="AdditionalService"/>.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        List<AdditionalService> GetAdditionalServices(DeliveryProviderName providerName, Tariff tariff);

        /// <summary>
        /// Gets all available additional services for the selected delivery tariff.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="tariff">The selected tariff.</param>
        /// <returns>List of <see cref="AdditionalService"/>.</returns>
        List<AdditionalService> GetAdditionalServices(IDeliveryProvider provider, Tariff tariff);

        /// <summary>
        /// Async gets all available additional services for the selected delivery tariff.
        /// </summary>
        /// <param name="tariff">The selected tariff.</param>
        /// <returns>List of <see cref="AdditionalService"/>.</returns>
        Task<List<AdditionalService>> GetAdditionalServicesAsync(Tariff tariff);

        /// <summary>
        /// Async gets all available additional services for the selected delivery tariff.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="tariff">The selected tariff.</param>
        /// <returns>List of <see cref="AdditionalService"/>.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<List<AdditionalService>> GetAdditionalServicesAsync(string providerName, Tariff tariff);

        /// <summary>
        /// Async gets all available additional services for the selected delivery tariff.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="tariff">The selected tariff.</param>
        /// <returns>List of <see cref="AdditionalService"/>.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<List<AdditionalService>> GetAdditionalServicesAsync(DeliveryProviderName providerName, Tariff tariff);

        /// <summary>
        /// Async gets all available additional services for the selected delivery tariff.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="tariff">The selected tariff.</param>
        /// <returns>List of <see cref="AdditionalService"/>.</returns>
        Task<List<AdditionalService>> GetAdditionalServicesAsync(IDeliveryProvider provider, Tariff tariff);
        #endregion

        #region DeliveryOrder
        /// <summary>
        /// Creates a delivery order.
        /// </summary>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created deliver order.</param>
        /// <returns>The created delivery order.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        DeliveryOrder CreateDeliveryOrder(CreateDeliveryOrderRequest deliveryOrderRequest, bool ensureStatus);

        /// <summary>
        /// Creates a delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created deliver order.</param>
        /// <returns>The created delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        DeliveryOrder CreateDeliveryOrder(string providerName, CreateDeliveryOrderRequest deliveryOrderRequest, bool ensureStatus);

        /// <summary>
        /// Creates a delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created deliver order.</param>
        /// <returns>The created delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        DeliveryOrder CreateDeliveryOrder(DeliveryProviderName providerName, CreateDeliveryOrderRequest deliveryOrderRequest, bool ensureStatus);

        /// <summary>
        /// Creates a delivery order.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created deliver order.</param>
        /// <returns>The created delivery order.</returns>
        DeliveryOrder CreateDeliveryOrder(IDeliveryProvider provider, CreateDeliveryOrderRequest deliveryOrderRequest, bool ensureStatus);

        /// <summary>
        /// Async creates a delivery order.
        /// </summary>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created deliver order.</param>
        /// <returns>The created delivery order.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        Task<DeliveryOrder> CreateDeliveryOrderAsync(CreateDeliveryOrderRequest deliveryOrderRequest, bool ensureStatus);

        /// <summary>
        /// Async creates a delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created deliver order.</param>
        /// <returns>The created delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<DeliveryOrder> CreateDeliveryOrderAsync(string providerName, CreateDeliveryOrderRequest deliveryOrderRequest, bool ensureStatus);

        /// <summary>
        /// Async creates a delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created deliver order.</param>
        /// <returns>The created delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<DeliveryOrder> CreateDeliveryOrderAsync(DeliveryProviderName providerName, CreateDeliveryOrderRequest deliveryOrderRequest, bool ensureStatus);

        /// <summary>
        /// Async creates a delivery order.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created deliver order.</param>
        /// <returns>The created delivery order.</returns>
        Task<DeliveryOrder> CreateDeliveryOrderAsync(IDeliveryProvider provider, CreateDeliveryOrderRequest deliveryOrderRequest, bool ensureStatus);

        /// <summary>
        /// Gets the delivery order.
        /// </summary>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        DeliveryOrder GetDeliveryOrder(GetDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Gets the delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        DeliveryOrder GetDeliveryOrder(string providerName, GetDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Gets the delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        DeliveryOrder GetDeliveryOrder(DeliveryProviderName providerName, GetDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Gets the delivery order.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        DeliveryOrder GetDeliveryOrder(IDeliveryProvider provider, GetDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Async gets the delivery order.
        /// </summary>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        Task<DeliveryOrder> GetDeliveryOrderAsync(GetDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Async gets the delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<DeliveryOrder> GetDeliveryOrderAsync(string providerName, GetDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Async gets the delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<DeliveryOrder> GetDeliveryOrderAsync(DeliveryProviderName providerName, GetDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Async gets the delivery order.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        Task<DeliveryOrder> GetDeliveryOrderAsync(IDeliveryProvider provider, GetDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Updates a delivery order.
        /// </summary>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        DeliveryOrder UpdateDeliveryOrder(UpdateDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Updates a delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        DeliveryOrder UpdateDeliveryOrder(string providerName, UpdateDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Updates a delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        DeliveryOrder UpdateDeliveryOrder(DeliveryProviderName providerName, UpdateDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Updates a delivery order.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        DeliveryOrder UpdateDeliveryOrder(IDeliveryProvider provider, UpdateDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Async updates a delivery order.
        /// </summary>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        Task<DeliveryOrder> UpdateDeliveryOrderAsync(UpdateDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Async updates a delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<DeliveryOrder> UpdateDeliveryOrderAsync(string providerName, UpdateDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Async updates a delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<DeliveryOrder> UpdateDeliveryOrderAsync(DeliveryProviderName providerName, UpdateDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Async updates a delivery order.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        Task<DeliveryOrder> UpdateDeliveryOrderAsync(IDeliveryProvider provider, UpdateDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Deletes the delivery order.
        /// </summary>
        /// <param name="orderId">The delivery order identifier.</param>
        /// <returns>The deleted delivery order.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        DeliveryOrder DeleteDeliveryOrder(string orderId);

        /// <summary>
        /// Deletes the delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="orderId">The delivery order identifier.</param>
        /// <returns>The deleted delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        DeliveryOrder DeleteDeliveryOrder(string providerName, string orderId);

        /// <summary>
        /// Deletes the delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="orderId">The delivery order identifier.</param>
        /// <returns>The deleted delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        DeliveryOrder DeleteDeliveryOrder(DeliveryProviderName providerName, string orderId);

        /// <summary>
        /// Deletes the delivery order.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="orderId">The delivery order identifier.</param>
        /// <returns>The deleted delivery order.</returns>
        DeliveryOrder DeleteDeliveryOrder(IDeliveryProvider provider, string orderId);

        /// <summary>
        /// Async deletes the delivery order.
        /// </summary>
        /// <param name="orderId">The delivery order identifier.</param>
        /// <returns>The delivery order.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        Task<DeliveryOrder> DeleteDeliveryOrderAsync(string orderId);

        /// <summary>
        /// Async deletes the delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="orderId">The delivery order identifier.</param>
        /// <returns>The deleted delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<DeliveryOrder> DeleteDeliveryOrderAsync(string providerName, string orderId);

        /// <summary>
        /// Async deletes the delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="orderId">The delivery order identifier.</param>
        /// <returns>The deleted delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<DeliveryOrder> DeleteDeliveryOrderAsync(DeliveryProviderName providerName, string orderId);

        /// <summary>
        /// Async deletes the delivery order.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="orderId">The delivery order identifier.</param>
        /// <returns>The deleted delivery order.</returns>
        Task<DeliveryOrder> DeleteDeliveryOrderAsync(IDeliveryProvider provider, string orderId);
        #endregion

        #region CourierPickup
        /// <summary>
        /// Creates the courier pickup order.
        /// </summary>
        /// <param name="createCourierPickupRequest">The courier pickup order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created courier pickup order.</param>
        /// <returns>The created courier pickup order.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        CourierPickup CreateCourierPickup(CreateCourierPickupRequest createCourierPickupRequest, bool ensureStatus);

        /// <summary>
        /// Creates the courier pickup order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="createCourierPickupRequest">The courier pickup order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created courier pickup order.</param>
        /// <returns>The created courier pickup order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        CourierPickup CreateCourierPickup(string providerName, CreateCourierPickupRequest createCourierPickupRequest, bool ensureStatus);

        /// <summary>
        /// Creates the courier pickup order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="createCourierPickupRequest">The courier pickup order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created courier pickup order.</param>
        /// <returns>The created courier pickup order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        CourierPickup CreateCourierPickup(DeliveryProviderName providerName, CreateCourierPickupRequest createCourierPickupRequest, bool ensureStatus);

        /// <summary>
        /// Creates the courier pickup order.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="createCourierPickupRequest">The courier pickup order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created courier pickup order.</param>
        /// <returns>The created courier pickup order.</returns>
        CourierPickup CreateCourierPickup(IDeliveryProvider provider, CreateCourierPickupRequest createCourierPickupRequest, bool ensureStatus);

        /// <summary>
        /// Async creates the courier pickup order.
        /// </summary>
        /// <param name="createCourierPickupRequest">The courier pickup order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created courier pickup order.</param>
        /// <returns>The created courier pickup order.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        Task<CourierPickup> CreateCourierPickupAsync(CreateCourierPickupRequest createCourierPickupRequest, bool ensureStatus);

        /// <summary>
        /// Async creates the courier pickup order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="createCourierPickupRequest">The courier pickup order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created courier pickup order.</param>
        /// <returns>The created courier pickup order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<CourierPickup> CreateCourierPickupAsync(string providerName, CreateCourierPickupRequest createCourierPickupRequest, bool ensureStatus);

        /// <summary>
        /// Async creates the courier pickup order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="createCourierPickupRequest">The courier pickup order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created courier pickup order.</param>
        /// <returns>The created courier pickup order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<CourierPickup> CreateCourierPickupAsync(DeliveryProviderName providerName, CreateCourierPickupRequest createCourierPickupRequest, bool ensureStatus);

        /// <summary>
        /// Async creates the courier pickup order.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="createCourierPickupRequest">The courier pickup order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created courier pickup order.</param>
        /// <returns>The created courier pickup order.</returns>
        Task<CourierPickup> CreateCourierPickupAsync(IDeliveryProvider provider, CreateCourierPickupRequest createCourierPickupRequest, bool ensureStatus);

        /// <summary>
        /// Gets the courier pickup order.
        /// </summary>
        /// <param name="getCourierPickupRequest">The courier pickup order request.</param>
        /// <returns>The courier pickup order.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        CourierPickup GetCourierPickup(GetCourierPickupRequest getCourierPickupRequest);

        /// <summary>
        /// Gets the courier pickup order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="getCourierPickupRequest">The courier pickup order request.</param>
        /// <returns>The courier pickup order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        CourierPickup GetCourierPickup(string providerName, GetCourierPickupRequest getCourierPickupRequest);

        /// <summary>
        /// Gets the courier pickup order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="getCourierPickupRequest">The courier pickup order request.</param>
        /// <returns>The courier pickup order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        CourierPickup GetCourierPickup(DeliveryProviderName providerName, GetCourierPickupRequest getCourierPickupRequest);

        /// <summary>
        /// Gets the courier pickup order.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="getCourierPickupRequest">The courier pickup order request.</param>
        /// <returns>The courier pickup order.</returns>
        CourierPickup GetCourierPickup(IDeliveryProvider provider, GetCourierPickupRequest getCourierPickupRequest);

        /// <summary>
        /// Async gets the courier pickup order.
        /// </summary>
        /// <param name="getCourierPickupRequest">The courier pickup order request.</param>
        /// <returns>The courier pickup order.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        Task<CourierPickup> GetCourierPickupAsync(GetCourierPickupRequest getCourierPickupRequest);

        /// <summary>
        /// Async gets the courier pickup order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="getCourierPickupRequest">The courier pickup order request.</param>
        /// <returns>The courier pickup order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<CourierPickup> GetCourierPickupAsync(string providerName, GetCourierPickupRequest getCourierPickupRequest);

        /// <summary>
        /// Async gets the courier pickup order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="getCourierPickupRequest">The courier pickup order request.</param>
        /// <returns>The courier pickup order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<CourierPickup> GetCourierPickupAsync(DeliveryProviderName providerName, GetCourierPickupRequest getCourierPickupRequest);

        /// <summary>
        /// Async gets the courier pickup order.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="getCourierPickupRequest">The courier pickup order request.</param>
        /// <returns>The courier pickup order.</returns>
        Task<CourierPickup> GetCourierPickupAsync(IDeliveryProvider provider, GetCourierPickupRequest getCourierPickupRequest);

        /// <summary>
        /// Deletes the courier pickup order.
        /// </summary>
        /// <param name="pickupOrderId">The courier pickup order identifier.</param>
        /// <returns>The deleted courier pickup order.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        CourierPickup DeleteCourierPickup(string pickupOrderId);

        /// <summary>
        /// Deletes the courier pickup order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="pickupOrderId">The courier pickup order identifier.</param>
        /// <returns>The deleted courier pickup order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        CourierPickup DeleteCourierPickup(string providerName, string pickupOrderId);

        /// <summary>
        /// Deletes the courier pickup order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="pickupOrderId">The courier pickup order identifier.</param>
        /// <returns>The deleted courier pickup order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        CourierPickup DeleteCourierPickup(DeliveryProviderName providerName, string pickupOrderId);

        /// <summary>
        /// Deletes the courier pickup order.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="pickupOrderId">The courier pickup order identifier.</param>
        /// <returns>The deleted courier pickup order.</returns>
        CourierPickup DeleteCourierPickup(IDeliveryProvider provider, string pickupOrderId);

        /// <summary>
        /// Async deletes the courier pickup order.
        /// </summary>
        /// <param name="pickupOrderId">The courier pickup order identifier.</param>
        /// <returns>The deleted courier pickup order.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        Task<CourierPickup> DeleteCourierPickupAsync(string pickupOrderId);

        /// <summary>
        /// Async deletes the courier pickup order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="pickupOrderId">The courier pickup order identifier.</param>
        /// <returns>The deleted courier pickup order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<CourierPickup> DeleteCourierPickupAsync(string providerName, string pickupOrderId);

        /// <summary>
        /// Async deletes the courier pickup order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="pickupOrderId">The courier pickup order identifier.</param>
        /// <returns>The deleted courier pickup order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<CourierPickup> DeleteCourierPickupAsync(DeliveryProviderName providerName, string pickupOrderId);

        /// <summary>
        /// Async deletes the courier pickup order.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="pickupOrderId">The courier pickup order identifier.</param>
        /// <returns>The deleted courier pickup order.</returns>
        Task<CourierPickup> DeleteCourierPickupAsync(IDeliveryProvider provider, string pickupOrderId);
        #endregion
    }
}
