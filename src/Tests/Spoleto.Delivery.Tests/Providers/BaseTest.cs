using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

            var cdekOptions = ConfigurationHelper.Configuration.GetSection(nameof(CdekOptions)).Get<CdekOptions>()!;
            services.AddSingleton(cdekOptions);
            services.AddSingleton<ICdekProvider, CdekProvider>();

            var masterPostOptions = ConfigurationHelper.Configuration.GetSection(nameof(MasterPostOptions)).Get<MasterPostOptions>()!;
            services.AddSingleton(masterPostOptions);
            services.AddHttpClient<IMasterPostProvider, MasterPostProvider>();

            _serviceProvider = services.BuildServiceProvider();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _serviceProvider.Dispose();

        }
    }
}
