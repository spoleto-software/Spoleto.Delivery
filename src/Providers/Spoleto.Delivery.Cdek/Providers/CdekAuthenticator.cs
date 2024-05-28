using Spoleto.RestClient;
using Spoleto.RestClient.Authentication;

namespace Spoleto.Delivery.Providers.Cdek
{
    public class CdekAuthenticator : DynamicAuthenticator
    {
        public const string TokenTypeName = "Bearer";

        private readonly AuthCredentials _authCredentials;

        public CdekAuthenticator() : this(AuthCredentials.Demo, TokenTypeName)
        {
        }

        public CdekAuthenticator(AuthCredentials authCredentials) : this(authCredentials, TokenTypeName)
        {
        }

        public CdekAuthenticator(AuthCredentials authCredentials, string tokenType) : base(tokenType)
        {
            _authCredentials = authCredentials;
        }

        protected override async Task<string> GetAuthenticationToken(IRestClient client)
        {
            var restRequest = client.CreateJsonRestRequest("oauth/token", RestClient.HttpMethod.Post, false, _authCredentials);

            var authResponseModel = await client.ExecuteAsync<AuthToken>(restRequest).ConfigureAwait(false);

            return authResponseModel.AccessToken;
        }
    }
}
