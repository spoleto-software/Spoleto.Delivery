using Spoleto.Delivery.Callback.Common.Models;

namespace Spoleto.Delivery.Callback.Common.Services
{
    // replace with your logic
    public class FakeRepository : IRepository
    {
        public Task<bool> UpdateDeliveryOrderStatusAsync(string externalId, string deliveryStatus, CancellationToken cancellationToken = default)
            => Task.FromResult(true); // replace with your logic


        public Task<List<DeliveryOrderViewModel>> GetDeliveryOrdersWithNonFinalStatusAsync(CancellationToken cancellationToken = default)
            => Task.FromResult(new List<DeliveryOrderViewModel>()); // replace with your logic
    }
}
