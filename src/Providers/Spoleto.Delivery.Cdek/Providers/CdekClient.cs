using Spoleto.RestClient;
using Spoleto.RestClient.Authentication;

namespace Spoleto.Delivery.Providers.Cdek
{
    public class CdekClient : RestHttpClient
    {
        private readonly CdekOptions _cdekOptions;

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
    }
}
