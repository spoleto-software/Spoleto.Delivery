namespace Spoleto.Delivery.Providers
{
    /// <summary>
    /// The delivery provider for delivery of goods.
    /// </summary>
    public interface IDeliveryProvider
    {
        /// <summary>
        /// Gets the delivery provider unique name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets cities filtered by <paramref name="cityRequest"/>.
        /// </summary>
        /// <param name="cityRequest">The cities request.</param>
        /// <returns>List of <see cref="City"/>.</returns>
        List<City> GetCities(CityRequest cityRequest);

        /// <summary>
        /// Async gets cities filtered by <paramref name="cityRequest"/>.
        /// </summary>
        /// <param name="cityRequest">The cities request.</param>
        /// <returns>List of <see cref="City"/>.</returns>
        Task<List<City>> GetCitiesAsync(CityRequest cityRequest);

        /// <summary>
        /// Gets available delivery tariffs.
        /// </summary>
        /// <param name="tariffRequest">The tariffs request.</param>
        /// <returns>List of <see cref="Tariff"/>.</returns>
        List<Tariff> GetTariffs(TariffRequest tariffRequest);

        /// <summary>
        /// Async gets available delivery tariffs.
        /// </summary>
        /// <param name="tariffRequest">The tariffs request.</param>
        /// <returns>List of <see cref="Tariff"/>.</returns>
        Task<List<Tariff>> GetTariffsAsync(TariffRequest tariffRequest);

        /// <summary>
        /// Gets all available additional services for the selected delivery tariff.
        /// </summary>
        /// <param name="tariff">The selected tariff.</param>
        /// <returns>List of <see cref="AdditionalService"/>.</returns>
        List<AdditionalService> GetAdditionalServices(Tariff tariff);

        /// <summary>
        /// Async gets all available additional services for the selected delivery tariff.
        /// </summary>
        /// <param name="tariff">The selected tariff.</param>
        /// <returns>List of <see cref="AdditionalService"/>.</returns>
        Task<List<AdditionalService>> GetAdditionalServicesAsync(Tariff tariff);

        /// <summary>
        /// Creates a delivery order.
        /// </summary>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        DeliveryOrder CreateDeliveryOrder(CreateDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Async creates a delivery order.
        /// </summary>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        Task<DeliveryOrder> CreateDeliveryOrderAsync(CreateDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Gets the delivery order.
        /// </summary>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        DeliveryOrder GetDeliveryOrder(GetDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Async gets the delivery order.
        /// </summary>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        Task<DeliveryOrder> GetDeliveryOrderAsync(GetDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Deletes the delivery order.
        /// </summary>
        /// <param name="orderId">The delivery order identifier.</param>
        /// <returns>The delivery order.</returns>
        DeliveryOrder DeleteDeliveryOrder(string orderId);

        /// <summary>
        /// Async deletes the delivery order.
        /// </summary>
        /// <param name="orderId">The delivery order identifier.</param>
        /// <returns>The delivery order.</returns>
        Task<DeliveryOrder> DeleteDeliveryOrderAsync(string orderId);
    }
}
