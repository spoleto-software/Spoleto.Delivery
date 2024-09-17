using Microsoft.Extensions.DependencyInjection;
using Spoleto.AddressResolver;
using Spoleto.AddressResolver.Dadata;
using Spoleto.Delivery.Providers.Cdek;
using Spoleto.Delivery.Providers.MasterPost;

namespace Spoleto.Delivery.Tests.Providers
{
    public class BaseTest
    {
        private ServiceProvider _serviceProvider;

        protected ServiceProvider ServiceProvider => _serviceProvider;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var services = new ServiceCollection();

            var dadataOptions = ConfigurationHelper.GetDadataptions();
            services.AddSingleton(dadataOptions);
            services.AddSingleton<IAddressResolver, DadataAddressResolver>();

            var cdekOptions = ConfigurationHelper.GetCdekOptions();
            services.AddSingleton(cdekOptions);
            services.AddSingleton<ICdekProvider, CdekProvider>();

            var masterPostOptions = ConfigurationHelper.GetMasterPostOptions();
            services.AddSingleton(masterPostOptions);
            services.AddSingleton<IMasterPostProvider, MasterPostProvider>();

            _serviceProvider = services.BuildServiceProvider();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _serviceProvider?.Dispose();
        }
    }
}
