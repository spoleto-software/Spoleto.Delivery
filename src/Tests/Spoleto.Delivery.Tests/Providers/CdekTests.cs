using Microsoft.Extensions.DependencyInjection;
using Spoleto.Common.Helpers;
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
                ProviderCityCode = "44"
                // Name = "Москва"
            };

            // Act
            var cities = await provider.GetCitiesAsync(cityRequest);

            // Assert
            Assert.That(cities, Is.Not.Null);
        }

        [Test]
        public async Task GetDeliveryPoints()
        {
            // Arrange
            var provider = ServiceProvider.GetRequiredService<ICdekProvider>();
            var deliveryPointRequest = new DeliveryPointRequest
            {
                Address = "г. Москва, площадь Киевского вокзала, д. 2, этаж третий помещение I комната 50",
                HaveCashless = true,
                AllowedCod = true,
                IsHandout = true
            };

            // Act
            var deliveryPoints = await provider.GetDeliveryPointsAsync(deliveryPointRequest);

            // Assert
            Assert.That(deliveryPoints, Is.Not.Null);
        }


        private static CreateDeliveryOrderRequest GetOrderRequest()
        {
            var deliveryOrderRequest = new CreateDeliveryOrderRequest
            {
                Type = OrderType.RegularDelivery,
                Comment = "Test order",
                FromLocation = new()
                {
                    Address = "Санкт-Петербург, пр. Ленинградский, д.4"
                },
                ToLocation = new()
                {
                    Address = "Москва, Кастанаевская улица, 65"
                },
                TariffCode = "480",
                Packages =
                [
                    new()
                    {
                        CisNumber = "1",
                        Comment = "Test",
                        Weight = 1000,
                        Width = 10,
                        Height = 10,
                        Length = 10
                    },
                ],
                Sender = new()
                {
                    Company = "Компания-Отправитель",
                    Name = "Петров И.",
                    //Email = "send@mail.com",
                    Phones =
                    [
                        new() { Number = "79234567890" },
                    ],
                },
                Recipient = new()
                {
                    Company = "Компания-Получатель",
                    Name = "Сидоров А.",
                    Email = "rec@mail.com",
                    Phones =
                    [
                        new() { Number = "79876543210" },
                    ],
                }
            };

            return deliveryOrderRequest;
        }

        private static CreateDeliveryOrderRequest GetOnlineOrderRequest()
        {
            var deliveryOrderRequest = new CreateDeliveryOrderRequest
            {
                CisNumber = "CIS-12345_" + new Random().Next(0, 10000),
                Type = OrderType.OnlineStore,
                Comment = "Test order",
                FromLocation = new()
                {
                    Address = "Санкт-Петербург, пр. Ленинградский, д.4"
                },
                ToLocation = new()
                {
                    Address = "Москва, Кастанаевская улица, 65"
                },
                TariffCode = "480",
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
                        Items =
                        [
                            new()
                            {
                                Name = "good 1",
                                Article = "article 1",
                                Amount = 1,
                                Weight = 1000,
                                Payment = new() { Value = 1000 }
                            }
                        ]
                    },
                ],
                Sender = new()
                {
                    Company = "Компания-Отправитель",
                    Name = "Петров И.",
                    Email = "send@mail.com",
                    Phones =
                    [
                        new() { Number = "79260001122" },
                    ],
                },
                Recipient = new()
                {
                    Company = "Компания-Получатель",
                    Name = "Сидоров А.",
                    Email = "rec@mail.com",
                    Phones =
                    [
                        new() { Number = "79230001122" },
                    ],
                }
            };

            return deliveryOrderRequest;
        }

        private static CreateCourierPickupRequest GetCourierPickupRequest()
        {
            var pickupRequest = new CreateCourierPickupRequest
            {
                Comment = "Комментарий для курьера",
                IntakeDate = DateTime.Now.AddDays(1),
                IntakeTimeFrom = TimeSpan.FromHours(12),
                IntakeTimeTo = TimeSpan.FromHours(15),
                FromLocation = new()
                {
                    Address = "Санкт-Петербург, пр. Ленинградский, д.4"
                },
                
                Sender = new()
                {
                    Company = "Компания-Отправитель",
                    Name = "Петров И.",
                    Phones =
                    [
                        new() { Number = "79234567890" },
                    ],
                },

                Name = "Заказ от компании"
            };

            return pickupRequest;
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
                Type = OrderType.RegularDelivery
            };

            tariffRequest.WithProviderData(nameof(Spoleto.Delivery.Providers.Cdek.TariffRequest.Lang), Spoleto.Delivery.Providers.Cdek.Language.Russian);
            tariffRequest.WithProviderData(nameof(Spoleto.Delivery.Providers.Cdek.TariffRequest.Currency), Spoleto.Delivery.Providers.Cdek.Currency.RussianRuble);

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

            deliveryOrderRequest.WithProviderData(nameof(Spoleto.Delivery.Providers.Cdek.CreateDeliveryOrderRequest.DeveloperKey), "XX-DEV-123-456");
            deliveryOrderRequest.WithProviderData(nameof(Spoleto.Delivery.Providers.Cdek.CreateDeliveryOrderRequest.Type), Spoleto.Delivery.Providers.Cdek.OrderType.RegularDelivery);

            // Act
            var deliveryOrder = await provider.CreateDeliveryOrderAsync(deliveryOrderRequest, true);
            var fullRawBody = deliveryOrder.GetFullRawBody();
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
        public async Task CreateOnlineOrder()
        {
            // Arrange
            var provider = ServiceProvider.GetRequiredService<ICdekProvider>();
            var deliveryOrderRequest = GetOnlineOrderRequest();

            deliveryOrderRequest.WithProviderData(nameof(Spoleto.Delivery.Providers.Cdek.CreateDeliveryOrderRequest.DeveloperKey), "XX-DEV-123-456");
            deliveryOrderRequest.WithProviderData(nameof(Spoleto.Delivery.Providers.Cdek.CreateDeliveryOrderRequest.Type), Spoleto.Delivery.Providers.Cdek.OrderType.OnlineStore);

            // Act
            var deliveryOrder = await provider.CreateDeliveryOrderAsync(deliveryOrderRequest, true);
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
            var updateRequest = new UpdateDeliveryOrderRequest { Recipient = new Contact() { Company = "My company", Name = "My name" } };

            updateRequest.WithProviderData(nameof(Spoleto.Delivery.Providers.Cdek.UpdateDeliveryOrderRequest.Comment), "New comment here");
            updateRequest.WithProviderData(nameof(Spoleto.Delivery.Providers.Cdek.UpdateDeliveryOrderRequest.Sender), new ContactBase { Company = "Sender company", Name = "Sender name here" });

            // Act
            var deliveryOrder = await provider.CreateDeliveryOrderAsync(deliveryOrderRequest, true);
            await Task.Delay(5000);

            var getOrder = await provider.GetDeliveryOrderAsync(new() { Uuid = deliveryOrder.Uuid });
            updateRequest.Uuid = deliveryOrder.Uuid;
            var updateOrder = await provider.UpdateDeliveryOrderAsync(updateRequest);
            await Task.Delay(5000);

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
            var deliveryOrder = await provider.CreateDeliveryOrderAsync(deliveryOrderRequest, true);

            var getOrder = await provider.GetDeliveryOrderAsync(new() { Uuid = deliveryOrder.Uuid });
            var deletedOrder = await provider.DeleteDeliveryOrderAsync(deliveryOrder.Uuid.ToString());

            // Assert
            Assert.That(deliveryOrder, Is.Not.Null);
            Assert.ThrowsAsync<Exception>(() => provider.GetDeliveryOrderAsync(new() { Uuid = deliveryOrder.Uuid }));
        }

        [Test]
        public async Task CreateOrderWithCourierPickup()
        {
            // Arrange
            var provider = ServiceProvider.GetRequiredService<ICdekProvider>();
            var deliveryOrderRequest = GetOnlineOrderRequest();
            var pickupRequest = GetCourierPickupRequest();

            deliveryOrderRequest.WithProviderData(nameof(Spoleto.Delivery.Providers.Cdek.CreateDeliveryOrderRequest.DeveloperKey), "XX-DEV-123-456");
            deliveryOrderRequest.WithProviderData(nameof(Spoleto.Delivery.Providers.Cdek.CreateDeliveryOrderRequest.Type), Spoleto.Delivery.Providers.Cdek.OrderType.OnlineStore);

            // Act
            var deliveryOrder = await provider.CreateDeliveryOrderAsync(deliveryOrderRequest, true);
            var getOrder = await provider.GetDeliveryOrderAsync(new() { Uuid = deliveryOrder.Uuid });
            
            pickupRequest.OrderUuid = deliveryOrder.Uuid;
            var pickup = await provider.CreateCourierPickupAsync(pickupRequest, true);
            var getPickup = await provider.GetCourierPickupAsync(new Delivery.GetCourierPickupRequest { Uuid = pickup.Uuid!.Value });

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(deliveryOrder, Is.Not.Null);

                Assert.That(getOrder, Is.Not.Null);
                Assert.That(getOrder.Errors, Is.Empty);

                Assert.That(pickup, Is.Not.Null);
                Assert.That(pickup.Errors, Is.Empty);

                Assert.That(getPickup, Is.Not.Null);
                Assert.That(getPickup.Errors, Is.Empty);
            });
        }

        [Test]
        public async Task DeleteCourierPickup()
        {
            // Arrange
            var provider = ServiceProvider.GetRequiredService<ICdekProvider>();
            var deliveryOrderRequest = GetOnlineOrderRequest();
            var pickupRequest = GetCourierPickupRequest();

            deliveryOrderRequest.WithProviderData(nameof(Spoleto.Delivery.Providers.Cdek.CreateDeliveryOrderRequest.DeveloperKey), "XX-DEV-123-456");
            deliveryOrderRequest.WithProviderData(nameof(Spoleto.Delivery.Providers.Cdek.CreateDeliveryOrderRequest.Type), Spoleto.Delivery.Providers.Cdek.OrderType.OnlineStore);

            // Act
            var deliveryOrder = await provider.CreateDeliveryOrderAsync(deliveryOrderRequest, true);
            //var getOrder = await provider.GetDeliveryOrderAsync(new() { Uuid = deliveryOrder.Uuid });

            pickupRequest.OrderUuid = deliveryOrder.Uuid;
            var pickup = await provider.CreateCourierPickupAsync(pickupRequest, true);
            //var getPickup = await provider.GetCourierPickupAsync(new Delivery.GetCourierPickupRequest { Uuid = pickup.Uuid });
            var deletedPickup = await provider.DeleteCourierPickupAsync(pickup.Uuid.ToString());

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(deliveryOrder, Is.Not.Null);

                //Assert.That(getOrder, Is.Not.Null);
                //Assert.That(getOrder.Errors, Is.Empty);

                Assert.That(pickup, Is.Not.Null);
                Assert.That(pickup.Errors, Is.Empty);

                //Assert.That(getPickup, Is.Not.Null);
                //Assert.That(getPickup.Errors, Is.Empty);

                Assert.That(deletedPickup, Is.Not.Null);
                Assert.That(deletedPickup.Errors, Is.Empty);
            });
        }

        [Test]
        public async Task CreateOrderWithCourierPickupAtTheSameTime()
        {
            // Arrange
            var provider = ServiceProvider.GetRequiredService<ICdekProvider>();
            var deliveryOrderRequest = GetOnlineOrderRequest();
            var pickupRequest = GetCourierPickupRequest();
            deliveryOrderRequest.CourierPickupRequest = new CourierPickupRequest
            {
                Comment = pickupRequest.Comment,
                IntakeDate = pickupRequest.IntakeDate,
                IntakeTimeFrom = pickupRequest.IntakeTimeFrom,
                IntakeTimeTo = pickupRequest.IntakeTimeTo
            };

            deliveryOrderRequest.WithProviderData(nameof(Spoleto.Delivery.Providers.Cdek.CreateDeliveryOrderRequest.DeveloperKey), "XX-DEV-123-456");
            deliveryOrderRequest.WithProviderData(nameof(Spoleto.Delivery.Providers.Cdek.CreateDeliveryOrderRequest.Type), Spoleto.Delivery.Providers.Cdek.OrderType.OnlineStore);

            // Act
            var deliveryOrder = await provider.CreateDeliveryOrderAsync(deliveryOrderRequest, true);
            var fullRawBody = deliveryOrder.GetFullRawBody();

            var after = JsonHelper.FromJson<DeliveryOrderFullRawBody>(fullRawBody);
            var orderAfterJson = JsonHelper.FromJson<Delivery.Providers.Cdek.DeliveryOrder>(after.DeliveryOrder);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(deliveryOrder, Is.Not.Null);

                Assert.That(deliveryOrder.CourierPickup, Is.Not.Null);

                Assert.That(deliveryOrder.Errors, Is.Empty);
                Assert.That(deliveryOrder.CourierPickup!.Errors, Is.Empty);
            });
        }

        [Test]
        public async Task CreateAndDeleteOrderWithCourierPickupAtTheSameTime()
        {
            // Arrange
            var provider = ServiceProvider.GetRequiredService<ICdekProvider>();
            var deliveryOrderRequest = GetOnlineOrderRequest();
            var pickupRequest = GetCourierPickupRequest();
            deliveryOrderRequest.CourierPickupRequest = new CourierPickupRequest
            {
                Comment = pickupRequest.Comment,
                IntakeDate = pickupRequest.IntakeDate,
                IntakeTimeFrom = pickupRequest.IntakeTimeFrom,
                IntakeTimeTo = pickupRequest.IntakeTimeTo
            };

            deliveryOrderRequest.WithProviderData(nameof(Spoleto.Delivery.Providers.Cdek.CreateDeliveryOrderRequest.DeveloperKey), "XX-DEV-123-456");
            deliveryOrderRequest.WithProviderData(nameof(Spoleto.Delivery.Providers.Cdek.CreateDeliveryOrderRequest.Type), Spoleto.Delivery.Providers.Cdek.OrderType.OnlineStore);

            // Act
            var deliveryOrder = await provider.CreateDeliveryOrderAsync(deliveryOrderRequest, true);
            var deletedOrder = await provider.DeleteDeliveryOrderAsync(deliveryOrder.Uuid.ToString()!);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(deliveryOrder, Is.Not.Null);

                Assert.That(deliveryOrder.CourierPickup, Is.Not.Null);

                Assert.That(deliveryOrder.Errors, Is.Empty);
                Assert.That(deliveryOrder.CourierPickup!.Errors, Is.Empty);

                Assert.That(deletedOrder, Is.Not.Null);
                Assert.That(deletedOrder.Errors, Is.Empty);
            });
        }
    }
}
