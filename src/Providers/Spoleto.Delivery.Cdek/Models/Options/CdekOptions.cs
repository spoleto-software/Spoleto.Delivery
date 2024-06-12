
namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// The options for the <see cref="CdekProvider"/>.
    /// </summary>
    public record CdekOptions : IOptions
    {
        public static readonly CdekOptions Demo = new() { ServiceUrl = "https://api.edu.cdek.ru/v2/", AuthCredentials = AuthCredentials.Demo };

        public static readonly CdekOptions Production = new() { ServiceUrl = "https://api.cdek.ru/v2/" };

        /// <summary>
        /// Gets or sets the service url.
        /// </summary>
        public string ServiceUrl { get; set; }

        /// <summary>
        /// Gets or sets the authentication credentials.
        /// </summary>
        public AuthCredentials AuthCredentials { get; set; }

        /// <summary>
        /// Checks that all the settings within the options are configured properly.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when <see cref="ServiceUrl"/> or <see cref="AuthCredentials"/> are null.</exception>
        public void Validate()
        {
            if (String.IsNullOrEmpty(ServiceUrl))
                throw new ArgumentNullException(nameof(ServiceUrl));

            if (AuthCredentials == null)
                throw new ArgumentNullException(nameof(AuthCredentials));

            AuthCredentials.Validate();
        }
    }
}
