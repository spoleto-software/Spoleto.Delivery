using Spoleto.AddressResolver;
using Spoleto.RestClient;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// MasterPost delivery provider for delivery of goods.
    /// </summary>
    /// <remarks>
    /// <see href="https://mplogistics.ru"/>
    /// </remarks>
    public partial class MasterPostProvider : DeliveryProviderBase, IDeliveryProvider, IDisposable
    {
        /// <summary>
        /// The name of the delivery provider.
        /// </summary>
        public const string ProviderName = nameof(DeliveryProviderName.MasterPost);

        private readonly MasterPostOptions _options;
        private readonly IAddressResolver? _addressResolver;
        private readonly MasterPostClient _masterPostClient;

        public MasterPostProvider(MasterPostOptions options, IAddressResolver? addressResolver = null)
        {
            if (options is null)
                throw new ArgumentNullException(nameof(options));

            if (options.AuthCredentials is null)
                throw new ArgumentNullException(nameof(options.AuthCredentials));

            // Validates if the options are valid
            options.Validate();

            _options = options;
            _addressResolver = addressResolver;

            _masterPostClient = new MasterPostClient(options);
        }

        /// <inheritdoc/>
        public override string Name => ProviderName;

        #region IDisposable
        bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                _disposed = true;
                _masterPostClient?.Dispose();
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
            var restRequest = new RestRequestFactory(RestHttpMethod.Get, $"cities")
                .WithQueryString(model)
                .Build();

            var cityList = await _masterPostClient.ExecuteAsync<List<City>>(restRequest).ConfigureAwait(false);

            return cityList.Select(x => x.ToDeliveryCity()).ToList();
        }

        /// <inheritdoc/>
        public override Task<List<Delivery.DeliveryPoint>> GetDeliveryPointsAsync(Delivery.DeliveryPointRequest deliveryPointRequest)
        {
            return Task.FromResult(new List<Delivery.DeliveryPoint>());
        }

        public override List<Delivery.Tariff> GetTariffs(Delivery.TariffRequest tariffRequest)
        {
            if (tariffRequest.FromLocation.CityFiasId == null && _addressResolver != null)
            {
                if (tariffRequest.FromLocation.Address == null)
                    throw new ArgumentNullException($"{nameof(tariffRequest.FromLocation)}.{nameof(tariffRequest.FromLocation.Address)}");

                var addressFrom = _addressResolver.ResolveLocation(tariffRequest.FromLocation.Address);
                tariffRequest.FromLocation.CityFiasId = addressFrom.CityFiasId;
            }

            if (tariffRequest.ToLocation.CityFiasId == null && _addressResolver != null)
            {
                if (tariffRequest.ToLocation.Address == null)
                    throw new ArgumentNullException($"{nameof(tariffRequest.ToLocation)}.{nameof(tariffRequest.ToLocation.Address)}");

                var addressTo = _addressResolver.ResolveLocation(tariffRequest.ToLocation.Address);
                tariffRequest.ToLocation.CityFiasId = addressTo.CityFiasId;
            }

            return base.GetTariffs(tariffRequest);
        }

        /// <inheritdoc/>
        public override async Task<List<Delivery.Tariff>> GetTariffsAsync(Delivery.TariffRequest tariffRequest)
        {
            // Получим все тарифы с их ценами в N + 1 запросов:
            // 1. Получение всех тарифов (без фильтрации по входным данным)
            // 2. N запросов для каждого тарифа из пункта 1, но уже с указанием входных данных (тарифный калькулятор).
            var serviceList = await GetServicesAsync().ConfigureAwait(false);

            if (tariffRequest.FromLocation.CityFiasId == null && _addressResolver != null)
            {
                if (tariffRequest.FromLocation.Address == null)
                    throw new ArgumentNullException($"{nameof(tariffRequest.FromLocation)}.{nameof(tariffRequest.FromLocation.Address)}");

                var addressFrom = await _addressResolver.ResolveLocationAsync(tariffRequest.FromLocation.Address).ConfigureAwait(false);
                tariffRequest.FromLocation.CityFiasId = addressFrom.CityFiasId;
            }

            if (tariffRequest.ToLocation.CityFiasId == null && _addressResolver != null)
            {
                if (tariffRequest.ToLocation.Address == null)
                    throw new ArgumentNullException($"{nameof(tariffRequest.ToLocation)}.{nameof(tariffRequest.ToLocation.Address)}");

                var addressTo = await _addressResolver.ResolveLocationAsync(tariffRequest.ToLocation.Address).ConfigureAwait(false);
                tariffRequest.ToLocation.CityFiasId = addressTo.CityFiasId;
            }

            var tariffList = new List<Tariff>();
            foreach (var service in serviceList) //todo: parallel.foreach?
            {
                var model = tariffRequest.ToTariffRequest();
                model.DeliveryMode = service.DeliveryMode;
                model.IndividualClientNumber = _options.IndividualClientNumber;

                var restRequest = new RestRequestFactory(RestHttpMethod.Post, "tariff_calc")
                    .WithJsonContent(model)
                    .Build();

                var tariff = await _masterPostClient.ExecuteAsync<Tariff>(restRequest).ConfigureAwait(false);
                tariff.Name = model.DeliveryMode;
                tariffList.Add(tariff);
            }

            return tariffList.Select(x => x.ToDeliveryTariff()).ToList();
        }

        /// <inheritdoc/>
        public override async Task<List<Delivery.AdditionalService>> GetAdditionalServicesAsync(Delivery.Tariff tariff)
        {
            var allAdditionalServiceList = await GetAdditionalServicesAsync().ConfigureAwait(false);
            var additionalServiceList = allAdditionalServiceList
                .Where(x => x.DeliveryMode == tariff.Name)
                .SelectMany(x => x.AdditionalServices)
                .Where(x => x.Usage != UsageKind.Never);

            return additionalServiceList.Select(x => x.ToDeliveryAdditionalService()).ToList();
        }

        public override Delivery.DeliveryOrder CreateDeliveryOrder(Delivery.CreateDeliveryOrderRequest deliveryOrderRequest, bool ensureStatus)
        {
            if (deliveryOrderRequest.FromLocation.CityFiasId == null && _addressResolver != null)
            {
                if (deliveryOrderRequest.FromLocation.Address == null)
                    throw new ArgumentNullException($"{nameof(deliveryOrderRequest.FromLocation)}.{nameof(deliveryOrderRequest.FromLocation.Address)}");

                var addressFrom = _addressResolver.ResolveLocation(deliveryOrderRequest.FromLocation.Address);
                deliveryOrderRequest.FromLocation.CityFiasId = addressFrom.CityFiasId;
            }

            if (deliveryOrderRequest.ToLocation.CityFiasId == null && _addressResolver != null)
            {
                if (deliveryOrderRequest.ToLocation.Address == null)
                    throw new ArgumentNullException($"{nameof(deliveryOrderRequest.ToLocation)}.{nameof(deliveryOrderRequest.ToLocation.Address)}");

                var addressTo = _addressResolver.ResolveLocation(deliveryOrderRequest.ToLocation.Address);
                deliveryOrderRequest.ToLocation.CityFiasId = addressTo.CityFiasId;
            }

            return base.CreateDeliveryOrder(deliveryOrderRequest, ensureStatus);
        }

        /// <inheritdoc/>
        public override async Task<Delivery.DeliveryOrder> CreateDeliveryOrderAsync(Delivery.CreateDeliveryOrderRequest deliveryOrderRequest, bool ensureStatus)
        {
            if (deliveryOrderRequest.FromLocation.CityFiasId == null && _addressResolver != null)
            {
                if (deliveryOrderRequest.FromLocation.Address == null)
                    throw new ArgumentNullException($"{nameof(deliveryOrderRequest.FromLocation)}.{nameof(deliveryOrderRequest.FromLocation.Address)}");

                var addressFrom = await _addressResolver.ResolveLocationAsync(deliveryOrderRequest.FromLocation.Address).ConfigureAwait(false);
                deliveryOrderRequest.FromLocation.CityFiasId = addressFrom.CityFiasId;
            }

            if (deliveryOrderRequest.ToLocation.CityFiasId == null && _addressResolver != null)
            {
                if (deliveryOrderRequest.ToLocation.Address == null)
                    throw new ArgumentNullException($"{nameof(deliveryOrderRequest.ToLocation)}.{nameof(deliveryOrderRequest.ToLocation.Address)}");

                var addressTo = await _addressResolver.ResolveLocationAsync(deliveryOrderRequest.ToLocation.Address).ConfigureAwait(false);
                deliveryOrderRequest.ToLocation.CityFiasId = addressTo.CityFiasId;
            }

            var model = deliveryOrderRequest.ToCreateOrderRequest();
            model.IndividualClientNumber = _options.IndividualClientNumber;

            var restRequest = new RestRequestFactory(RestHttpMethod.Post, "dns")
                .WithJsonContent(model)
                .Build();

            (var deliveryOrderList, var rawBody) = await _masterPostClient.ExecuteWithRawBodyAsync<List<DeliveryOrder>>(restRequest).ConfigureAwait(false);
            var deliveryOrder = deliveryOrderList[0];
            
            var order = deliveryOrder.ToDeliveryOrder(_options.ServiceUrl);
            order.RawBody = rawBody;

            if (ensureStatus)
            {
                if (order.Status == null)
                {
                    order = await GetDeliveryOrderAsync(new GetDeliveryOrderRequest { Number = order.Number });

                    if (order.Status == null)
                        throw new ArgumentException("The created order status is null.");
                }
            }

            if (deliveryOrderRequest.CourierPickupRequest is CourierPickupRequest courierPickupRequest)
            {
                //todo: надо ли тут явно создавать этот CourierPickup?
                order.CourierPickup = new CourierPickup
                {
                    IntakeDate = courierPickupRequest.IntakeDate,
                    IntakeTimeFrom = courierPickupRequest.IntakeTimeFrom,
                    IntakeTimeTo = courierPickupRequest.IntakeTimeTo
                };
            }

            return order;
        }

        /// <inheritdoc/>
        public override async Task<Delivery.DeliveryOrder> GetDeliveryOrderAsync(GetDeliveryOrderRequest deliveryOrderRequest)
        {
            var number = deliveryOrderRequest.Uuid?.ToString() ?? deliveryOrderRequest.Number ?? deliveryOrderRequest.CisNumber ?? throw new ArgumentNullException(nameof(deliveryOrderRequest.Number));
           
            var restRequest = new RestRequestFactory(RestHttpMethod.Get, $"dns/{number}").Build();

            (var deliveryOrderList, var rawBody) = await _masterPostClient.ExecuteWithRawBodyAsync<List<DeliveryOrder>>(restRequest).ConfigureAwait(false);
            var deliveryOrder = deliveryOrderList[0];

            var order = deliveryOrder.ToDeliveryOrder(_options.ServiceUrl);
            order.RawBody = rawBody;

            return order;
        }

        /// <inheritdoc/>
        public override async Task<Delivery.DeliveryOrder> DeleteDeliveryOrderAsync(string orderId)
        {
            var restRequest = new RestRequestFactory(RestHttpMethod.Put, $"dns/{_options.IndividualClientNumber}/{orderId}")
                .Build();

            (var deliveryOrderList, var rawBody) = await _masterPostClient.ExecuteWithRawBodyAsync<List<DeliveryOrder>>(restRequest).ConfigureAwait(false);
            var deliveryOrder = deliveryOrderList[0];
            
            var order = deliveryOrder.ToDeliveryOrder(_options.ServiceUrl);
            order.RawBody = rawBody;

            return order;
        }

        /// <inheritdoc/>
        public override Task<Delivery.DeliveryOrder> UpdateDeliveryOrderAsync(UpdateDeliveryOrderRequest deliveryOrderRequest)
        {
            //todo: delete + create a new order?
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override Task<CourierPickup> CreateCourierPickupAsync(CreateCourierPickupRequest createCourierPickupRequest, bool ensureStatus)
        {
            return Task.FromResult<CourierPickup>(default);
        }

        /// <inheritdoc/>
        public override Task<CourierPickup> GetCourierPickupAsync(GetCourierPickupRequest getCourierPickupRequest)
        {
            return Task.FromResult<CourierPickup>(default);
        }

        /// <inheritdoc/>
        public override Task<CourierPickup> DeleteCourierPickupAsync(string pickupOrderId)
        {
            return Task.FromResult<CourierPickup>(default);
        }
    }
}
