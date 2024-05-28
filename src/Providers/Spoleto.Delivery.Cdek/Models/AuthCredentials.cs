using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    public record AuthCredentials
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
        public string ClientId { get; }


        [JsonPropertyName("client_secret")]
        public string ClientSecret { get; }
    }

}
