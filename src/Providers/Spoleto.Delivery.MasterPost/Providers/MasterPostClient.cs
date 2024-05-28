using Spoleto.RestClient;
using Spoleto.RestClient.Authentication;

namespace Spoleto.Delivery.Providers.MasterPost
{
    public class MasterPostClient : Spoleto.RestClient.RestClient
    {
        private const string TokenTypeName = "ADD_DATA";

        private readonly MasterPostOptions _masterPostOptions;

        public MasterPostClient(MasterPostOptions masterPostOptions, AuthCredentials authCredentials)
            : this(CreateNewClient(masterPostOptions), CreateAuthenticator(authCredentials), RestClientOptions.Default, true)
        {
            _masterPostOptions = masterPostOptions;
        }

        private static HttpClient CreateNewClient(MasterPostOptions masterPostOptions) //todo: should use Polly?
        {
            var httpClient = new HttpClient { BaseAddress = new Uri(masterPostOptions.ServiceUrl) };

            return httpClient;
        }

        private static IAuthenticator CreateAuthenticator(AuthCredentials authCredentials)
        {
            var authenticator = new StaticAuthenticator(TokenTypeName, authCredentials.ApiKey);

            return authenticator;
        }

        public MasterPostClient(HttpClient httpClient, IAuthenticator? authenticator = null, RestClientOptions? options = null, bool disposeHttpClient = false) : base(httpClient, authenticator, options, disposeHttpClient)
        {
        }
    }
}
