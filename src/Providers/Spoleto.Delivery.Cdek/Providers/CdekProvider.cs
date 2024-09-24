using Spoleto.AddressResolver;
using Spoleto.RestClient;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// CDEK delivery provider for delivery of goods.
    /// </summary>
    /// <remarks>
    /// <see href="https://api-docs.cdek.ru/29923741.html"/>
    /// </remarks>
    public partial class CdekProvider : DeliveryProviderBase, ICdekProvider, IDisposable
    {
        /// <summary>
        /// The name of the delivery provider.
        /// </summary>
        public const string ProviderName = nameof(DeliveryProviderName.Cdek);

        private readonly CdekOptions _options;
        private readonly IAddressResolver? _addressResolver;
        private readonly CdekClient _cdekClient;

        public CdekProvider() : this(CdekOptions.Demo)
        {
        }

        public CdekProvider(CdekOptions options, IAddressResolver? addressResolver = null)
        {
            if (options is null)
                throw new ArgumentNullException(nameof(options));

            if (options.AuthCredentials is null)
                throw new ArgumentNullException(nameof(options.AuthCredentials));

            // Validates if the options are valid
            options.Validate();

            _options = options;
            _addressResolver = addressResolver;

            _cdekClient = new CdekClient(_options);
        }

        public CdekProvider(CdekClient cdekClient)
        {
            _cdekClient = cdekClient;
        }

        /// <inheritdoc/>
        public override string Name => ProviderName;

        /// <inheritdoc/>
        public override List<Delivery.OrderType> SupportedOrderTypes => new() { Delivery.OrderType.RegularDelivery, Delivery.OrderType.OnlineStore };

        #region IDisposable
        bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                _disposed = true;
                _cdekClient?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        /// <inheritdoc/>
        public override async Task<List<Delivery.City>> GetCitiesAsync(Delivery.CityRequest cityRequest)
        {
            var model = cityRequest.ToCityRequest();
            var restRequest = new RestRequestFactory(RestHttpMethod.Get, $"location/cities")
                .WithQueryString(model)
                .Build();

            var cityList = await _cdekClient.ExecuteAsync<List<City>>(restRequest).ConfigureAwait(false);

            return cityList.Select(x => x.ToDeliveryCity()).ToList();
        }

        public override List<Delivery.DeliveryPoint> GetDeliveryPoints(Delivery.DeliveryPointRequest deliveryPointRequest)
        {
            if (deliveryPointRequest.ProviderCityCode == null && deliveryPointRequest.FiasId == null && _addressResolver == null)
                throw new ArgumentNullException(nameof(deliveryPointRequest.FiasId), $"{nameof(deliveryPointRequest.FiasId)} or {nameof(deliveryPointRequest.ProviderCityCode)} must be specified or the address resolver must be initialized.");

            if (deliveryPointRequest.ProviderCityCode == null && deliveryPointRequest.FiasId == null && _addressResolver != null)
            {
                if (deliveryPointRequest.Address == null)
                    throw new ArgumentNullException(nameof(deliveryPointRequest.Address));

                var location = _addressResolver.ResolveLocation(deliveryPointRequest.Address);
                if (location == null)
                    throw new ArgumentException($"Could not find the full address for <{deliveryPointRequest.Address}>.");

                deliveryPointRequest.FiasId = location.CityFiasId;
            }

            return base.GetDeliveryPoints(deliveryPointRequest);
        }

        /// <inheritdoc/>
        public override async Task<List<Delivery.DeliveryPoint>> GetDeliveryPointsAsync(Delivery.DeliveryPointRequest deliveryPointRequest)
        {
            if (deliveryPointRequest.ProviderCityCode == null && deliveryPointRequest.FiasId == null && _addressResolver == null)
                throw new ArgumentNullException(nameof(deliveryPointRequest.FiasId), $"{nameof(deliveryPointRequest.FiasId)} or {nameof(deliveryPointRequest.ProviderCityCode)} must be specified or the address resolver must be initialized.");

            if (deliveryPointRequest.ProviderCityCode == null && deliveryPointRequest.FiasId == null && _addressResolver != null)
            {
                if (deliveryPointRequest.Address == null)
                    throw new ArgumentNullException(nameof(deliveryPointRequest.Address));

                var location = await _addressResolver.ResolveLocationAsync(deliveryPointRequest.Address).ConfigureAwait(false);
                if (location == null)
                    throw new ArgumentException($"Could not find the full address for <{deliveryPointRequest.Address}>.");

                deliveryPointRequest.FiasId = location.CityFiasId;
            }

            var model = deliveryPointRequest.ToDeliveryPointRequest();
            var restRequest = new RestRequestFactory(RestHttpMethod.Get, $"deliverypoints")
                .WithQueryString(model)
                .Build();

            var deliveryPointList = await _cdekClient.ExecuteAsync<List<DeliveryPoint>>(restRequest).ConfigureAwait(false);

            return deliveryPointList.Select(x => x.ToDeliveryPoint()).ToList();
        }

        /// <inheritdoc/>
        public override async Task<List<Delivery.Tariff>> GetTariffsAsync(Delivery.TariffRequest tariffRequest)
        {
            var model = tariffRequest.ToTariffRequest();
            var restRequest = new RestRequestFactory(RestHttpMethod.Post, "calculator/tarifflist")
                .WithJsonContent(model)
                .Build();

            var tariffList = await _cdekClient.ExecuteAsync<TariffList>(restRequest).ConfigureAwait(false);

            if (tariffList.Errors?.Count > 0)
            {
                throw new Exception(string.Join(Environment.NewLine, tariffList.Errors.Select(x => x.ToString())));
            }

            return tariffList.Tariffs.Select(x => x.ToDeliveryTariff()).ToList();
        }

        /// <inheritdoc/>
        public override Task<List<Delivery.AdditionalService>> GetAdditionalServicesAsync(Delivery.Tariff tariff)
        {
            var allAdditionalServices = GetAdditionalServices();
            var additionalServices = allAdditionalServices.Select(x => new Delivery.AdditionalService { Code = x.Code, Name = x.Name, Description = x.Description, ParameterType = x.ParameterType }).ToList();

            return Task.FromResult(additionalServices);
        }

        /// <inheritdoc/>
        public override async Task<Delivery.DeliveryOrder> CreateDeliveryOrderAsync(Delivery.CreateDeliveryOrderRequest deliveryOrderRequest)
        {
            var model = deliveryOrderRequest.ToCreateOrderRequest();
            var restRequest = new RestRequestFactory(RestHttpMethod.Post, "orders")
                .WithJsonContent(model)
                .Build();

            (var deliveryOrder, var rawBody) = await _cdekClient.ExecuteWithRawBodyAsync<CreatedDeliveryOrder>(restRequest).ConfigureAwait(false);

            var order = deliveryOrder.ToDeliveryOrder();
            order.RawBody = rawBody;

            return order;
        }

        /// <inheritdoc/>
        public override async Task<Delivery.DeliveryOrder> GetDeliveryOrderAsync(GetDeliveryOrderRequest deliveryOrderRequest)
        {
            var uri = deliveryOrderRequest.Uuid != null ? $"orders/{deliveryOrderRequest.Uuid}"
                : !string.IsNullOrEmpty(deliveryOrderRequest.Number) ? $"orders?cdek_number={deliveryOrderRequest.Number}"
                : !string.IsNullOrEmpty(deliveryOrderRequest.CisNumber) ? $"orders?im_number={deliveryOrderRequest.CisNumber}"
                : throw new ArgumentNullException(nameof(deliveryOrderRequest.CisNumber));

            var restRequest = new RestRequestFactory(RestHttpMethod.Get, uri)
                .Build();

            (var deliveryOrder, var rawBody) = await _cdekClient.ExecuteWithRawBodyAsync<DeliveryOrder>(restRequest).ConfigureAwait(false);

            var order = deliveryOrder.ToDeliveryOrder();
            order.RawBody = rawBody;

            return order;
        }

        /// <inheritdoc/>
        public override async Task<Delivery.DeliveryOrder> DeleteDeliveryOrderAsync(string orderId)
        {
            var restRequest = new RestRequestFactory(RestHttpMethod.Delete, $"orders/{orderId}")
                .Build();

            var deliveryOrder = await _cdekClient.ExecuteAsync<CreatedDeliveryOrder>(restRequest).ConfigureAwait(false);

            return deliveryOrder.ToDeliveryOrder();
        }

        /// <inheritdoc/>
        public override async Task<Delivery.DeliveryOrder> UpdateDeliveryOrderAsync(Delivery.UpdateDeliveryOrderRequest deliveryOrderRequest)
        {
            var model = deliveryOrderRequest.ToOrderRequest();
            var restRequest = new RestRequestFactory(RestHttpMethod.Patch, "orders")
                .WithJsonContent(model)
                .Build();

            (var deliveryOrder, var rawBody) = await _cdekClient.ExecuteWithRawBodyAsync<UpdatedDeliveryOrder>(restRequest).ConfigureAwait(false);

            var order = deliveryOrder.ToDeliveryOrder();
            order.RawBody = rawBody;

            return order;
        }
    }
}
