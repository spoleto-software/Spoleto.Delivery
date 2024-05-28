namespace Spoleto.Delivery.Providers.MasterPost
{
    public record AuthCredentials
    {

        public AuthCredentials(string apiKey)
        {
            ApiKey = apiKey;
        }

        public string ApiKey { get; }
    }
}
