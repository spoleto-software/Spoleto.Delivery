namespace Spoleto.Delivery.Providers.MasterPost
{
    public record AuthCredentials : IOptions
    {
        public AuthCredentials(string apiKey)
        {
            ApiKey = apiKey;
        }

        public string ApiKey { get; }

        /// <summary>
        /// Checks that all the settings within the credentials are configured properly.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when <see cref="ApiKey"/> is null.</exception>
        public void Validate()
        {
            if (String.IsNullOrEmpty(ApiKey))
                throw new ArgumentNullException(nameof(ApiKey));
        }
    }
}
