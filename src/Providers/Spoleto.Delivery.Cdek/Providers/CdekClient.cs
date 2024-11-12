using Spoleto.RestClient;
using Spoleto.RestClient.Authentication;
using Spoleto.RestClient.Serializers;

namespace Spoleto.Delivery.Providers.Cdek
{
    public class CdekClient : RestHttpClient
    {
        private readonly CdekOptions _cdekOptions;

        private readonly HashSet<string> _orderNotFoundCodes = ["v2_entity_not_found", "v2_order_not_found"];

        public CdekClient() : this(CdekOptions.Demo)
        {
        }

        public CdekClient(CdekOptions cdekOptions)
            : this(cdekOptions, CreateNewClient(cdekOptions), CreateAuthenticator(cdekOptions.AuthCredentials), RestClientOptions.Default, true)
        {
            
        }

        public CdekClient(CdekOptions cdekOptions, HttpClient httpClient, IAuthenticator? authenticator = null, RestClientOptions? options = null, bool disposeHttpClient = false)
            : base(httpClient, authenticator, options, disposeHttpClient)
        {
            _cdekOptions = cdekOptions;
        }

        private static HttpClient CreateNewClient(CdekOptions cdekOptions) //todo: should use Polly?
        {
            var httpClient = new HttpClient { BaseAddress = new Uri(cdekOptions.ServiceUrl) };

            return httpClient;
        }

        private static IAuthenticator CreateAuthenticator(AuthCredentials authCredentials)
        {
            var authenticator = new CdekAuthenticator(authCredentials);

            return authenticator;
        }

        public override bool NotFound(IRestResponse restResponse)
        {
            if (restResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var content = restResponse.GetContent();

                if (content is string json
                   && !string.IsNullOrEmpty(json))
                {
                    var objectResult = SerializationManager.Deserialize<DeliveryOrder>(restResponse);
                    var errorCodes = objectResult?.Requests?.Where(x => x.Errors != null).SelectMany(x => x.Errors!).Select(x => x.Code);
                    if (errorCodes != null &&
                        _orderNotFoundCodes.Any(x => errorCodes.Contains(x)))
                    {
                        return true;
                    }
                }
            }

            return base.NotFound(restResponse);
        }
    }
}
