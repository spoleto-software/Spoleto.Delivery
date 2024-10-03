namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// MasterPost delivery provider for delivery of goods.
    /// </summary>
    /// <remarks>
    /// <see href="https://mplogistics.ru"/>
    /// </remarks>
    public interface IMasterPostProvider : IDeliveryProvider
    {
        /// <summary>
        /// Gets all existing services (tariffs).
        /// </summary>
        /// <returns>List of <see cref="Service"/>.</returns>
        List<Service> GetServices();

        /// <summary>
        /// Async gets all existing services (tariffs).
        /// </summary>
        /// <returns>List of <see cref="Service"/>.</returns>
        Task<List<Service>> GetServicesAsync();

        /// <summary>
        /// Gets all existing additional services (for all tariffs).
        /// </summary>
        /// <returns>List of <see cref="AdditionalServiceInfo"/>.</returns>
        List<AdditionalServiceInfo> GetAdditionalServices();

        /// <summary>
        /// Async gets all existing additional services (for all tariffs).
        /// </summary>
        /// <returns>List of <see cref="AdditionalServiceInfo"/>.</returns>
        Task<List<AdditionalServiceInfo>> GetAdditionalServicesAsync();

        /// <summary>
        /// Gets streets filtered by <paramref name="streetRequest"/>.
        /// </summary>
        /// <param name="streetRequest">The streets request.</param>
        /// <returns>List of <see cref="City"/>.</returns>
        List<Street> GetStreets(StreetRequest streetRequest);

        /// <summary>
        /// Async gets streets filtered by <paramref name="streetRequest"/>.
        /// </summary>
        /// <param name="streetRequest">The streets request.</param>
        /// <returns>List of <see cref="City"/>.</returns>
        Task<List<Street>> GetStreetsAsync(StreetRequest streetRequest);

        /// <summary>
        /// Gets the delivery order by its number.
        /// </summary>
        /// <param name="orderNumber">The number of the delivery order.</param>
        /// <returns>The delivery order.</returns>
        DeliveryOrder GetDeliveryOrder(string orderNumber);

        /// <summary>
        /// Async gets the delivery order by its number.
        /// </summary>
        /// <param name="orderNumber">The number of the delivery order.</param>
        /// <returns>The delivery order.</returns>
        Task<DeliveryOrder> GetDeliveryOrderAsync(string orderNumber);

        /// <summary>
        /// Gets all available delivery time intervals.
        /// </summary>
        /// <returns>List of <see cref="DeliveryTimeInterval"/>.</returns>
        List<DeliveryTimeInterval> GetDeliveryTimeIntervals();

        /// <summary>
        /// Async gets all available delivery time intervals.
        /// </summary>
        /// <returns>List of <see cref="DeliveryTimeInterval"/>.</returns>
        Task<List<DeliveryTimeInterval>> GetDeliveryTimeIntervalsAsync();
    }
}
