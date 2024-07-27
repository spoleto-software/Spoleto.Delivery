using Spoleto.RestClient;

namespace Spoleto.Delivery.Providers.MasterPost
{
    public partial class MasterPostProvider : IMasterPostProvider
    {
        /// <inheritdoc/>
        public List<Service> GetServices()
            => GetServicesAsync().GetAwaiter().GetResult();

        /// <inheritdoc/>
        public async Task<List<Service>> GetServicesAsync()
        {
            var restRequest = new RestRequestFactory(RestHttpMethod.Get, $"services/{_options.IndividualClientNumber}").Build();

            var serviceList = await _masterPostClient.ExecuteAsync<List<Service>>(restRequest).ConfigureAwait(false);

            return serviceList;
        }

        /// <inheritdoc/>
        public List<AdditionalServiceInfo> GetAdditionalServices()
            => GetAdditionalServicesAsync().GetAwaiter().GetResult();

        /// <inheritdoc/>
        public async Task<List<AdditionalServiceInfo>> GetAdditionalServicesAsync()
        {
            var restRequest = new RestRequestFactory(RestHttpMethod.Get, $"add_services/{_options.IndividualClientNumber}").Build();

            var additionalServiceList = await _masterPostClient.ExecuteAsync<List<AdditionalServiceInfo>>(restRequest).ConfigureAwait(false);

            return additionalServiceList;
        }

        /// <inheritdoc/>
        public List<Street> GetStreets(StreetRequest streetRequest)
            => GetStreetsAsync(streetRequest).GetAwaiter().GetResult();

        /// <inheritdoc/>
        public async Task<List<Street>> GetStreetsAsync(StreetRequest streetRequest)
        {
            var restRequest = new RestRequestFactory(RestHttpMethod.Get, $"streets")
                .WithQueryString(streetRequest)
                .Build();

            var cityList = await _masterPostClient.ExecuteAsync<List<Street>>(restRequest).ConfigureAwait(false);

            return cityList;
        }

        /// <inheritdoc/>
        public DeliveryOrder GetDeliveryOrder(string orderNumber)
            => GetDeliveryOrderAsync(orderNumber).GetAwaiter().GetResult();

        /// <inheritdoc/>
        public async Task<DeliveryOrder> GetDeliveryOrderAsync(string orderNumber)
        {
            var restRequest = new RestRequestFactory(RestHttpMethod.Get, $"dns/{orderNumber}").Build();

            var deliveryOrderList= await _masterPostClient.ExecuteAsync<List<DeliveryOrder>>(restRequest).ConfigureAwait(false);
            var deliveryOrder = deliveryOrderList[0];
            
            return deliveryOrder;
        }
    }
}
