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
        public virtual DeliveryOrder CreateDeliveryOrder(CreateDeliveryOrderRequest deliveryOrderRequest)
            => CreateDeliveryOrderAsync(deliveryOrderRequest).GetAwaiter().GetResult();

        /// <inheritdoc/>
        public abstract Task<DeliveryOrder> CreateDeliveryOrderAsync(CreateDeliveryOrderRequest deliveryOrderRequest);

        /// <inheritdoc/>
        public virtual DeliveryOrder GetDeliveryOrder(GetDeliveryOrderRequest deliveryOrderRequest)
            => GetDeliveryOrderAsync(deliveryOrderRequest).GetAwaiter().GetResult();

        /// <inheritdoc/>
        public abstract Task<DeliveryOrder> GetDeliveryOrderAsync(GetDeliveryOrderRequest deliveryOrderRequest);

        /// <inheritdoc/>
        public virtual DeliveryOrder DeleteDeliveryOrder(string orderId)
            => DeleteDeliveryOrderAsync(orderId).GetAwaiter().GetResult();

        /// <inheritdoc/>
        public abstract Task<DeliveryOrder> DeleteDeliveryOrderAsync(string orderId);

        /// <inheritdoc/>
        public virtual DeliveryOrder UpdateDeliveryOrder(UpdateDeliveryOrderRequest deliveryOrderRequest)
            => UpdateDeliveryOrderAsync(deliveryOrderRequest).GetAwaiter().GetResult();

        /// <inheritdoc/>
        public abstract Task<DeliveryOrder> UpdateDeliveryOrderAsync(UpdateDeliveryOrderRequest deliveryOrderRequest);
    }
}
