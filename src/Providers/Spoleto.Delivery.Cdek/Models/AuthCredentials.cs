using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    public record AuthCredentials : IOptions
    {
        public static readonly AuthCredentials Demo = new("EMscd6r9JnFiQ3bLoyjJY6eM78JrJceI", "PjLZkKBHEiLK3YsjtNrt3TGNG0ahs3kG");

        public AuthCredentials(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        [JsonPropertyName("grant_type")]
        public virtual string GrantType { get; } = "client_credentials";

        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        [JsonPropertyName("client_secret")]
        public string ClientSecret { get; set; }

        /// <summary>
        /// Checks that all the settings within the credentials are configured properly.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when <see cref="ClientId"/> or <see cref="ClientSecret"/> are null.</exception>
        public void Validate()
        {
            if (String.IsNullOrEmpty(ClientId))
                throw new ArgumentNullException(nameof(ClientId));

            if (String.IsNullOrEmpty(ClientSecret))
                throw new ArgumentNullException(nameof(ClientSecret));
        }
    }

}
