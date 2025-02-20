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
        /// Gets the supported order types.
        /// </summary>
        public List<OrderType> SupportedOrderTypes { get; }

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
        /// Gets delivery points filtered by <paramref name="deliveryPointRequest"/>.
        /// </summary>
        /// <param name="cityRequest">The delivery point request.</param>
        /// <returns>List of <see cref="DeliveryPoint"/>.</returns>
        List<DeliveryPoint> GetDeliveryPoints(DeliveryPointRequest deliveryPointRequest);

        /// <summary>
        /// Async gets delivery points filtered by <paramref name="deliveryPointRequest"/>.
        /// </summary>
        /// <param name="cityRequest">The delivery point request.</param>
        /// <returns>List of <see cref="DeliveryPoint"/>.</returns>
        Task<List<DeliveryPoint>> GetDeliveryPointsAsync(DeliveryPointRequest deliveryPointRequest);

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
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created deliver order.</param>
        /// <returns>The created delivery order.</returns>
        DeliveryOrderContainer CreateDeliveryOrder(CreateDeliveryOrderRequest deliveryOrderRequest, bool ensureStatus);

        /// <summary>
        /// Async creates a delivery order.
        /// </summary>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created deliver order.</param>
        /// <returns>The created delivery order.</returns>
        Task<DeliveryOrderContainer> CreateDeliveryOrderAsync(CreateDeliveryOrderRequest deliveryOrderRequest, bool ensureStatus);

        /// <summary>
        /// Gets the delivery order.
        /// </summary>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        DeliveryOrderContainer GetDeliveryOrder(GetDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Async gets the delivery order.
        /// </summary>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        Task<DeliveryOrderContainer> GetDeliveryOrderAsync(GetDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Updates the delivery order.
        /// </summary>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The updated delivery order.</returns>
        DeliveryOrderContainer UpdateDeliveryOrder(UpdateDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Async updates the delivery order.
        /// </summary>
        /// <param name="deliveryOrderRequest">The delivery order request.</param>
        /// <returns>The delivery order.</returns>
        Task<DeliveryOrderContainer> UpdateDeliveryOrderAsync(UpdateDeliveryOrderRequest deliveryOrderRequest);

        /// <summary>
        /// Deletes the delivery order.
        /// </summary>
        /// <param name="orderId">The delivery order identifier.</param>
        /// <returns>The deleted delivery order.</returns>
        DeliveryOrderContainer DeleteDeliveryOrder(string orderId);

        /// <summary>
        /// Async deletes the delivery order.
        /// </summary>
        /// <param name="pickupOrderId">The delivery order identifier.</param>
        /// <returns>The deleted delivery order.</returns>
        Task<DeliveryOrderContainer> DeleteDeliveryOrderAsync(string pickupOrderId);

        /// <summary>
        /// Prints the delivery orders.
        /// </summary>
        /// <param name="deliveryOrderRequests">The delivery order requests.</param>
        /// <returns>The list of printing documents.</returns>
        List<PrintingDocument> PrintDeliveryOrder(List<GetDeliveryOrderRequest> deliveryOrderRequests);

        /// <summary>
        /// Async prints the delivery orders.
        /// </summary>
        /// <param name="deliveryOrderRequests">The delivery order requests.</param>
        /// <returns>The list of printing documents.</returns>
        Task<List<PrintingDocument>> PrintDeliveryOrderAsync(List<GetDeliveryOrderRequest> deliveryOrderRequests);

        /// <summary>
        /// Creates the courier pickup order.
        /// </summary>
        /// <param name="createCourierPickupRequest">The courier pickup order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created courier pickup order.</param>
        /// <returns>The created courier pickup order.</returns>
        CourierPickupContainer CreateCourierPickup(CreateCourierPickupRequest createCourierPickupRequest, bool ensureStatus);

        /// <summary>
        /// Async creates the courier pickup order.
        /// </summary>
        /// <param name="createCourierPickupRequest">The courier pickup order request.</param>
        /// <param name="ensureStatus">The flag indicating whether this method has to ensure the valid status of the created courier pickup order.</param>
        /// <returns>The created courier pickup order.</returns>
        Task<CourierPickupContainer> CreateCourierPickupAsync(CreateCourierPickupRequest createCourierPickupRequest, bool ensureStatus);

        /// <summary>
        /// Gets the courier pickup order.
        /// </summary>
        /// <param name="getCourierPickupRequest">The courier pickup order request.</param>
        /// <returns>The courier pickup order.</returns>
        CourierPickupContainer GetCourierPickup(GetCourierPickupRequest getCourierPickupRequest);

        /// <summary>
        /// Async gets the courier pickup order.
        /// </summary>
        /// <param name="getCourierPickupRequest">The courier pickup order request.</param>
        /// <returns>The courier pickup order.</returns>
        Task<CourierPickupContainer> GetCourierPickupAsync(GetCourierPickupRequest getCourierPickupRequest);

        /// <summary>
        /// Deletes the courier pickup order.
        /// </summary>
        /// <param name="pickupOrderId">The courier pickup order identifier.</param>
        /// <returns>The courier pickup order.</returns>
        CourierPickupContainer DeleteCourierPickup(string pickupOrderId);

        /// <summary>
        /// Async deletes the courier pickup order.
        /// </summary>
        /// <param name="pickupOrderId">The courier pickup order identifier.</param>
        /// <returns>The courier pickup order.</returns>
        Task<CourierPickupContainer> DeleteCourierPickupAsync(string pickupOrderId);
    }
}
