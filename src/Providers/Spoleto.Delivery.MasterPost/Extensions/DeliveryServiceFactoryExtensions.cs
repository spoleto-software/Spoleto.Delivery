namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Extension methods to configure an <see cref="DeliveryServiceFactory"/> with <see cref="MasterPostProvider"/>.
    /// </summary>
    public static class DeliveryServiceFactoryExtensions
    {
        /// <summary>
        /// Adds the MasterPost provider to be used in the Delivery service.
        /// </summary>
        /// <remarks>
        /// <see href="https://mplogistics.ru"/>
        /// </remarks>
        /// <param name="builder">The <see cref="DeliveryServiceFactory"/> instance.</param>
        /// <param name="individualClientNumber">The MasterPost Individual client number.</param>
        /// <param name="apiKey">The MasterPost Api key.</param>
        /// <param name="serviceUrl">The MasterPost service url.</param>
        /// <returns>The <see cref="DeliveryServiceFactory"/> instance is provided to support method chaining capabilities.</returns>
        public static DeliveryServiceFactory AddMasterPost(this DeliveryServiceFactory builder, string individualClientNumber, string apiKey, string serviceUrl)
           => builder.AddMasterPost(x =>
           {
               x.IndividualClientNumber = individualClientNumber;
               x.ServiceUrl = serviceUrl;
               x.AuthCredentials = new AuthCredentials(apiKey);
           });

        /// <summary>
        /// Adds the MasterPost provider to be used in the Delivery service.
        /// </summary>
        /// <remarks>
        /// <see href="https://mplogistics.ru"/>
        /// </remarks>
        /// <param name="builder">The <see cref="DeliveryServiceFactory"/> instance.</param>
        /// <param name="config">The action to configure the <see cref="MasterPostOptions"/> for the MasterPost provider.</param>
        /// <returns>The <see cref="DeliveryServiceFactory"/> instance is provided to support method chaining capabilities.</returns>
        public static DeliveryServiceFactory AddMasterPost(this DeliveryServiceFactory builder, Action<MasterPostOptions> config)
        {
            // loads the options:
            var options = new MasterPostOptions();
            config(options);

            // validates the options:
            options.Validate();

            // add the provider to the Delivery service factory
            builder.AddProvider(new MasterPostProvider(options, builder.AddressResolver));

            return builder;
        }

        /// <summary>
        /// Adds the MasterPost provider to be used in the Delivery service.
        /// </summary>
        /// <remarks>
        /// <see href="https://mplogistics.ru"/>
        /// </remarks>
        /// <param name="builder">The <see cref="DeliveryServiceFactory"/> instance.</param>
        /// <param name="provider">The <see cref="MasterPostProvider"/> instance.</param>
        /// <returns>The <see cref="DeliveryServiceFactory"/> instance is provided to support method chaining capabilities.</returns>
        public static DeliveryServiceFactory AddMasterPost(this DeliveryServiceFactory builder, MasterPostProvider provider)
        {
            // add the provider to the Delivery service factory
            builder.AddProvider(provider);

            return builder;
        }
    }
}
