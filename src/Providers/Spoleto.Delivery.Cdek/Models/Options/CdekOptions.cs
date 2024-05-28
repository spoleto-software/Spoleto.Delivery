
namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// The options for the <see cref="CdekProvider"/>.
    /// </summary>
    public record CdekOptions : IOptions
    {
        public static readonly CdekOptions Demo = new() { ServiceUrl = "https://api.edu.cdek.ru/v2/" };

        public static readonly CdekOptions Production = new() { ServiceUrl = "https://api.cdek.ru/v2/" };

        /// <summary>
        /// Gets or sets the service url.
        /// </summary>
        public string ServiceUrl { get; set; }

        /// <summary>
        /// Checks that all the settings within the options are configured properly.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when <see cref="ServiceUrl"/> is null.</exception>
        public void Validate()
        {
            if (String.IsNullOrEmpty(ServiceUrl))
                throw new ArgumentNullException(nameof(ServiceUrl));
        }
    }
}
