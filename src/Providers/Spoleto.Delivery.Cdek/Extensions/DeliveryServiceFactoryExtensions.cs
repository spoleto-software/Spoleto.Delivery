namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Extension methods to configure an <see cref="DeliveryServiceFactory"/> with <see cref="CdekProvider"/>.
    /// </summary>
    public static class DeliveryServiceFactoryExtensions
    {
        /// <summary>
        /// Adds the Cdek provider to be used in the Delivery service.
        /// </summary>
        /// <remarks>
        /// <see href="https://api-docs.cdek.ru/29923741.html"/>
        /// </remarks>
        /// <param name="builder">The <see cref="DeliveryServiceFactory"/> instance.</param>
        /// <param name="cliendId">The cliend identifier.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <param name="serviceUrl">The Cdek service url.</param>
        /// <param name="maxWaitingTimeSecondsToEnsureStatus">The max time in seconds to ensure status.</param>
        /// <returns>The <see cref="DeliveryServiceFactory"/> instance is provided to support method chaining capabilities.</returns>
        public static DeliveryServiceFactory AddCdek(this DeliveryServiceFactory builder, string cliendId, string clientSecret, string serviceUrl, int maxWaitingTimeSecondsToEnsureStatus = CdekOptions.DefaultMaxWaitingTimeSecondsToEnsureStatus)
           => builder.AddCdek(x =>
           {
               x.ServiceUrl = serviceUrl;
               x.MaxWaitingTimeSecondsToEnsureStatus = maxWaitingTimeSecondsToEnsureStatus;
               x.AuthCredentials = new AuthCredentials(cliendId, clientSecret);
           });


        /// <summary>
        /// Adds the Cdek provider to be used in the Delivery service.
        /// </summary>
        /// <remarks>
        /// <see href="https://api-docs.cdek.ru/29923741.html"/>
        /// </remarks>
        /// <param name="builder">The <see cref="DeliveryServiceFactory"/> instance.</param>
        /// <param name="config">The action to configure the <see cref="CdekOptions"/> for the Cdek provider.</param>
        /// <returns>The <see cref="DeliveryServiceFactory"/> instance is provided to support method chaining capabilities.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="config"/> is null.</exception>
        public static DeliveryServiceFactory AddCdek(this DeliveryServiceFactory builder, Action<CdekOptions> config)
        {
            if (config is null)
                throw new ArgumentNullException(nameof(config));

            // loads the options
            var options = new CdekOptions();
            config(options);

            // validates the options
            options.Validate();


            // add the provider to the Delivery service factory
            builder.AddProvider(new CdekProvider(options, builder.AddressResolver));

            return builder;
        }

        /// <summary>
        /// Adds the Cdek provider to be used in the Delivery service.
        /// </summary>
        /// <remarks>
        /// <see href="https://api-docs.cdek.ru/29923741.html"/>
        /// </remarks>
        /// <param name="builder">The <see cref="DeliveryServiceFactory"/> instance.</param>
        /// <param name="provider">The <see cref="CdekProvider"/> instance.</param>
        /// <returns>The <see cref="DeliveryServiceFactory"/> instance is provided to support method chaining capabilities.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="provider"/> is null.</exception>
        public static DeliveryServiceFactory AddCdek(this DeliveryServiceFactory builder, CdekProvider provider)
        {
            if (provider is null)
                throw new ArgumentNullException(nameof(provider));

            // add the provider to the Delivery service factory
            builder.AddProvider(provider);

            return builder;
        }
    }
}
