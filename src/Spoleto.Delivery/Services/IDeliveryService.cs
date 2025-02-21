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
        DeliveryOrderContainer CreateDeliveryOrder(CreateDeliveryOrderRequest deliveryOrderRequest, bool ensureStatus);

        /// <summary>
        /// Creates a delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created deliver order.</param>
        /// <returns>The created delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        DeliveryOrderContainer CreateDeliveryOrder(string providerName, CreateDeliveryOrderRequest deliveryOrderRequest, bool ensureStatus);

        /// <summary>
        /// Creates a delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created deliver order.</param>
        /// <returns>The created delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        DeliveryOrderContainer CreateDeliveryOrder(DeliveryProviderName providerName, CreateDeliveryOrderRequest deliveryOrderRequest, bool ensureStatus);

        /// <summary>
        /// Creates a delivery order.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created deliver order.</param>
        /// <returns>The created delivery order.</returns>
        DeliveryOrderContainer CreateDeliveryOrder(IDeliveryProvider provider, CreateDeliveryOrderRequest deliveryOrderRequest, bool ensureStatus);

        /// <summary>
        /// Async creates a delivery order.
        /// </summary>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created deliver order.</param>
        /// <returns>The created delivery order.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        Task<DeliveryOrderContainer> CreateDeliveryOrderAsync(CreateDeliveryOrderRequest deliveryOrderRequest, bool ensureStatus);

        /// <summary>
        /// Async creates a delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created deliver order.</param>
        /// <returns>The created delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<DeliveryOrderContainer> CreateDeliveryOrderAsync(string providerName, CreateDeliveryOrderRequest deliveryOrderRequest, bool ensureStatus);

        /// <summary>
        /// Async creates a delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created deliver order.</param>
        /// <returns>The created delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<DeliveryOrderContainer> CreateDeliveryOrderAsync(DeliveryProviderName providerName, CreateDeliveryOrderRequest deliveryOrderRequest, bool ensureStatus);

        /// <summary>
        /// Async creates a delivery order.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created deliver order.</param>
        /// <returns>The created delivery order.</returns>
        Task<DeliveryOrderContainer> CreateDeliveryOrderAsync(IDeliveryProvider provider, CreateDeliveryOrderRequest deliveryOrderRequest, bool ensureStatus);

        /// <summary>
        /// Gets the delivery order.
        /// </summary>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        DeliveryOrderContainer GetDeliveryOrder(GetDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Gets the delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        DeliveryOrderContainer GetDeliveryOrder(string providerName, GetDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Gets the delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        DeliveryOrderContainer GetDeliveryOrder(DeliveryProviderName providerName, GetDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Gets the delivery order.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        DeliveryOrderContainer GetDeliveryOrder(IDeliveryProvider provider, GetDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Async gets the delivery order.
        /// </summary>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        Task<DeliveryOrderContainer> GetDeliveryOrderAsync(GetDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Async gets the delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<DeliveryOrderContainer> GetDeliveryOrderAsync(string providerName, GetDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Async gets the delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<DeliveryOrderContainer> GetDeliveryOrderAsync(DeliveryProviderName providerName, GetDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Async gets the delivery order.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        Task<DeliveryOrderContainer> GetDeliveryOrderAsync(IDeliveryProvider provider, GetDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Updates a delivery order.
        /// </summary>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        DeliveryOrderContainer UpdateDeliveryOrder(UpdateDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Updates a delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        DeliveryOrderContainer UpdateDeliveryOrder(string providerName, UpdateDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Updates a delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        DeliveryOrderContainer UpdateDeliveryOrder(DeliveryProviderName providerName, UpdateDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Updates a delivery order.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        DeliveryOrderContainer UpdateDeliveryOrder(IDeliveryProvider provider, UpdateDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Async updates a delivery order.
        /// </summary>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        Task<DeliveryOrderContainer> UpdateDeliveryOrderAsync(UpdateDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Async updates a delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<DeliveryOrderContainer> UpdateDeliveryOrderAsync(string providerName, UpdateDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Async updates a delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<DeliveryOrderContainer> UpdateDeliveryOrderAsync(DeliveryProviderName providerName, UpdateDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Async updates a delivery order.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        Task<DeliveryOrderContainer> UpdateDeliveryOrderAsync(IDeliveryProvider provider, UpdateDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Deletes the delivery order.
        /// </summary>
        /// <param name="orderId">The delivery order identifier.</param>
        /// <returns>The deleted delivery order.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        DeliveryOrderContainer DeleteDeliveryOrder(string orderId);

        /// <summary>
        /// Deletes the delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="orderId">The delivery order identifier.</param>
        /// <returns>The deleted delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        DeliveryOrderContainer DeleteDeliveryOrder(string providerName, string orderId);

        /// <summary>
        /// Deletes the delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="orderId">The delivery order identifier.</param>
        /// <returns>The deleted delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        DeliveryOrderContainer DeleteDeliveryOrder(DeliveryProviderName providerName, string orderId);

        /// <summary>
        /// Deletes the delivery order.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="orderId">The delivery order identifier.</param>
        /// <returns>The deleted delivery order.</returns>
        DeliveryOrderContainer DeleteDeliveryOrder(IDeliveryProvider provider, string orderId);

        /// <summary>
        /// Async deletes the delivery order.
        /// </summary>
        /// <param name="orderId">The delivery order identifier.</param>
        /// <returns>The delivery order.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        Task<DeliveryOrderContainer> DeleteDeliveryOrderAsync(string orderId);

        /// <summary>
        /// Async deletes the delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="orderId">The delivery order identifier.</param>
        /// <returns>The deleted delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<DeliveryOrderContainer> DeleteDeliveryOrderAsync(string providerName, string orderId);

        /// <summary>
        /// Async deletes the delivery order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="orderId">The delivery order identifier.</param>
        /// <returns>The deleted delivery order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<DeliveryOrderContainer> DeleteDeliveryOrderAsync(DeliveryProviderName providerName, string orderId);

        /// <summary>
        /// Async deletes the delivery order.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="orderId">The delivery order identifier.</param>
        /// <returns>The deleted delivery order.</returns>
        Task<DeliveryOrderContainer> DeleteDeliveryOrderAsync(IDeliveryProvider provider, string orderId);

        /// <summary>
        /// Prints the delivery orders.
        /// </summary>
        /// <param name="printDeliveryOrderRequest">The print delivery order request.</param>
        /// <returns>The list of printing documents.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        List<PrintingDocument> PrintDeliveryOrder(PrintDeliveryOrderRequest printDeliveryOrderRequest);

        /// <summary>
        /// Prints the delivery orders.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="printDeliveryOrderRequest">The print delivery order request.</param>
        /// <returns>The list of printing documents.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        List<PrintingDocument> PrintDeliveryOrder(string providerName, PrintDeliveryOrderRequest printDeliveryOrderRequest);

        /// <summary>
        /// Prints the delivery orders.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="printDeliveryOrderRequest">The print delivery order request.</param>
        /// <returns>The list of printing documents.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        List<PrintingDocument> PrintDeliveryOrder(DeliveryProviderName providerName, PrintDeliveryOrderRequest printDeliveryOrderRequest);

        /// <summary>
        /// Prints the delivery orders.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="printDeliveryOrderRequest">The print delivery order request.</param>
        /// <returns>The list of printing documents.</returns>
        List<PrintingDocument> PrintDeliveryOrder(IDeliveryProvider provider, PrintDeliveryOrderRequest printDeliveryOrderRequest);

        /// <summary>
        /// Async prints the delivery orders.
        /// </summary>
        /// <param name="printDeliveryOrderRequest">The print delivery order request.</param>
        /// <returns>The list of printing documents.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        Task<List<PrintingDocument>> PrintDeliveryOrderAsync(PrintDeliveryOrderRequest printDeliveryOrderRequest);

        /// <summary>
        /// Async prints the delivery orders.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="printDeliveryOrderRequest">The print delivery order request.</param>
        /// <returns>The list of printing documents.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<List<PrintingDocument>> PrintDeliveryOrderAsync(string providerName, PrintDeliveryOrderRequest printDeliveryOrderRequest);

        /// <summary>
        /// Async prints the delivery orders.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="printDeliveryOrderRequest">The print delivery order request.</param>
        /// <returns>The list of printing documents.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<List<PrintingDocument>> PrintDeliveryOrderAsync(DeliveryProviderName providerName, PrintDeliveryOrderRequest printDeliveryOrderRequest);

        /// <summary>
        /// Async prints the delivery orders.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="printDeliveryOrderRequest">The print delivery order request.</param>
        /// <returns>The list of printing documents.</returns>
        Task<List<PrintingDocument>> PrintDeliveryOrderAsync(IDeliveryProvider provider, PrintDeliveryOrderRequest printDeliveryOrderRequest);
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
        CourierPickupContainer CreateCourierPickup(CreateCourierPickupRequest createCourierPickupRequest, bool ensureStatus);

        /// <summary>
        /// Creates the courier pickup order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="createCourierPickupRequest">The courier pickup order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created courier pickup order.</param>
        /// <returns>The created courier pickup order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        CourierPickupContainer CreateCourierPickup(string providerName, CreateCourierPickupRequest createCourierPickupRequest, bool ensureStatus);

        /// <summary>
        /// Creates the courier pickup order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="createCourierPickupRequest">The courier pickup order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created courier pickup order.</param>
        /// <returns>The created courier pickup order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        CourierPickupContainer CreateCourierPickup(DeliveryProviderName providerName, CreateCourierPickupRequest createCourierPickupRequest, bool ensureStatus);

        /// <summary>
        /// Creates the courier pickup order.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="createCourierPickupRequest">The courier pickup order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created courier pickup order.</param>
        /// <returns>The created courier pickup order.</returns>
        CourierPickupContainer CreateCourierPickup(IDeliveryProvider provider, CreateCourierPickupRequest createCourierPickupRequest, bool ensureStatus);

        /// <summary>
        /// Async creates the courier pickup order.
        /// </summary>
        /// <param name="createCourierPickupRequest">The courier pickup order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created courier pickup order.</param>
        /// <returns>The created courier pickup order.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        Task<CourierPickupContainer> CreateCourierPickupAsync(CreateCourierPickupRequest createCourierPickupRequest, bool ensureStatus);

        /// <summary>
        /// Async creates the courier pickup order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="createCourierPickupRequest">The courier pickup order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created courier pickup order.</param>
        /// <returns>The created courier pickup order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<CourierPickupContainer> CreateCourierPickupAsync(string providerName, CreateCourierPickupRequest createCourierPickupRequest, bool ensureStatus);

        /// <summary>
        /// Async creates the courier pickup order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="createCourierPickupRequest">The courier pickup order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created courier pickup order.</param>
        /// <returns>The created courier pickup order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<CourierPickupContainer> CreateCourierPickupAsync(DeliveryProviderName providerName, CreateCourierPickupRequest createCourierPickupRequest, bool ensureStatus);

        /// <summary>
        /// Async creates the courier pickup order.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="createCourierPickupRequest">The courier pickup order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created courier pickup order.</param>
        /// <returns>The created courier pickup order.</returns>
        Task<CourierPickupContainer> CreateCourierPickupAsync(IDeliveryProvider provider, CreateCourierPickupRequest createCourierPickupRequest, bool ensureStatus);

        /// <summary>
        /// Gets the courier pickup order.
        /// </summary>
        /// <param name="getCourierPickupRequest">The courier pickup order request.</param>
        /// <returns>The courier pickup order.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        CourierPickupContainer GetCourierPickup(GetCourierPickupRequest getCourierPickupRequest);

        /// <summary>
        /// Gets the courier pickup order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="getCourierPickupRequest">The courier pickup order request.</param>
        /// <returns>The courier pickup order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        CourierPickupContainer GetCourierPickup(string providerName, GetCourierPickupRequest getCourierPickupRequest);

        /// <summary>
        /// Gets the courier pickup order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="getCourierPickupRequest">The courier pickup order request.</param>
        /// <returns>The courier pickup order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        CourierPickupContainer GetCourierPickup(DeliveryProviderName providerName, GetCourierPickupRequest getCourierPickupRequest);

        /// <summary>
        /// Gets the courier pickup order.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="getCourierPickupRequest">The courier pickup order request.</param>
        /// <returns>The courier pickup order.</returns>
        CourierPickupContainer GetCourierPickup(IDeliveryProvider provider, GetCourierPickupRequest getCourierPickupRequest);

        /// <summary>
        /// Async gets the courier pickup order.
        /// </summary>
        /// <param name="getCourierPickupRequest">The courier pickup order request.</param>
        /// <returns>The courier pickup order.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        Task<CourierPickupContainer> GetCourierPickupAsync(GetCourierPickupRequest getCourierPickupRequest);

        /// <summary>
        /// Async gets the courier pickup order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="getCourierPickupRequest">The courier pickup order request.</param>
        /// <returns>The courier pickup order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<CourierPickupContainer> GetCourierPickupAsync(string providerName, GetCourierPickupRequest getCourierPickupRequest);

        /// <summary>
        /// Async gets the courier pickup order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="getCourierPickupRequest">The courier pickup order request.</param>
        /// <returns>The courier pickup order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<CourierPickupContainer> GetCourierPickupAsync(DeliveryProviderName providerName, GetCourierPickupRequest getCourierPickupRequest);

        /// <summary>
        /// Async gets the courier pickup order.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="getCourierPickupRequest">The courier pickup order request.</param>
        /// <returns>The courier pickup order.</returns>
        Task<CourierPickupContainer> GetCourierPickupAsync(IDeliveryProvider provider, GetCourierPickupRequest getCourierPickupRequest);

        /// <summary>
        /// Deletes the courier pickup order.
        /// </summary>
        /// <param name="pickupOrderId">The courier pickup order identifier.</param>
        /// <returns>The deleted courier pickup order.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        CourierPickupContainer DeleteCourierPickup(string pickupOrderId);

        /// <summary>
        /// Deletes the courier pickup order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="pickupOrderId">The courier pickup order identifier.</param>
        /// <returns>The deleted courier pickup order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        CourierPickupContainer DeleteCourierPickup(string providerName, string pickupOrderId);

        /// <summary>
        /// Deletes the courier pickup order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="pickupOrderId">The courier pickup order identifier.</param>
        /// <returns>The deleted courier pickup order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        CourierPickupContainer DeleteCourierPickup(DeliveryProviderName providerName, string pickupOrderId);

        /// <summary>
        /// Deletes the courier pickup order.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="pickupOrderId">The courier pickup order identifier.</param>
        /// <returns>The deleted courier pickup order.</returns>
        CourierPickupContainer DeleteCourierPickup(IDeliveryProvider provider, string pickupOrderId);

        /// <summary>
        /// Async deletes the courier pickup order.
        /// </summary>
        /// <param name="pickupOrderId">The courier pickup order identifier.</param>
        /// <returns>The deleted courier pickup order.</returns>
        /// <remarks>
        /// The designated default delivery provider must be defined within the <see cref="DeliveryServiceOptions.DefaultProvider"/> setting, which is provided to the <see cref="DeliveryService"/> when it is instantiated.
        /// </remarks>
        Task<CourierPickupContainer> DeleteCourierPickupAsync(string pickupOrderId);

        /// <summary>
        /// Async deletes the courier pickup order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="pickupOrderId">The courier pickup order identifier.</param>
        /// <returns>The deleted courier pickup order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<CourierPickupContainer> DeleteCourierPickupAsync(string providerName, string pickupOrderId);

        /// <summary>
        /// Async deletes the courier pickup order.
        /// </summary>
        /// <param name="providerName">The name of the delivery provider.</param>
        /// <param name="pickupOrderId">The courier pickup order identifier.</param>
        /// <returns>The deleted courier pickup order.</returns>
        /// <exception cref="DeliveryProviderNotFoundException">Thrown when the identified delivery service provider cannot be found.</exception>
        Task<CourierPickupContainer> DeleteCourierPickupAsync(DeliveryProviderName providerName, string pickupOrderId);

        /// <summary>
        /// Async deletes the courier pickup order.
        /// </summary>
        /// <param name="providerName">The delivery provider.</param>
        /// <param name="pickupOrderId">The courier pickup order identifier.</param>
        /// <returns>The deleted courier pickup order.</returns>
        Task<CourierPickupContainer> DeleteCourierPickupAsync(IDeliveryProvider provider, string pickupOrderId);
        #endregion
    }
}
