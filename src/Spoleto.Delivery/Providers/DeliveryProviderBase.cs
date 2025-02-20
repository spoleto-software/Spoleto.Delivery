namespace Spoleto.Delivery.Providers
{
    /// <summary>
    /// The base abstract delivery provider.
    /// </summary>
    public abstract class DeliveryProviderBase : IDeliveryProvider
    {
        /// <inheritdoc/>
        public abstract string Name { get; }

        /// <inheritdoc/>
        public virtual List<OrderType> SupportedOrderTypes => new() { OrderType.RegularDelivery };

        /// <inheritdoc/>
        public virtual List<City> GetCities(CityRequest cityRequest)
            => GetCitiesAsync(cityRequest).GetAwaiter().GetResult();

        /// <inheritdoc/>
        public abstract Task<List<City>> GetCitiesAsync(CityRequest cityRequest);

        /// <inheritdoc/>
        public virtual List<DeliveryPoint> GetDeliveryPoints(DeliveryPointRequest deliveryPointRequest)
            => GetDeliveryPointsAsync(deliveryPointRequest).GetAwaiter().GetResult();

        /// <inheritdoc/>
        public abstract Task<List<DeliveryPoint>> GetDeliveryPointsAsync(DeliveryPointRequest deliveryPointRequest);

        /// <inheritdoc/>
        public virtual List<Tariff> GetTariffs(TariffRequest tariffRequest)
            => GetTariffsAsync(tariffRequest).GetAwaiter().GetResult();

        /// <inheritdoc/>
        public abstract Task<List<Tariff>> GetTariffsAsync(TariffRequest tariffRequest);

        /// <inheritdoc/>
        public virtual List<AdditionalService> GetAdditionalServices(Tariff tariff)
            => GetAdditionalServicesAsync(tariff).GetAwaiter().GetResult();

        /// <inheritdoc/>
        public abstract Task<List<AdditionalService>> GetAdditionalServicesAsync(Tariff tariff);

        /// <inheritdoc/>
        public virtual DeliveryOrderContainer CreateDeliveryOrder(CreateDeliveryOrderRequest deliveryOrderRequest, bool ensureStatus)
            => CreateDeliveryOrderAsync(deliveryOrderRequest, ensureStatus).GetAwaiter().GetResult();

        /// <inheritdoc/>
        public abstract Task<DeliveryOrderContainer> CreateDeliveryOrderAsync(CreateDeliveryOrderRequest deliveryOrderRequest, bool ensureStatus);

        /// <inheritdoc/>
        public virtual DeliveryOrderContainer GetDeliveryOrder(GetDeliveryOrderRequest deliveryOrderRequest)
            => GetDeliveryOrderAsync(deliveryOrderRequest).GetAwaiter().GetResult();

        /// <inheritdoc/>
        public abstract Task<DeliveryOrderContainer> GetDeliveryOrderAsync(GetDeliveryOrderRequest deliveryOrderRequest);

        /// <inheritdoc/>
        public virtual DeliveryOrderContainer UpdateDeliveryOrder(UpdateDeliveryOrderRequest deliveryOrderRequest)
            => UpdateDeliveryOrderAsync(deliveryOrderRequest).GetAwaiter().GetResult();

        /// <inheritdoc/>
        public abstract Task<DeliveryOrderContainer> UpdateDeliveryOrderAsync(UpdateDeliveryOrderRequest deliveryOrderRequest);

        /// <inheritdoc/>
        public virtual DeliveryOrderContainer DeleteDeliveryOrder(string orderId)
            => DeleteDeliveryOrderAsync(orderId).GetAwaiter().GetResult();

        /// <inheritdoc/>
        public abstract Task<DeliveryOrderContainer> DeleteDeliveryOrderAsync(string orderId);

        public virtual List<PrintingDocument> PrintDeliveryOrder(List<GetDeliveryOrderRequest> deliveryOrderRequests)
            => PrintDeliveryOrderAsync(deliveryOrderRequests).GetAwaiter().GetResult();

        public abstract Task<List<PrintingDocument>> PrintDeliveryOrderAsync(List<GetDeliveryOrderRequest> deliveryOrderRequests);

        /// <inheritdoc/>
        public virtual CourierPickupContainer CreateCourierPickup(CreateCourierPickupRequest createCourierPickupRequest, bool ensureStatus)
            => CreateCourierPickupAsync(createCourierPickupRequest, ensureStatus).GetAwaiter().GetResult();

        /// <inheritdoc/>
        public abstract Task<CourierPickupContainer> CreateCourierPickupAsync(CreateCourierPickupRequest createCourierPickupRequest, bool ensureStatus);

        /// <inheritdoc/>
        public virtual CourierPickupContainer GetCourierPickup(GetCourierPickupRequest getCourierPickupRequest)
            => GetCourierPickupAsync(getCourierPickupRequest).GetAwaiter().GetResult();

        /// <inheritdoc/>
        public abstract Task<CourierPickupContainer> GetCourierPickupAsync(GetCourierPickupRequest getCourierPickupRequest);

        /// <inheritdoc/>
        public virtual CourierPickupContainer DeleteCourierPickup(string pickupOrderId)
            => DeleteCourierPickupAsync(pickupOrderId).GetAwaiter().GetResult();

        /// <inheritdoc/>
        public abstract Task<CourierPickupContainer> DeleteCourierPickupAsync(string pickupOrderId);
    }
}
