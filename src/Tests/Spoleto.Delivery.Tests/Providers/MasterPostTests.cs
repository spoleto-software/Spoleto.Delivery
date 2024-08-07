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
                FromLocation = new()
                {
                    CityFiasId = Guid.Parse("0c5b2444-70a0-4932-980c-b4dc0d3f02b5"),
                    Address = "г Москва, Бережковская наб, д 20 стр 64"
                },
                ToLocation = new()
                {
                    CityFiasId = Guid.Parse("c2deb16a-0330-4f05-821f-1d09c93331e6"),
                    Address = "г Новосибирск, ул Кривощековская, зд 15 к 1"
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
                ]
            };

            tariffRequest.WithProviderData(nameof(Spoleto.Delivery.Providers.MasterPost.TariffRequest.EstimatedCost), 2000M);
            tariffRequest.WithProviderData(nameof(Spoleto.Delivery.Providers.MasterPost.TariffRequest.SenderSms), "79001234567");
            //tariffRequest.WithProviderData(nameof(Spoleto.Delivery.Providers.MasterPost.TariffRequest.IsStraightDelivery), true);
            //tariffRequest.WithProviderData(nameof(Spoleto.Delivery.Providers.MasterPost.TariffRequest.SenderAddressCodes), new List<string> { "code1", "code2", "code3" });

            // Act
            var tariffs = await provider.GetTariffsAsync(tariffRequest);

            // Assert
            Assert.That(tariffs, Is.Not.Null);
        }

        private static CreateDeliveryOrderRequest GetOrderRequest()
        {
            return new CreateDeliveryOrderRequest
            {
                CisNumber = "CIS-12345_" + new Random().Next(0, 10000),
                Type = OrderType.RegularDelivery,
                Comment = "Test order",
                FromLocation = new()
                {
                    CityFiasId = Guid.Parse("c2deb16a-0330-4f05-821f-1d09c93331e6"),
                    Address = "Санкт-Петербург, пр. Ленинградский, д.4"
                },
                ToLocation = new()
                {
                    CityFiasId = Guid.Parse("0c5b2444-70a0-4932-980c-b4dc0d3f02b5"),
                    Address = "Москва, ул. Блюхера, 32"
                },
                TariffCode = "Экспресс",
                Packages =
                [
                    new()
                    {
                        CisNumber = "1",
                        Comment = "Test",
                        Weight = 1000,
                        Width = 10,
                        Height = 10,
                        Length = 10,
                    },
                ],
                Sender = new()
                {
                    Company = "Sender company",
                    Name = "Sender name",
                    Email = "sender@example.com",
                    Phones =
                    [
                        new() { Number = "+71234567890" },
                    ],
                },
                Recipient = new()
                {
                    Company = "Rec company",
                    Name = "Rec name",
                    Email = "company@example.com",
                    Phones =
                    [
                        new() { Number = "+79876543210" },
                    ],
                },
            };
        }

        [Test]
        public async Task CreateOrder()
        {
            // Arrange
            var provider = ServiceProvider.GetRequiredService<IMasterPostProvider>();
            var deliveryOrderRequest = GetOrderRequest();

            deliveryOrderRequest.WithProviderData(nameof(Spoleto.Delivery.Providers.MasterPost.CreateDeliveryOrderRequest.Comment), "test");
            deliveryOrderRequest.WithProviderData(nameof(Spoleto.Delivery.Providers.MasterPost.CreateDeliveryOrderRequest.CollectionAtDelivery), "123-456-789");
            //deliveryOrderRequest.WithProviderData(nameof(Spoleto.Delivery.Providers.MasterPost.CreateDeliveryOrderRequest.IsStraightDelivery), true);
            //deliveryOrderRequest.WithProviderData(nameof(Spoleto.Delivery.Providers.MasterPost.CreateDeliveryOrderRequest.SenderAddressCodes), new List<string> { "code1", "code2", "code3" });

            // Act
            var deliveryOrder = await provider.CreateDeliveryOrderAsync(deliveryOrderRequest);
            var getOrder = await provider.GetDeliveryOrderAsync(new GetDeliveryOrderRequest() { Number = deliveryOrder.Number });

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(deliveryOrder, Is.Not.Null);

                Assert.That(getOrder, Is.Not.Null);
                Assert.That(getOrder.Errors, Is.Null);
            });
        }

        [Test]
        public async Task DeleteOrder()
        {
            // Arrange
            var provider = ServiceProvider.GetRequiredService<IMasterPostProvider>();
            var deliveryOrderRequest = GetOrderRequest();

            // Act
            var deliveryOrder = await provider.CreateDeliveryOrderAsync(deliveryOrderRequest);
            var getOrder = await provider.GetDeliveryOrderAsync(new GetDeliveryOrderRequest() { Number = deliveryOrder.Number });
            var deleteOrder = await provider.DeleteDeliveryOrderAsync(deliveryOrder.Number);
            var getOrder2 = await provider.GetDeliveryOrderAsync(new GetDeliveryOrderRequest() { Number = deliveryOrder.Number });

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(deliveryOrder, Is.Not.Null);

                Assert.That(getOrder, Is.Not.Null);
                Assert.That(getOrder.Errors, Is.Null);

                Assert.That(deleteOrder, Is.Not.Null);
                Assert.That(deleteOrder.Errors, Is.Null);

                Assert.That(getOrder2, Is.Not.Null);
                Assert.That(getOrder2.Errors, Is.Null);
            });
        }
    }
}
