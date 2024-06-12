using Spoleto.RestClient;
using Spoleto.RestClient.Authentication;

namespace Spoleto.Delivery.Providers.Cdek
{
    public class CdekAuthenticator : DynamicAuthenticator
    {
        public const string TokenTypeName = "Bearer";

        private readonly AuthCredentials _authCredentials;

        public CdekAuthenticator() : this(AuthCredentials.Demo)
        {
        }

        public CdekAuthenticator(AuthCredentials authCredentials) : base(TokenTypeName)
        {
            _authCredentials = authCredentials;
        }

        protected override async Task<string> GetAuthenticationToken(IRestClient client)
        {
            var restRequest = new RestRequestFactory(RestHttpMethod.Post, "oauth/token")
                .WithFormUrlEncodedContent(_authCredentials)
                .Build();

            var authResponseModel = await client.ExecuteAsync<AuthToken>(restRequest).ConfigureAwait(false);

            return authResponseModel.AccessToken;
        }
    }
}
