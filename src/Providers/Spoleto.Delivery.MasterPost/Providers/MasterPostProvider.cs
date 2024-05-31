using Spoleto.Common.Helpers;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// MasterPost delivery provider for delivery of goods.
    /// </summary>
    /// <remarks>
    /// <see href="https://mplogistics.ru"/>
    /// </remarks>
    public class MasterPostProvider : IMasterPostProvider, IDisposable
    {
        /// <summary>
        /// The name of the delivery provider.
        /// </summary>
        public const string ProviderName = nameof(DeliveryProviderName.MasterPost);

        private readonly MasterPostOptions _options;
        private readonly AuthCredentials _authCredentials;
        private readonly MasterPostClient _masterPostClient;

        public MasterPostProvider(MasterPostOptions options, AuthCredentials authCredentials)
        {
            if (options is null)
                throw new ArgumentNullException(nameof(options));

            if (authCredentials is null)
                throw new ArgumentNullException(nameof(authCredentials));

            // Validates if the options are valid
            options.Validate();

            _options = options;
            _authCredentials = authCredentials;

            _masterPostClient = new MasterPostClient(_options, _authCredentials);
        }

        public MasterPostProvider(MasterPostClient masterPostClient)
        {
            _masterPostClient = masterPostClient;
        }

        /// <inheritdoc/>
        public string Name => ProviderName;

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
        public List<Delivery.City> GetCities(Delivery.CityRequest cityRequest)
            => GetCitiesAsync(cityRequest).GetAwaiter().GetResult();

        /// <inheritdoc/>
        public async Task<List<Delivery.City>> GetCitiesAsync(Delivery.CityRequest cityRequest)
        {
            var model = cityRequest.ToCityRequest();
            var modelQuery = HttpHelper.ToQueryString(model);
            var restRequest = _masterPostClient.CreateJsonRestRequest<CityRequest>($"cities?{modelQuery}", RestClient.HttpMethod.Get);

            var cityList = await _masterPostClient.ExecuteAsync<List<City>>(restRequest).ConfigureAwait(false);

            return cityList.Select(x => x.ToDeliveryCity()).ToList();
        }

        /// <inheritdoc/>
        public List<Delivery.Tariff> GetTariffs(TariffRequest tariffRequest)
            => GetTariffsAsync(tariffRequest).GetAwaiter().GetResult();

        /// <inheritdoc/>
        public async Task<List<Delivery.Tariff>> GetTariffsAsync(TariffRequest tariffRequest)
        {
            // Получим все тарифы с их ценами в N + 1 запросов:
            // 1. Получение всех тарифов (без фильтрации по входным данным)
            // 2. N запросов для каждого тарифа из пункта 1, но уже с указанием входных данных (тарифный калькулятор).
            var serviceList = await GetServicesAsync().ConfigureAwait(false);

            var tariffList = new List<Tariff>();
            foreach (var service in serviceList) //todo: parallel.foreach?
            {
                var model = tariffRequest.ToTariffCalcRequest();
                model.DeliveryMode = service.DeliveryMode;
                model.IndividualClientNumber = _options.IndividualClientNumber;

                var restRequest = _masterPostClient.CreateJsonRestRequest("tariff_calc", RestClient.HttpMethod.Post, false, model);

                var tariff = await _masterPostClient.ExecuteAsync<Tariff>(restRequest).ConfigureAwait(false);
                tariffList.Add(tariff);
            }

            return tariffList.Select(x => x.ToDeliveryTariff()).ToList();
        }

        /// <inheritdoc/>
        public List<Service> GetServices()
            => GetServicesAsync().GetAwaiter().GetResult();

        /// <inheritdoc/>
        public async Task<List<Service>> GetServicesAsync()
        {
            var restRequest = _masterPostClient.CreateJsonRestRequest<object>($"services/{_options.IndividualClientNumber}", RestClient.HttpMethod.Get);

            var serviceList = await _masterPostClient.ExecuteAsync<List<Service>>(restRequest).ConfigureAwait(false);

            return serviceList;
        }

        /// <inheritdoc/>
        public List<AdditionalServiceInfo> GetAdditionalServices()
            => GetAdditionalServicesAsync().GetAwaiter().GetResult();

        /// <inheritdoc/>
        public async Task<List<AdditionalServiceInfo>> GetAdditionalServicesAsync()
        {
            var restRequest = _masterPostClient.CreateJsonRestRequest<object>($"add_services/{_options.IndividualClientNumber}", RestClient.HttpMethod.Get);

            var additionalServiceList = await _masterPostClient.ExecuteAsync<List<AdditionalServiceInfo>>(restRequest).ConfigureAwait(false);

            return additionalServiceList;
        }

        /// <inheritdoc/>
        public List<Street> GetStreets(StreetRequest streetRequest)
            => GetStreetsAsync(streetRequest).GetAwaiter().GetResult();

        /// <inheritdoc/>
        public async Task<List<Street>> GetStreetsAsync(StreetRequest streetRequest)
        {
            var modelQuery = HttpHelper.ToQueryString(streetRequest);
            var restRequest = _masterPostClient.CreateJsonRestRequest<CityRequest>($"streets?{modelQuery}", RestClient.HttpMethod.Get);

            var cityList = await _masterPostClient.ExecuteAsync<List<Street>>(restRequest).ConfigureAwait(false);

            return cityList;
        }

        /// <inheritdoc/>
        public DeliveryOrder CreateDeliveryOrder(Delivery.DeliveryOrderRequest deliveryOrderRequest)
            => CreateDeliveryOrderAsync(deliveryOrderRequest).GetAwaiter().GetResult();

        /// <inheritdoc/>
        public Task<DeliveryOrder> CreateDeliveryOrderAsync(Delivery.DeliveryOrderRequest deliveryOrderRequest)
        {
            throw new NotImplementedException();
        }
    }
}
