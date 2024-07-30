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
                Code = "44"
                // Name = "Москва"
            };

            // Act
            var cities = await provider.GetCitiesAsync(cityRequest);

            // Assert
            Assert.That(cities, Is.Not.Null);
        }


        private static CreateDeliveryOrderRequest GetOrderRequest()
        {
            var deliveryOrderRequest = new CreateDeliveryOrderRequest
            {
                Type = OrderType.RegularDelivery,
                Comment = "Test order",
                FromLocation = new()
                {
                    // Code = "44",
                    Address = "Санкт-Петербург, пр. Ленинградский, д.4"
                },
                ToLocation = new()
                {
                    // Code = "44",
                    //FiasGuid = Guid.Parse("0c5b2444-70a0-4932-980c-b4dc0d3f02b5"),
                    Address = "Москва, Кастанаевская улица, 65"
                },
                TariffCode = "480",
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

            return deliveryOrderRequest;
        }

        [Test]
        public async Task GetTariffs()
        {
            // Arrange
            var provider = ServiceProvider.GetRequiredService<ICdekProvider>();
            var tariffRequest = new TariffRequest
            {
                FromLocation = new()
                {
                    // Code = "44",
                    // City = "Новосибирск",
                    Address = "Санкт-Петербург, пр. Ленинградский, д.4"
                },
                ToLocation = new()
                {
                    // Code = "44",
                    Address = "Москва, Кастанаевская улица, 65"
                },

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
            var deliveryOrderRequest = GetOrderRequest();

            // Act
            var deliveryOrder = await provider.CreateDeliveryOrderAsync(deliveryOrderRequest);
            var getOrder = await provider.GetDeliveryOrderAsync(new() { Uuid = deliveryOrder.Uuid });

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(deliveryOrder, Is.Not.Null);

                Assert.That(getOrder, Is.Not.Null);
                Assert.That(getOrder.Errors, Is.Empty);
            });
        }

        [Test]
        public async Task UpdateOrder()
        {
            // Arrange
            var provider = ServiceProvider.GetRequiredService<ICdekProvider>();
            var deliveryOrderRequest = GetOrderRequest();

            // Act
            var deliveryOrder = await provider.CreateDeliveryOrderAsync(deliveryOrderRequest);
            await Task.Delay(5000);

            var getOrder = await provider.GetDeliveryOrderAsync(new() { Uuid = deliveryOrder.Uuid });
            var updateOrder = await provider.UpdateDeliveryOrderAsync(new() { Uuid = deliveryOrder.Uuid, Recipient = new Contact() { Company = "My company", Name = "My name" } });
            var getOrder2 = await provider.GetDeliveryOrderAsync(new() { Uuid = deliveryOrder.Uuid });

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(deliveryOrder, Is.Not.Null);

                Assert.That(getOrder, Is.Not.Null);
                Assert.That(getOrder.Errors, Is.Empty);

                Assert.That(updateOrder, Is.Not.Null);
                Assert.That(updateOrder.Errors, Is.Empty);

                Assert.That(getOrder2, Is.Not.Null);
                Assert.That(getOrder2.Errors, Is.Empty);
            });
        }

        [Test]
        public async Task DeleteOrder()
        {
            // Arrange
            var provider = ServiceProvider.GetRequiredService<ICdekProvider>();
            var deliveryOrderRequest = GetOrderRequest();

            // Act
            var deliveryOrder = await provider.CreateDeliveryOrderAsync(deliveryOrderRequest);
            await Task.Delay(5000);

            var getOrder = await provider.GetDeliveryOrderAsync(new() { Uuid = deliveryOrder.Uuid });
            var deleteOrder = await provider.DeleteDeliveryOrderAsync(deliveryOrder.Uuid.ToString());

            // Assert
            Assert.That(deliveryOrder, Is.Not.Null);
            Assert.ThrowsAsync<Exception>(() => provider.GetDeliveryOrderAsync(new() { Uuid = deliveryOrder.Uuid }));
        }
    }
}
