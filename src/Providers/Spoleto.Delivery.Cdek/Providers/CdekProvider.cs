
namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// CDEK delivery provider for delivery of goods.
    /// </summary>
    public class CdekProvider : ICdekProvider
    {
        /// <summary>
        /// The name of the delivery provider.
        /// </summary>
        public const string ProviderName = nameof(DeliveryProviderName.Cdek);

        private readonly CdekOptions _options;

        public CdekProvider(CdekOptions options)
        {
            if (options is null)
                throw new ArgumentNullException(nameof(options));

            // Validates if the options are valid
            options.Validate();
            _options = options;
        }

        /// <inheritdoc/>
        public string Name => ProviderName;

        public DeliveryStatusResult GetStatus(string id)
        {
            throw new NotImplementedException();
        }

        public Task<DeliveryStatusResult> GetStatusAsync(string id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public List<Delivery.Tariff> GetTariffs(TariffRequest tariffRequest)
            => GetTariffsAsync(tariffRequest).GetAwaiter().GetResult();

        public Task<List<Delivery.Tariff>> GetTariffsAsync(TariffRequest tariffRequest)
        {
            throw new NotImplementedException();
        }

        public DeliverySendingResult Send(GoodsDelivery goodsDelivery)
        {
            throw new NotImplementedException();
        }

        public Task<DeliverySendingResult> SendAsync(GoodsDelivery GoodsDelivery, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
