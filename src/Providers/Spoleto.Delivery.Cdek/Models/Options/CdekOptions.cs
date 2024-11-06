
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
        /// The default value for <see cref="MaxWaitingTimeSecondsToEnsureStatus"/>.
        /// </summary>
        public const int DefaultMaxWaitingTimeSecondsToEnsureStatus = 10;

        /// <summary>
        /// Gets or sets the service url.
        /// </summary>
        public string ServiceUrl { get; set; }

        /// <summary>
        /// Gets or sets the authentication credentials.
        /// </summary>
        public AuthCredentials AuthCredentials { get; set; }

        /// <summary>
        /// Gets or sets the max time in seconds to ensure status in the methods <see cref="IDeliveryProvider.CreateDeliveryOrder(Delivery.CreateDeliveryOrderRequest, bool)"/>, <see cref="IDeliveryProvider.CreateCourierPickup(Delivery.CreateCourierPickupRequest, bool)"/>.
        /// </summary>
        /// <remarks>
        /// Default: <see cref="DefaultMaxWaitingTimeSecondsToEnsureStatus"/>.
        /// </remarks>
        public int MaxWaitingTimeSecondsToEnsureStatus { get; set; } = DefaultMaxWaitingTimeSecondsToEnsureStatus;

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

            if (MaxWaitingTimeSecondsToEnsureStatus <= 0)
                throw new ArgumentException("Has to be greater than zero.", nameof(MaxWaitingTimeSecondsToEnsureStatus));

            AuthCredentials.Validate();
        }
    }
}
