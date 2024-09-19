﻿using Spoleto.AddressResolver;
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

        /// <inheritdoc/>
        public override async Task<List<Delivery.Tariff>> GetTariffsAsync(Delivery.TariffRequest tariffRequest)
        {
            // Получим все тарифы с их ценами в N + 1 запросов:
            // 1. Получение всех тарифов (без фильтрации по входным данным)
            // 2. N запросов для каждого тарифа из пункта 1, но уже с указанием входных данных (тарифный калькулятор).
            var serviceList = await GetServicesAsync().ConfigureAwait(false);

            if (tariffRequest.FromLocation.CityFiasId == null && _addressResolver != null)
            {
                var addressFrom = await _addressResolver.ResolveLocationAsync(tariffRequest.FromLocation.Address).ConfigureAwait(false);
                tariffRequest.FromLocation.CityFiasId = addressFrom.CityFiasId;
            }

            if (tariffRequest.ToLocation.CityFiasId == null && _addressResolver != null)
            {
                var addressTo = await _addressResolver.ResolveLocationAsync(tariffRequest.FromLocation.Address).ConfigureAwait(false);
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

        /// <inheritdoc/>
        public override async Task<Delivery.DeliveryOrder> CreateDeliveryOrderAsync(Delivery.CreateDeliveryOrderRequest deliveryOrderRequest)
        {
            var model = deliveryOrderRequest.ToOrderRequest();
            model.IndividualClientNumber = _options.IndividualClientNumber;

            var restRequest = new RestRequestFactory(RestHttpMethod.Post, "dns")
                .WithJsonContent(model)
                .Build();

            (var deliveryOrderList, var rawBody) = await _masterPostClient.ExecuteWithRawBodyAsync<List<DeliveryOrder>>(restRequest).ConfigureAwait(false);
            var deliveryOrder = deliveryOrderList[0];
            
            var order = deliveryOrder.ToDeliveryOrder(_options.ServiceUrl);
            order.RawBody = rawBody;

            return order;
        }

        /// <inheritdoc/>
        public override async Task<Delivery.DeliveryOrder> GetDeliveryOrderAsync(GetDeliveryOrderRequest deliveryOrderRequest)
        {
            var number = deliveryOrderRequest.Uuid?.ToString() ?? deliveryOrderRequest.Number ?? deliveryOrderRequest.CisNumber ?? throw new ArgumentNullException(nameof(deliveryOrderRequest.CisNumber));
           
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
            throw new NotImplementedException();
        }
    }
}
