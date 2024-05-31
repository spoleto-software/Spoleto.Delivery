using Microsoft.Extensions.Configuration;

namespace Spoleto.Delivery.Tests
{
    internal class ConfigurationHelper
    {
        private static readonly IConfigurationRoot _config;

        static ConfigurationHelper()
        {
            _config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: true)
               .AddUserSecrets("9650e9a7-e8fe-4aa7-bc2a-7008c079bb0d")
               .Build();
        }

        public static IConfigurationRoot Configuration => _config;

        public static Delivery.DeliveryOrderRequest GetGoodsDeliveryCdek()
        {
   
            return null;
        }

        public static Delivery.DeliveryOrderRequest GetSmsMessageMasterPost()
        {
 
            return null;
        }
    }
}
