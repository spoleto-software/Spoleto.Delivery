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

        
    }
}
