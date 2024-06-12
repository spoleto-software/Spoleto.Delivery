using Spoleto.RestClient;
using Spoleto.RestClient.Authentication;

namespace Spoleto.Delivery.Providers.MasterPost
{
    public class MasterPostClient : Spoleto.RestClient.RestHttpClient
    {
        private const string TokenTypeName = "ADD_DATA";

        private readonly MasterPostOptions _masterPostOptions;

        public MasterPostClient(MasterPostOptions masterPostOptions)
            : this(masterPostOptions, CreateNewClient(masterPostOptions), CreateAuthenticator(masterPostOptions.AuthCredentials), RestClientOptions.Default, true)
        {
        }

        public MasterPostClient(MasterPostOptions masterPostOptions, HttpClient httpClient, IAuthenticator? authenticator = null, RestClientOptions? options = null, bool disposeHttpClient = false)
            : base(httpClient, authenticator, options, disposeHttpClient)
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
    }
}
