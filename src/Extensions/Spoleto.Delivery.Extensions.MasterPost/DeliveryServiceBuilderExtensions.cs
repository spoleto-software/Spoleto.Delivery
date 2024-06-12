using Microsoft.Extensions.DependencyInjection;
using Spoleto.Delivery.Providers;
using Spoleto.Delivery.Providers.MasterPost;


namespace Spoleto.Delivery.Extensions.MasterPost
{
    /// <summary>
    /// Extension methods to configure an <see cref="DeliveryServiceBuilder"/> with <see cref="MasterPostProvider"/>.
    /// </summary>
    public static class DeliveryServiceBuilderExtensions
    {
        /// <summary>
        /// Adds the MasterPost provider to be used in the Delivery service.
        /// </summary>
        /// <remarks>
        /// <see href="https://mplogistics.ru"/>
        /// </remarks>
        /// <param name="builder">The <see cref="DeliveryServiceBuilder"/> instance.</param>
        /// <param name="individualClientNumber">The MasterPost Individual client number.</param>
        /// <param name="apiKey">The MasterPost Api key.</param>
        /// <param name="serviceUrl">The MasterPost service url.</param>
        /// <returns>The <see cref="DeliveryServiceBuilder"/> instance is provided to support method chaining capabilities.</returns>
        public static DeliveryServiceBuilder AddMasterPost(this DeliveryServiceBuilder builder, string individualClientNumber, string apiKey, string serviceUrl)
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
        /// <param name="builder">The <see cref="DeliveryServiceBuilder"/> instance.</param>
        /// <param name="config">The action to configure the <see cref="MasterPostOptions"/> for the MasterPost provider.</param>
        /// <returns>The <see cref="DeliveryServiceBuilder"/> instance is provided to support method chaining capabilities.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="config"/> is null.</exception>
        public static DeliveryServiceBuilder AddMasterPost(this DeliveryServiceBuilder builder, Action<MasterPostOptions> config)
        {
            if (config is null)
                throw new ArgumentNullException(nameof(config));

            // loads the options
            var options = new MasterPostOptions();
            config(options);

            // validates the options
            options.Validate();

            builder.ServiceCollection.AddSingleton(s => options);
            builder.ServiceCollection.AddScoped<IDeliveryProvider, MasterPostProvider>();
            builder.ServiceCollection.AddScoped<IMasterPostProvider, MasterPostProvider>();

            return builder;
        }

        /// <summary>
        /// Adds the MasterPost provider to be used in the Delivery service.
        /// </summary>
        /// <remarks>
        /// <see href="https://mplogistics.ru"/>
        /// </remarks>
        /// <param name="builder">The <see cref="DeliveryServiceBuilder"/> instance.</param>
        /// <param name="provider">The <see cref="MasterPostProvider"/> instance.</param>
        /// <returns>The <see cref="DeliveryServiceBuilder"/> instance is provided to support method chaining capabilities.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="provider"/> is null.</exception>
        public static DeliveryServiceBuilder AddMasterPost(this DeliveryServiceBuilder builder, MasterPostProvider provider)
        {
            if (provider is null)
                throw new ArgumentNullException(nameof(provider));

            builder.ServiceCollection.AddScoped<IDeliveryProvider>(x => provider);
            builder.ServiceCollection.AddScoped<IMasterPostProvider>(x => provider);

            return builder;
        }
    }
}