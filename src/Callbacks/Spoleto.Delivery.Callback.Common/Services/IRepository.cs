using Spoleto.Delivery.Callback.Common.Models;

namespace Spoleto.Delivery.Callback.Common.Services
{
    public interface IRepository
    {
        Task<List<DeliveryOrderViewModel>> GetDeliveryOrdersWithNonFinalStatusAsync(CancellationToken cancellationToken = default);

        Task<bool> UpdateDeliveryOrderStatusAsync(string externalId, string deliveryStatus, CancellationToken cancellationToken = default);
    }
}
