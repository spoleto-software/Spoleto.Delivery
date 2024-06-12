using Microsoft.Extensions.DependencyInjection;

namespace Spoleto.Delivery.Extensions
{
    /// <summary>
    /// Extension methods to configure an <see cref="IServiceCollection"/> for <see cref="IDeliveryService"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the Spoleto.Delivery service.
        /// </summary>
        /// <param name="serviceCollection">The service collection instance.</param>
        /// <param name="defaultProviderName">The name of the default delivery provider to be used.</param>
        /// <returns>The <see cref="DeliveryServiceBuilder"/> instance is provided to support method chaining capabilities.</returns>
        public static DeliveryServiceBuilder AddDelivery(this IServiceCollection serviceCollection, string defaultProviderName)
            => AddDelivery(serviceCollection, options => options.DefaultProvider = defaultProviderName);

        /// <summary>
        /// Adds the Spoleto.Delivery service.
        /// </summary>
        /// <param name="serviceCollection">The service collection instance.</param>
        /// <param name="config">The action to configure the <see cref="DeliveryServiceOptions"/> for the DeliveryService.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="config"/> is null.</exception>
        /// <returns>The <see cref="DeliveryServiceBuilder"/> instance is provided to support method chaining capabilities.</returns>
        public static DeliveryServiceBuilder AddDelivery(this IServiceCollection serviceCollection, Action<DeliveryServiceOptions> config)
        {
            if (config is null)
                throw new ArgumentNullException(nameof(config));

            // loads the options
            var options = new DeliveryServiceOptions();
            config(options);

            serviceCollection.AddSingleton(s => options);
            serviceCollection.AddScoped<IDeliveryService, DeliveryService>();

            // registers the providers on this instance:
            return new DeliveryServiceBuilder(serviceCollection);
        }
    }
}