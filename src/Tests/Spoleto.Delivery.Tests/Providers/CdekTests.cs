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
                    Address = "125167, Санкт-Петербург, пр. Ленинградский, д.4"
                },
                ToLocation = new()
                {
                    Address = "119048, Москва, Кастанаевская улица, 65"
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
                                Cost = 1000,
                                Payment = new() { Value = 1000 }
                            }
                        ]
                    },
                ],
                Sender = new()
                {
                    Company = "Компания-Отправитель",
                    Name = "Петров И.В.",
                    Email = "send@mail.com",
                    Phones =
                    [
                        new() { Number = "79260001123" },
                    ],
                },
                Recipient = new()
                {
                    Company = "Компания-Получатель",
                    Name = "Сидоров А.Ф.",
                    Email = "rec@mail.com",
                    Phones =
                    [
                        new() { Number = "79230001121" },
                    ],
                },
                Services =
                [
                    new AdditionalServiceRequest{Code = nameof(Spoleto.Delivery.Providers.Cdek.AdditionalServiceType.CARTON_BOX_5KG), Parameter = "5" }
                ]
            };

            return deliveryOrderRequest;
        }

        private static CreateCourierPickupRequest GetCourierPickupRequest()
        {
            var pickupRequest = new CreateCourierPickupRequest
            {
                Comment = "Комментарий для курьера",
                IntakeDate = DateTime.Now.AddDays(3),
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
                        new() { Number = "79234567891" },
                    ],
                },

                Name = "Заказ от компании"
            };

            return pickupRequest;
        }

        private static CreateCourierPickupRequest GetCourierPickupRequestWithSizes()
        {
            var pickupRequest = new CreateCourierPickupRequest
            {
                Comment = "Комментарий для курьера",
                IntakeDate = DateTime.Now.AddDays(3),
                IntakeTimeFrom = TimeSpan.FromHours(12),
                IntakeTimeTo = TimeSpan.FromHours(15),
                FromLocation = new()
                {
                    Address = "Москва, Ленинский проспект, 40"
                },

                Sender = new()
                {
                    Company = "Компания-Отправителя",
                    Name = "Легин И.Ф.",
                    Phones =
                    [
                        new() { Number = "79134567898" },
                    ],
                },

                Name = "Заказ от компании 123",

                Height = 50,
                Length = 30,
                Width = 40,
                Weight = 5
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
            deliveryOrderRequest.Services = [];
            deliveryOrderRequest.Services.Add(new AdditionalServiceRequest { Code = nameof(Spoleto.Delivery.Providers.Cdek.AdditionalServiceType.CARTON_BOX_5KG), Parameter = "2" });
            deliveryOrderRequest.Services.Add(new AdditionalServiceRequest { Code = nameof(Spoleto.Delivery.Providers.Cdek.AdditionalServiceType.COURIER_PACKAGE_A2), Parameter = "2" });

            deliveryOrderRequest.WithProviderData(nameof(Spoleto.Delivery.Providers.Cdek.CreateDeliveryOrderRequest.DeveloperKey), "XX-DEV-123-456");
            deliveryOrderRequest.WithProviderData(nameof(Spoleto.Delivery.Providers.Cdek.CreateDeliveryOrderRequest.Type), Spoleto.Delivery.Providers.Cdek.OrderType.RegularDelivery);

            // Act
            var deliveryOrderContainer = await provider.CreateDeliveryOrderAsync(deliveryOrderRequest, true);
            var fullRawBody = deliveryOrderContainer.GetFullRawBody();
            var getOrder = await provider.GetDeliveryOrderAsync(new() { Uuid = deliveryOrderContainer.DeliveryOrder.Uuid });

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(deliveryOrderContainer, Is.Not.Null);

                Assert.That(getOrder, Is.Not.Null);
                Assert.That(getOrder.DeliveryOrder.Errors, Is.Empty);
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
            var getOrderContainer = await provider.GetDeliveryOrderAsync(new() { Uuid = deliveryOrder.DeliveryOrder.Uuid });
            var getOrder = getOrderContainer.DeliveryOrder;

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
            var deliveryOrderContainer = await provider.CreateDeliveryOrderAsync(deliveryOrderRequest, true);
            var deliveryOrder = deliveryOrderContainer.DeliveryOrder;
            await Task.Delay(5000);

            var getOrderContainer = await provider.GetDeliveryOrderAsync(new() { Uuid = deliveryOrder.Uuid });
            var getOrder = getOrderContainer.DeliveryOrder;
            updateRequest.Uuid = deliveryOrder.Uuid;

            var updateOrderContainer = await provider.UpdateDeliveryOrderAsync(updateRequest);
            var updateOrder = updateOrderContainer.DeliveryOrder;
            await Task.Delay(5000);

            var getOrder2Container = await provider.GetDeliveryOrderAsync(new() { Uuid = deliveryOrder.Uuid });
            var getOrder2 = getOrder2Container.DeliveryOrder;

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
            var deliveryOrderContainer = await provider.CreateDeliveryOrderAsync(deliveryOrderRequest, true);
            var deliveryOrder = deliveryOrderContainer.DeliveryOrder!;

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
            var deliveryOrderContainer = await provider.CreateDeliveryOrderAsync(deliveryOrderRequest, true);
            var deliveryOrder = deliveryOrderContainer.DeliveryOrder;
            var getOrderContainer = await provider.GetDeliveryOrderAsync(new() { Uuid = deliveryOrder.Uuid });
            var getOrder = getOrderContainer.DeliveryOrder;

            pickupRequest.OrderUuid = deliveryOrder.Uuid;
            var pickupContainer = await provider.CreateCourierPickupAsync(pickupRequest, true);
            var pickup = pickupContainer.CourierPickup;

            var getPickupContainer = await provider.GetCourierPickupAsync(new Delivery.GetCourierPickupRequest { Uuid = pickup.Uuid!.Value });
            var getPickup = getPickupContainer.CourierPickup;

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
            var deliveryOrdeContainer = await provider.CreateDeliveryOrderAsync(deliveryOrderRequest, true);
            var deliveryOrder = deliveryOrdeContainer.DeliveryOrder;
            var getOrder = await provider.GetDeliveryOrderAsync(new() { Uuid = deliveryOrder.Uuid });

            pickupRequest.OrderUuid = deliveryOrder.Uuid;
            var pickupContainer = await provider.CreateCourierPickupAsync(pickupRequest, true);
            var pickup = pickupContainer.CourierPickup;
            //var getPickup = await provider.GetCourierPickupAsync(new Delivery.GetCourierPickupRequest { Uuid = pickup.Uuid });
            var deletedPickupContainer = await provider.DeleteCourierPickupAsync(pickup.Uuid.ToString());
            var deletedPickup = deletedPickupContainer.CourierPickup;

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
            var deliveryOrderContainer = await provider.CreateDeliveryOrderAsync(deliveryOrderRequest, true);
            var deliveryOrder = deliveryOrderContainer.DeliveryOrder;
            var fullRawBody = deliveryOrderContainer.GetFullRawBody();

            var after = JsonHelper.FromJson<DeliveryOrderRawData>(fullRawBody);
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
            var deliveryOrderRequest = GetOrderRequest();
            var pickupRequest = GetCourierPickupRequest();
            deliveryOrderRequest.CourierPickupRequest = new CourierPickupRequest
            {
                Comment = pickupRequest.Comment,
                IntakeDate = pickupRequest.IntakeDate,
                IntakeTimeFrom = pickupRequest.IntakeTimeFrom,
                IntakeTimeTo = pickupRequest.IntakeTimeTo
            };

            deliveryOrderRequest.WithProviderData(nameof(Spoleto.Delivery.Providers.Cdek.CreateDeliveryOrderRequest.DeveloperKey), "XX-DEV-123-456");
            //deliveryOrderRequest.WithProviderData(nameof(Spoleto.Delivery.Providers.Cdek.CreateDeliveryOrderRequest.Type), Spoleto.Delivery.Providers.Cdek.OrderType.OnlineStore);

            // Act
            var deliveryOrderContainer = await provider.CreateDeliveryOrderAsync(deliveryOrderRequest, true);
            var rawBody = deliveryOrderContainer.GetFullRawBody();

            var deliveryOrder = deliveryOrderContainer.DeliveryOrder;
            var getOrder2 = await provider.GetDeliveryOrderAsync(new() { Uuid = deliveryOrder.Uuid });
            var deletedOrderContainer = await provider.DeleteDeliveryOrderAsync(deliveryOrder.Uuid.ToString()!);
            var deletedOrder = deletedOrderContainer.DeliveryOrder;

            await Task.Delay(3000);

            var getOrder = await provider.GetDeliveryOrderAsync(new() { Uuid = deliveryOrder.Uuid });
            var getPickup = await provider.GetCourierPickupAsync(new Delivery.GetCourierPickupRequest { Uuid = deliveryOrder.CourierPickup.Uuid.Value });

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

        [Test]
        public async Task CreateCourierPickup()
        {
            // Arrange
            var provider = ServiceProvider.GetRequiredService<ICdekProvider>();
            var pickupRequest = GetCourierPickupRequestWithSizes();

            // Act
            for (var i = 0; i < 100; i++)
            {
                var pickupContainer = await provider.CreateCourierPickupAsync(pickupRequest, true);
                var pickup = pickupContainer.CourierPickup;

                var getPickupContainer = await provider.GetCourierPickupAsync(new Delivery.GetCourierPickupRequest { Uuid = pickup.Uuid.Value });
                var getPickup = getPickupContainer.CourierPickup;

                var deletedPickupContainer = await provider.DeleteCourierPickupAsync(pickup.Uuid.ToString());
                var deletedPickup = deletedPickupContainer.CourierPickup;

                var getPickup2 = await provider.GetCourierPickupAsync(new Delivery.GetCourierPickupRequest { Uuid = pickup.Uuid.Value });

                // Assert
                Assert.Multiple(() =>
                {
                    Assert.That(pickup, Is.Not.Null);
                    Assert.That(pickup.Errors, Is.Empty);

                    Assert.That(getPickup, Is.Not.Null);
                    Assert.That(getPickup.Errors, Is.Empty);

                    Assert.That(deletedPickup, Is.Not.Null);
                    Assert.That(deletedPickup.Errors, Is.Empty);
                });
            }
        }

        [Test]
        public async Task GetWebhook()
        {
            // Arrange
            var provider = ServiceProvider.GetRequiredService<ICdekProvider>();
            var webhookUuid = Guid.Parse("5b3b6ab5-0861-447f-9518-2c62182f475a");

            // Act
            var webhook = await provider.GetWebhookAsync(webhookUuid);

            // Assert
            Assert.Pass();
        }

        [Test]
        public async Task CreateWebhook()
        {
            // Arrange
            var provider = ServiceProvider.GetRequiredService<ICdekProvider>();
            var webhookRequest = new WebhookRequest { Type = WebhookType.DOWNLOAD_PHOTO, Url = "http://mysite.com/api/cdek" };

            // Act
            var createdWebhook = await provider.CreateWebhookAsync(webhookRequest);
            var webhook = await provider.GetWebhookAsync(createdWebhook.Entity.Uuid);

            // Assert
            Assert.Pass();
        }

        [Test]
        public async Task DeleteWebhook()
        {
            // Arrange
            var provider = ServiceProvider.GetRequiredService<ICdekProvider>();
            var webhookRequest = new WebhookRequest { Type = WebhookType.DOWNLOAD_PHOTO, Url = "http://mysite.com/api/cdek" };

            // Act
            var createdWebhook = await provider.CreateWebhookAsync(webhookRequest);
            var webhook = await provider.GetWebhookAsync(createdWebhook.Entity.Uuid);
            var deletedWebhook = await provider.DeleteWebhookAsync(webhook.Entity.Uuid);

            // Assert
            Assert.Pass();
        }

        [Test]
        public async Task GetAllWebhooks()
        {
            // Arrange
            var provider = ServiceProvider.GetRequiredService<ICdekProvider>();

            // Act
            var webhooks = await provider.GetAllWebhooksAsync();

            // Assert
            Assert.That(webhooks, Is.Not.Null);
        }

        [Test]
        public async Task CreatePrintingReceipt()
        {
            // Arrange
            var provider = ServiceProvider.GetRequiredService<ICdekProvider>();
            var ordersToPrint = ConfigurationHelper.CdekDocumentsToPrint();
            var request = new CreatePrintingReceiptRequest() { Orders = ordersToPrint.Select(x => new PrintingOrder { CdekNumber = x }).ToList() };

            // Act
            var printingReceipt = await provider.CreatePrintingReceiptAsync(request);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(printingReceipt, Is.Not.Null);
                Assert.That(printingReceipt.Entity, Is.Not.Null);
                Assert.That(printingReceipt.Entity.Uuid, Is.Not.Empty);
            });
        }

        [Test]
        public async Task CreateAndGetPrintingReceipt()
        {
            // Arrange
            var provider = ServiceProvider.GetRequiredService<ICdekProvider>();
            var ordersToPrint = ConfigurationHelper.CdekDocumentsToPrint();
            var request = new CreatePrintingReceiptRequest() { Orders = ordersToPrint.Select(x => new PrintingOrder { CdekNumber = x }).ToList() };

            // Act
            var printingReceipt = await provider.CreatePrintingReceiptAsync(request);
            var getPrintingReceipt = await provider.GetPrintingReceiptAsync(printingReceipt.Entity.Uuid);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(getPrintingReceipt, Is.Not.Null);
                Assert.That(getPrintingReceipt.Entity, Is.Not.Null);
                Assert.That(getPrintingReceipt.Entity.Uuid, Is.Not.Empty);
            });
        }

        [Test]
        public async Task CreateAndGetAndDownloadPrintingReceipt()
        {
            // Arrange
            var provider = ServiceProvider.GetRequiredService<ICdekProvider>();
            var ordersToPrint = ConfigurationHelper.CdekDocumentsToPrint();
            var request = new CreatePrintingReceiptRequest() { Type = PrintingReceiptType.TplRussia, Orders = ordersToPrint.Select(x => new PrintingOrder { CdekNumber = x }).ToList() };

            // Act
            var printingReceipt = await provider.CreatePrintingReceiptAsync(request);
            var getPrintingReceipt = await provider.GetPrintingReceiptAsync(printingReceipt.Entity.Uuid);

            if (getPrintingReceipt.Entity.Url == null)
            {
                var dateTime = DateTime.Now.AddSeconds(10);

                while (true)
                {
                    await Task.Delay(1000).ConfigureAwait(false);

                    getPrintingReceipt = await provider.GetPrintingReceiptAsync(printingReceipt.Entity.Uuid);

                    if (getPrintingReceipt.Entity.Url != null)
                        break;

                    if (DateTime.Now > dateTime)
                        break;
                }
            }

            var data = await provider.DownloadPrintingReceiptAsync(printingReceipt.Entity.Uuid);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(getPrintingReceipt, Is.Not.Null);
                Assert.That(getPrintingReceipt.Entity, Is.Not.Null);
                Assert.That(getPrintingReceipt.Entity.Uuid, Is.Not.Empty);
            });
        }


        [Test]
        public async Task CreatePrintingBarcode()
        {
            // Arrange
            var provider = ServiceProvider.GetRequiredService<ICdekProvider>();
            var ordersToPrint = ConfigurationHelper.CdekDocumentsToPrint();
            var request = new CreatePrintingBarcodeRequest() { Orders = ordersToPrint.Select(x => new PrintingOrder { CdekNumber = x }).ToList() };

            // Act
            var printingBarcode = await provider.CreatePrintingBarcodeAsync(request);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(printingBarcode, Is.Not.Null);
                Assert.That(printingBarcode.Entity, Is.Not.Null);
                Assert.That(printingBarcode.Entity.Uuid, Is.Not.Empty);
            });
        }

        [Test]
        public async Task CreateAndGetPrintingBarcode()
        {
            // Arrange
            var provider = ServiceProvider.GetRequiredService<ICdekProvider>();
            var ordersToPrint = ConfigurationHelper.CdekDocumentsToPrint();
            var request = new CreatePrintingBarcodeRequest() { Orders = ordersToPrint.Select(x => new PrintingOrder { CdekNumber = x }).ToList() };

            // Act
            var printingBarcode = await provider.CreatePrintingBarcodeAsync(request);
            var getPrintingBarcode = await provider.GetPrintingBarcodeAsync(printingBarcode.Entity.Uuid);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(getPrintingBarcode, Is.Not.Null);
                Assert.That(getPrintingBarcode.Entity, Is.Not.Null);
                Assert.That(getPrintingBarcode.Entity.Uuid, Is.Not.Empty);
            });
        }

        [Test]
        public async Task CreateAndGetAndDownloadPrintingBarcode()
        {
            // Arrange
            var provider = ServiceProvider.GetRequiredService<ICdekProvider>();
            var ordersToPrint = ConfigurationHelper.CdekDocumentsToPrint();
            var request = new CreatePrintingBarcodeRequest() { Orders = ordersToPrint.Select(x => new PrintingOrder { CdekNumber = x }).ToList() };

            // Act
            var printingBarcode = await provider.CreatePrintingBarcodeAsync(request);
            var getPrintingBarcode = await provider.GetPrintingBarcodeAsync(printingBarcode.Entity.Uuid);

            if (getPrintingBarcode.Entity.Url == null)
            {
                var dateTime = DateTime.Now.AddSeconds(10);

                while (true)
                {
                    await Task.Delay(1000).ConfigureAwait(false);

                    getPrintingBarcode = await provider.GetPrintingBarcodeAsync(printingBarcode.Entity.Uuid);

                    if (getPrintingBarcode.Entity.Url != null)
                        break;

                    if (DateTime.Now > dateTime)
                        break;
                }
            }

            var data = await provider.DownloadPrintingBarcodeAsync(printingBarcode.Entity.Uuid);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(getPrintingBarcode, Is.Not.Null);
                Assert.That(getPrintingBarcode.Entity, Is.Not.Null);
                Assert.That(getPrintingBarcode.Entity.Uuid, Is.Not.Empty);
            });
        }

        [Test]
        public async Task PrintOrders()
        {
            // Arrange
            var provider = ServiceProvider.GetRequiredService<ICdekProvider>();
            var ordersToPrint = ConfigurationHelper.CdekDocumentsToPrint();
            var request = new PrintDeliveryOrderRequest
            {
                DeliveryOrders = ordersToPrint.Select(x => new PrintDeliveryOrder { Number = x.ToString() }).ToList()
            };
            request.WithProviderData(nameof(Spoleto.Delivery.Providers.Cdek.PrintDeliveryOrderRequest.ReceiptType), Spoleto.Delivery.Providers.Cdek.PrintingReceiptType.TplItalian);
            request.WithProviderData(nameof(Spoleto.Delivery.Providers.Cdek.PrintDeliveryOrderRequest.BarcodeFormat), Spoleto.Delivery.Providers.Cdek.PrintingBarcodeFormat.A5);
            request.WithProviderData(nameof(Spoleto.Delivery.Providers.Cdek.PrintDeliveryOrderRequest.BarcodeCopyCount), 3);

            // Act
            var printingDocuments = await provider.PrintDeliveryOrderAsync(request);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(printingDocuments, Is.Not.Null);
                Assert.That(printingDocuments, Has.Count.EqualTo(2));
            });
        }
    }
}
