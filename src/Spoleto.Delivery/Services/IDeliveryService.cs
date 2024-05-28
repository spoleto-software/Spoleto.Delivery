using Spoleto.Delivery.Providers;

namespace Spoleto.Delivery.Services
{
    /// <summary>
    /// The Delivery service serves as an abstraction layer for delivery of goods.
    /// </summary>
    public interface IDeliveryService
    {
        #region Cities
        List<City> GetCities(CityRequest cityRequest);

        List<City> GetCities(string providerName, CityRequest cityRequest);

        List<City> GetCities(DeliveryProviderName providerName, CityRequest cityRequest);

        List<City> GetCities(IDeliveryProvider provider, CityRequest cityRequest);

        Task<List<City>> GetCitiesAsync(CityRequest cityRequest);

        Task<List<City>> GetCitiesAsync(string providerName, CityRequest cityRequest);

        Task<List<City>> GetCitiesAsync(DeliveryProviderName providerName, CityRequest cityRequest);

        Task<List<City>> GetCitiesAsync(IDeliveryProvider provider, CityRequest cityRequest);
        #endregion

        #region Tariffs
        List<Tariff> GetTariffs(TariffRequest tariffRequest);

        List<Tariff> GetTariffs(string providerName, TariffRequest tariffRequest);

        List<Tariff> GetTariffs(DeliveryProviderName providerName, TariffRequest tariffRequest);

        List<Tariff> GetTariffs(IDeliveryProvider provider, TariffRequest tariffRequest);

        Task<List<Tariff>> GetTariffsAsync(TariffRequest tariffRequest);

        Task<List<Tariff>> GetTariffsAsync(string providerName, TariffRequest tariffRequest);

        Task<List<Tariff>> GetTariffsAsync(DeliveryProviderName providerName, TariffRequest tariffRequest);

        Task<List<Tariff>> GetTariffsAsync(IDeliveryProvider provider, TariffRequest tariffRequest);
        #endregion
    }
}
