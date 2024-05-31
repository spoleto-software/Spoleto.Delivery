using Microsoft.Extensions.DependencyInjection;

namespace Spoleto.Delivery.Extensions
{
    /// <summary>
    /// Spoleto.Delivery dependency injection builder.
    /// </summary>
    public class DeliveryServiceBuilder
    {
        /// <summary>
        /// Creates an instance of <see cref="DeliveryServiceBuilder"/>.
        /// </summary>
        /// <param name="serviceCollection">The services collection instance.</param>
        internal DeliveryServiceBuilder(IServiceCollection serviceCollection)
        {
            ServiceCollection = serviceCollection;
        }

        /// <summary>
        /// Gets the service collection.
        /// </summary>
        public IServiceCollection ServiceCollection { get; }
    }
}
