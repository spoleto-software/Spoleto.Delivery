using Microsoft.Extensions.DependencyInjection;
using Spoleto.Delivery.Providers.Cdek;

namespace Spoleto.Delivery.Tests.Providers
{
    public class CdekTests : BaseTest
    {
        [Test]
        public async Task GetCities()
        {
            // Arrange
            var provider = ServiceProvider.GetRequiredService<ICdekProvider>();
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
            var provider = ServiceProvider.GetRequiredService<ICdekProvider>();
            var tariffRequest = new TariffRequest
            {
                FromLocation = new() { Code = "270" },
                ToLocation = new() { Code = "44" },
                Packages =
                [
                    new()
                    {
                        Weight = 4000,
                        Height = 10,
                        Width = 10,
                        Length = 10
                    }
                ],
            };

            // Act
            var tariffs = await provider.GetTariffsAsync(tariffRequest);

            // Assert
            Assert.That(tariffs, Is.Not.Null);
        }

        [Test]
        public async Task GetAdditionalServices()
        {
            // Arrange
            var provider = ServiceProvider.GetRequiredService<ICdekProvider>();
            var tariff = new Tariff
            {
                Name = "11"
            };

            // Act
            var additionalServices = await provider.GetAdditionalServicesAsync(tariff);

            // Assert
            Assert.That(additionalServices, Is.Not.Null);
        }

        [Test]
        public async Task CreateOrder()
        {
            // Arrange
            var provider = ServiceProvider.GetRequiredService<ICdekProvider>();
            var deliveryOrderRequest = new CreateDeliveryOrderRequest
            {
                Type = OrderType.RegularDelivery,
                Comment = "Test order",
                FromLocation = new()
                {
                    Code = "44",
                    Address = "пр. Ленинградский, д.4"
                },
                ToLocation = new()
                {
                    Code = "44",
                    FiasGuid = Guid.Parse("0c5b2444-70a0-4932-980c-b4dc0d3f02b5"),
                    Address = "ул. Блюхера, 32"
                },
                NumTariffCode = 480,
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
            var getOrder = await provider.GetDeliveryOrderAsync(new() { Uuid = deliveryOrder.Uuid });
            var deleteOrder = await provider.DeleteDeliveryOrderAsync(deliveryOrder.Uuid.ToString());
            var getOrder2 = await provider.GetDeliveryOrderAsync(new() { Uuid = deliveryOrder.Uuid });

            // Assert
            Assert.That(deliveryOrder, Is.Not.Null);
        }
    }
}
