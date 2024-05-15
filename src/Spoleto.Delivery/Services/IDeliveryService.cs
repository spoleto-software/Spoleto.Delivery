using Spoleto.Delivery.Providers;

namespace Spoleto.Delivery.Services
{
    /// <summary>
    /// The Delivery service serves as an abstraction layer for delivery of goods.
    /// </summary>
    public interface IDeliveryService
    {
        List<Tariff> GetTariffs(TariffRequest tariffRequest);

        List<Tariff> GetTariffs(string providerName, TariffRequest tariffRequest);

        List<Tariff> GetTariffs(DeliveryProviderName providerName, TariffRequest tariffRequest);

        List<Tariff> GetTariffs(IDeliveryProvider provider, TariffRequest tariffRequest);

        Task<List<Tariff>> GetTariffsAsync(TariffRequest tariffRequest);

        Task<List<Tariff>> GetTariffsAsync(string providerName, TariffRequest tariffRequest);

        Task<List<Tariff>> GetTariffsAsync(DeliveryProviderName providerName, TariffRequest tariffRequest);

        Task<List<Tariff>> GetTariffsAsync(IDeliveryProvider provider, TariffRequest tariffRequest);
    }
}
