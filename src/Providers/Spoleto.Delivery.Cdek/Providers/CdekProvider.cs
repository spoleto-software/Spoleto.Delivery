using Spoleto.Common.Helpers;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// CDEK delivery provider for delivery of goods.
    /// </summary>
    /// <remarks>
    /// <see href="https://api-docs.cdek.ru/29923741.html"/>
    /// </remarks>
    public class CdekProvider : ICdekProvider
    {
        /// <summary>
        /// The name of the delivery provider.
        /// </summary>
        public const string ProviderName = nameof(DeliveryProviderName.Cdek);

        private readonly CdekOptions _options;
        private readonly AuthCredentials _authCredentials;
        private readonly CdekClient _cdekClient;

        public CdekProvider() : this(CdekOptions.Demo, AuthCredentials.Demo)
        {
        }

        public CdekProvider(CdekOptions options, AuthCredentials authCredentials)
        {
            if (options is null)
                throw new ArgumentNullException(nameof(options));

            if (authCredentials is null)
                throw new ArgumentNullException(nameof(authCredentials));

            // Validates if the options are valid
            options.Validate();

            _options = options;
            _authCredentials = authCredentials;

            _cdekClient = new CdekClient(_options, _authCredentials);
        }

        public CdekProvider(CdekClient cdekClient)
        {
            _cdekClient = cdekClient;
        }

        /// <inheritdoc/>
        public string Name => ProviderName;

        /// <inheritdoc/>
        public List<Delivery.City> GetCities(Delivery.CityRequest cityRequest)
            => GetCitiesAsync(cityRequest).GetAwaiter().GetResult();

        /// <inheritdoc/>
        public async Task<List<Delivery.City>> GetCitiesAsync(Delivery.CityRequest cityRequest)
        {
            var model = cityRequest.ToCityRequest();
            var modelQuery = HttpHelper.ToQueryString(model);
            var restRequest = _cdekClient.CreateJsonRestRequest<CityRequest>($"location/cities?{modelQuery}", RestClient.HttpMethod.Get);

            var cityList = await _cdekClient.ExecuteAsync<List<City>>(restRequest).ConfigureAwait(false);

            return cityList.Select(x => x.ToDeliveryCity()).ToList();
        }

        /// <inheritdoc/>
        public List<Delivery.Tariff> GetTariffs(Delivery.TariffRequest tariffRequest)
            => GetTariffsAsync(tariffRequest).GetAwaiter().GetResult();

        /// <inheritdoc/>
        public async Task<List<Delivery.Tariff>> GetTariffsAsync(Delivery.TariffRequest tariffRequest)
        {
            var model = tariffRequest.ToTariffRequest();
            var restRequest = _cdekClient.CreateJsonRestRequest("tarifflist", RestClient.HttpMethod.Post, false, model);

            var tariffList = await _cdekClient.ExecuteAsync<List<Tariff>>(restRequest).ConfigureAwait(false);

            return tariffList.Select(x => x.ToDeliveryTariff()).ToList();
        }
    }
}
