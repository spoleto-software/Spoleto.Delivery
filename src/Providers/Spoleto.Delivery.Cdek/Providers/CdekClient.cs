using Spoleto.RestClient;
using Spoleto.RestClient.Authentication;

namespace Spoleto.Delivery.Providers.Cdek
{
    public class CdekClient : Spoleto.RestClient.RestClient
    {
        private readonly CdekOptions _cdekOptions;

        public CdekClient() : this(CdekOptions.Demo, AuthCredentials.Demo)
        {
        }

        public CdekClient(CdekOptions cdekOptions, AuthCredentials authCredentials)
            : this(CreateNewClient(cdekOptions), CreateAuthenticator(authCredentials), RestClientOptions.Default, true)
        {
            _cdekOptions = cdekOptions;
        }

        public CdekClient(HttpClient httpClient, IAuthenticator? authenticator = null, RestClientOptions? options = null, bool disposeHttpClient = false)
            : base(httpClient, authenticator, options, disposeHttpClient)
        {
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
    }
}
