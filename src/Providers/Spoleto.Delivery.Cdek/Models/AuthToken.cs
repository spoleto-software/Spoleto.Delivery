using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    public record AuthToken
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        [JsonPropertyName("jti")]
        public string Jti { get; set; }
    }

}
