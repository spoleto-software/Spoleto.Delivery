﻿namespace Spoleto.Delivery.Providers.MasterPost
{
    public record MasterPostOptions : IOptions
    {
        /// <summary>
        /// Gets or sets the individual client number.
        /// </summary>
        public string IndividualClientNumber { get; set; }

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
        /// <exception cref="ArgumentNullException">Thrown when <see cref="ServiceUrl"/> or <see cref="IndividualClientNumber"/> or <see cref="AuthCredentials"/> are null.</exception>
        public void Validate()
        {
            if (String.IsNullOrEmpty(IndividualClientNumber))
                throw new ArgumentNullException(nameof(IndividualClientNumber));

            if (String.IsNullOrEmpty(ServiceUrl))
                throw new ArgumentNullException(nameof(ServiceUrl));

            if (AuthCredentials == null)
                throw new ArgumentNullException(nameof(AuthCredentials));

            AuthCredentials.Validate();
        }
    }
}
