using Microsoft.Extensions.DependencyInjection;
using Spoleto.Delivery.Providers.MasterPost;

namespace Spoleto.Delivery.Tests.Providers
{
    public class MasterPostTests : BaseTest
    {
        [Test]
        public async Task GetCities()
        {
            // Arrange
            var provider = ServiceProvider.GetRequiredService<IMasterPostProvider>();
            var cityRequest = new CityRequest
            {
                Name = "Москва"
            };

            // Act
            var cities = await provider.GetCitiesAsync(cityRequest);

            // Assert
            Assert.That(cities, Is.Not.Null);
        }

        [Test]
        public async Task GetTariffs()
        {
            // Arrange
            var provider = ServiceProvider.GetRequiredService<IMasterPostProvider>();
            var tariffRequest = new TariffRequest
            {
                FromLocation = new() { Code = "0c5b2444-70a0-4932-980c-b4dc0d3f02b5" },
                ToLocation = new() { Code = "c2deb16a-0330-4f05-821f-1d09c93331e6" },
                Packages =
                [
                    new()
                    {
                        Weight = 4000,
                        Height = 10,
                        Width = 10,
                        Length = 10
                    }
                ]
            };

            // Act
            var tariffs = await provider.GetTariffsAsync(tariffRequest);

            // Assert
            Assert.That(tariffs, Is.Not.Null);
        }

        [Test]
        public async Task CreateOrder()
        {
            // Arrange
            var provider = ServiceProvider.GetRequiredService<IMasterPostProvider>();
            var deliveryOrderRequest = new CreateDeliveryOrderRequest
            {
                Type = OrderType.RegularDelivery,
                Comment = "Test order",
                FromLocation = new()
                {
                    FiasGuid = Guid.Parse("c2deb16a-0330-4f05-821f-1d09c93331e6"),
                    Address = "Санкт-Петербург, пр. Ленинградский, д.4"
                },
                ToLocation = new()
                {
                    FiasGuid = Guid.Parse("0c5b2444-70a0-4932-980c-b4dc0d3f02b5"),
                    Address = "Москва, ул. Блюхера, 32"
                },
                TariffCode = "Экспресс",
                Packages =
                [
                    new()
                    {
                        Number = "1",
                        Comment = "Test",
                        Weight = 1000,
                        Width = 10,
                        Height = 10,
                        Length = 10,
                    },
                ],
                Sender = new()
                {
                    Company = "Burattino",
                    Name = "Basilio",
                    Email = "basilio@example.com",
                    Phones =
                    [
                        new() { Number = "+71234567890" },
                    ],
                },
                Recipient = new()
                {
                    Company = "Burattino",
                    Name = "Alice",
                    Email = "alice@example.com",
                    Phones =
                    [
                        new() { Number = "+79876543210" },
                    ],
                },
            };

            // Act
            var deliveryOrder = await provider.CreateDeliveryOrderAsync(deliveryOrderRequest);

            // Assert
            Assert.That(deliveryOrder, Is.Not.Null);
        }
    }
}
