using Microsoft.Extensions.DependencyInjection;
using Spoleto.Delivery.Providers;
using Spoleto.Delivery.Providers.Cdek;

namespace Spoleto.Delivery.Extensions.Cdek
{
    /// <summary>
    /// Extension methods to configure an <see cref="DeliveryServiceBuilder"/> with <see cref="CdekProvider"/>.
    /// </summary>
    public static class DeliveryServiceBuilderExtensions
    {
        /// <summary>
        /// Adds the Cdek provider to be used in the Delivery service.
        /// </summary>
        /// <remarks>
        /// <see href="https://api-docs.cdek.ru/29923741.html"/>
        /// </remarks>
        /// <param name="builder">The <see cref="DeliveryServiceBuilder"/> instance.</param>
        /// <param name="cliendId">The cliend identifier.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <returns>The <see cref="DeliveryServiceBuilder"/> instance is provided to support method chaining capabilities.</returns>
        public static DeliveryServiceBuilder AddCdek(this DeliveryServiceBuilder builder, string cliendId, string clientSecret)
           => builder.AddCdek(x =>
           {
               x.ClientId = cliendId;
               x.ClientSecret = clientSecret;
           });


        /// <summary>
        /// Adds the Cdek provider to be used in the Delivery service.
        /// </summary>
        /// <remarks>
        /// <see href="https://api-docs.cdek.ru/29923741.html"/>
        /// </remarks>
        /// <param name="builder">The <see cref="DeliveryServiceBuilder"/> instance.</param>
        /// <param name="authConfig">The action to configure the <see cref="AuthCredentials"/> for the Cdek provider.</param>
        /// <returns>The <see cref="DeliveryServiceBuilder"/> instance is provided to support method chaining capabilities.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="authConfig"/> is null.</exception>
        public static DeliveryServiceBuilder AddCdek(this DeliveryServiceBuilder builder, Action<AuthCredentials> authConfig)
        {
            if (authConfig is null)
                throw new ArgumentNullException(nameof(authConfig));

            // loads the options
            var authCredentials = new AuthCredentials();
            authConfig(authCredentials);

            // validates the options
            authCredentials.Validate();

            builder.ServiceCollection.AddSingleton(s => CdekOptions.Production);
            builder.ServiceCollection.AddSingleton(s => authCredentials);
            builder.ServiceCollection.AddScoped<IDeliveryProvider, CdekProvider>();
            builder.ServiceCollection.AddScoped<ICdekProvider, CdekProvider>();

            return builder;
        }

        /// <summary>
        /// Adds the Cdek provider to be used in the Delivery service.
        /// </summary>
        /// <remarks>
        /// <see href="https://api-docs.cdek.ru/29923741.html"/>
        /// </remarks>
        /// <param name="builder">The <see cref="DeliveryServiceBuilder"/> instance.</param>
        /// <param name="provider">The <see cref="CdekProvider"/> instance.</param>
        /// <returns>The <see cref="DeliveryServiceBuilder"/> instance is provided to support method chaining capabilities.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="provider"/> is null.</exception>
        public static DeliveryServiceBuilder AddCdek(this DeliveryServiceBuilder builder, CdekProvider provider)
        {
            if (provider is null)
                throw new ArgumentNullException(nameof(provider));

            builder.ServiceCollection.AddScoped<IDeliveryProvider>(x => provider);
            builder.ServiceCollection.AddScoped<ICdekProvider>(x => provider);

            return builder;
        }
    }
}