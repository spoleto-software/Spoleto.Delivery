﻿using Microsoft.Extensions.Configuration;
using Spoleto.Delivery.Providers.Cdek;
using Spoleto.Delivery.Providers.MasterPost;

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

        public static CdekOptions GetCdekOptions()
        {
            var options = _config.GetSection(nameof(CdekOptions)).Get<CdekOptions>()!;

            return options;
        }

        public static MasterPostOptions GetMasterPostOptions()
        {
            var options = _config.GetSection(nameof(MasterPostOptions)).Get<MasterPostOptions>()!;

            return options;
        }

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
