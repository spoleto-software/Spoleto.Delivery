
namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// MasterPost delivery provider for delivery of goods.
    /// </summary>
    public class MasterPostProvider : IMasterPostProvider
    {
        /// <summary>
        /// The name of the delivery provider.
        /// </summary>
        public string Name => nameof(DeliveryProviderName.MasterPost);

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
