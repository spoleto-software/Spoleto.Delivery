﻿using Spoleto.AddressResolver;
using Spoleto.RestClient;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// CDEK delivery provider for delivery of goods.
    /// </summary>
    /// <remarks>
    /// <see href="https://api-docs.cdek.ru/29923741.html"/>
    /// </remarks>
    public partial class CdekProvider : DeliveryProviderBase, IDisposable
    {
        /// <summary>
        /// The name of the delivery provider.
        /// </summary>
        public const string ProviderName = nameof(DeliveryProviderName.Cdek);

        private readonly CdekOptions _options;
        private readonly IAddressResolver? _addressResolver;
        private readonly CdekClient _cdekClient;

        public CdekProvider() : this(CdekOptions.Demo)
        {
        }

        public CdekProvider(CdekOptions options, IAddressResolver? addressResolver = null)
        {
            if (options is null)
                throw new ArgumentNullException(nameof(options));

            if (options.AuthCredentials is null)
                throw new ArgumentNullException(nameof(options.AuthCredentials));

            // Validates if the options are valid
            options.Validate();

            _options = options;
            _addressResolver = addressResolver;

            _cdekClient = new CdekClient(_options);
        }

        public CdekProvider(CdekClient cdekClient)
        {
            _cdekClient = cdekClient;
        }

        /// <inheritdoc/>
        public override string Name => ProviderName;

        /// <inheritdoc/>
        public override List<Delivery.OrderType> SupportedOrderTypes => new() { Delivery.OrderType.RegularDelivery, Delivery.OrderType.OnlineStore };

        #region IDisposable
        bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                _disposed = true;
                _cdekClient?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        /// <inheritdoc/>
        public override async Task<List<Delivery.City>> GetCitiesAsync(Delivery.CityRequest cityRequest)
        {
            var model = cityRequest.ToCityRequest();
            var restRequest = new RestRequestFactory(RestHttpMethod.Get, $"location/cities")
                .WithQueryString(model)
                .Build();

            var cityList = await _cdekClient.ExecuteAsync<List<City>>(restRequest).ConfigureAwait(false);

            return cityList.Select(x => x.ToDeliveryCity()).ToList();
        }

        public override List<Delivery.DeliveryPoint> GetDeliveryPoints(Delivery.DeliveryPointRequest deliveryPointRequest)
        {
            if (deliveryPointRequest.ProviderCityCode == null && deliveryPointRequest.FiasId == null && _addressResolver == null)
                throw new ArgumentNullException(nameof(deliveryPointRequest.FiasId), $"{nameof(deliveryPointRequest.FiasId)} or {nameof(deliveryPointRequest.ProviderCityCode)} must be specified or the address resolver must be initialized.");

            if (deliveryPointRequest.ProviderCityCode == null && deliveryPointRequest.FiasId == null && _addressResolver != null)
            {
                if (deliveryPointRequest.Address == null)
                    throw new ArgumentNullException(nameof(deliveryPointRequest.Address));

                var location = _addressResolver.ResolveLocation(deliveryPointRequest.Address);
                if (location == null)
                    throw new ArgumentException($"Could not find the full address for <{deliveryPointRequest.Address}>.");

                deliveryPointRequest.FiasId = location.CityFiasId;
            }

            return base.GetDeliveryPoints(deliveryPointRequest);
        }

        /// <inheritdoc/>
        public override async Task<List<Delivery.DeliveryPoint>> GetDeliveryPointsAsync(Delivery.DeliveryPointRequest deliveryPointRequest)
        {
            if (deliveryPointRequest.ProviderCityCode == null && deliveryPointRequest.FiasId == null && _addressResolver == null)
                throw new ArgumentNullException(nameof(deliveryPointRequest.FiasId), $"{nameof(deliveryPointRequest.FiasId)} or {nameof(deliveryPointRequest.ProviderCityCode)} must be specified or the address resolver must be initialized.");

            if (deliveryPointRequest.ProviderCityCode == null && deliveryPointRequest.FiasId == null && _addressResolver != null)
            {
                if (deliveryPointRequest.Address == null)
                    throw new ArgumentNullException(nameof(deliveryPointRequest.Address));

                var location = await _addressResolver.ResolveLocationAsync(deliveryPointRequest.Address).ConfigureAwait(false);
                if (location == null)
                    throw new ArgumentException($"Could not find the full address for <{deliveryPointRequest.Address}>.");

                deliveryPointRequest.FiasId = location.CityFiasId;
            }

            var model = deliveryPointRequest.ToDeliveryPointRequest();
            var restRequest = new RestRequestFactory(RestHttpMethod.Get, $"deliverypoints")
                .WithQueryString(model)
                .Build();

            var deliveryPointList = await _cdekClient.ExecuteAsync<List<DeliveryPoint>>(restRequest).ConfigureAwait(false);

            return deliveryPointList.Select(x => x.ToDeliveryPoint()).ToList();
        }

        /// <inheritdoc/>
        public override async Task<List<Delivery.Tariff>> GetTariffsAsync(Delivery.TariffRequest tariffRequest)
        {
            var model = tariffRequest.ToTariffRequest();
            var restRequest = new RestRequestFactory(RestHttpMethod.Post, "calculator/tarifflist")
                .WithJsonContent(model)
                .Build();

            var tariffList = await _cdekClient.ExecuteAsync<TariffList>(restRequest).ConfigureAwait(false);

            if (tariffList.Errors?.Count > 0)
            {
                throw new Exception(string.Join(Environment.NewLine, tariffList.Errors.Select(x => x.ToString())));
            }

            return tariffList.Tariffs.Select(x => x.ToDeliveryTariff()).ToList();
        }

        /// <inheritdoc/>
        public override Task<List<Delivery.AdditionalService>> GetAdditionalServicesAsync(Delivery.Tariff tariff)
        {
            var allAdditionalServices = GetAdditionalServices();
            var additionalServices = allAdditionalServices.Select(x => new Delivery.AdditionalService { Code = x.Code, Name = x.Name, Description = x.Description, ParameterType = x.ParameterType }).ToList();

            return Task.FromResult(additionalServices);
        }

        /// <inheritdoc/>
        public override async Task<Delivery.DeliveryOrderContainer> CreateDeliveryOrderAsync(Delivery.CreateDeliveryOrderRequest deliveryOrderRequest, bool ensureStatus)
        {
            var model = deliveryOrderRequest.ToCreateOrderRequest();
            var restRequest = new RestRequestFactory(RestHttpMethod.Post, "orders")
                .WithJsonContent(model)
                .Build();

            (var deliveryOrder, var rawBody) = await _cdekClient.ExecuteWithRawBodyAsync<CreatedDeliveryOrder>(restRequest).ConfigureAwait(false);

            var order = deliveryOrder!.ToDeliveryOrder();
            var orderContainer = new DeliveryOrderContainer(order, rawBody);

            if (deliveryOrderRequest.CourierPickupRequest != null)
                ensureStatus = true;

            if (ensureStatus)
            {
                if (orderContainer.DeliveryOrder!.Status == null)
                {
                    var dateTime = DateTime.Now.AddSeconds(_options.MaxWaitingTimeSecondsToEnsureStatus);
                    var firstStatus = OrderStatus.ACCEPTED.ToString();

                    while (true)
                    {
                        await Task.Delay(4000).ConfigureAwait(false);

                        orderContainer = await GetDeliveryOrderAsync(new() { Uuid = orderContainer.DeliveryOrder!.Uuid }).ConfigureAwait(false);

                        if (orderContainer.DeliveryOrder!.Status != null && orderContainer.DeliveryOrder!.Status != firstStatus)
                            break;

                        if (DateTime.Now > dateTime)
                            break;
                    }
                }

                if (orderContainer.DeliveryOrder!.Status == OrderStatus.INVALID.ToString())
                {
                    var message = "The created order is invalid.";
                    if (orderContainer.DeliveryOrder!.Errors?.Count > 0)
                    {
                        message += Environment.NewLine + String.Join(Environment.NewLine, orderContainer.DeliveryOrder!.Errors);
                    }

                    throw new InvalidOperationException(message);
                }
            }

            if (deliveryOrderRequest.CourierPickupRequest is CourierPickupRequest courierPickupRequest)
            {
                try
                {
                    var createCourierPickupRequest = courierPickupRequest.ToDeliveryCreatePickupRequest(orderContainer.DeliveryOrder!.Uuid!.Value);

                    var pickup = await CreateCourierPickupAsync(createCourierPickupRequest, true).ConfigureAwait(false);

                    orderContainer.DeliveryOrder!.CourierPickup = pickup.CourierPickup;
                    orderContainer.AddRelatedOrder(nameof(CourierPickup), pickup.RawBody);
                }
                catch // if the courier pickup is failed, then delete the delivery order (probably the problem is the delivery order).
                {
                    await DeleteDeliveryOrderAsync(orderContainer.DeliveryOrder!.Uuid!.Value.ToString()).ConfigureAwait(false);
                    
                    throw;
                }
            }

            return orderContainer;
        }

        /// <inheritdoc/>
        public override async Task<Delivery.DeliveryOrderContainer> GetDeliveryOrderAsync(GetDeliveryOrderRequest deliveryOrderRequest)
        {
            var uri = deliveryOrderRequest.Uuid != null ? $"orders/{deliveryOrderRequest.Uuid}"
                : !string.IsNullOrEmpty(deliveryOrderRequest.Number) ? $"orders?cdek_number={deliveryOrderRequest.Number}"
                : !string.IsNullOrEmpty(deliveryOrderRequest.CisNumber) ? $"orders?im_number={deliveryOrderRequest.CisNumber}"
                : throw new ArgumentNullException(nameof(deliveryOrderRequest.Uuid));

            var restRequest = new RestRequestFactory(RestHttpMethod.Get, uri)
                .Build();

            (var deliveryOrder, var rawBody) = await _cdekClient.ExecuteWithRawBodyAsync<DeliveryOrder>(restRequest).ConfigureAwait(false);

            var order = deliveryOrder?.ToDeliveryOrder();
            var orderContainer = new DeliveryOrderContainer(order, rawBody);

            return orderContainer;
        }

        /// <inheritdoc/>
        public override async Task<Delivery.DeliveryOrderContainer> UpdateDeliveryOrderAsync(Delivery.UpdateDeliveryOrderRequest deliveryOrderRequest)
        {
            var model = deliveryOrderRequest.ToUpdateOrderRequest();
            var restRequest = new RestRequestFactory(RestHttpMethod.Patch, "orders")
                .WithJsonContent(model)
                .Build();

            (var deliveryOrder, var rawBody) = await _cdekClient.ExecuteWithRawBodyAsync<UpdatedDeliveryOrder>(restRequest).ConfigureAwait(false);

            var order = deliveryOrder!.ToDeliveryOrder();
            var orderContainer = new DeliveryOrderContainer(order, rawBody);

            return orderContainer;
        }

        /// <inheritdoc/>
        public override async Task<Delivery.DeliveryOrderContainer> DeleteDeliveryOrderAsync(string orderId)
        {
            var restRequest = new RestRequestFactory(RestHttpMethod.Delete, $"orders/{orderId}")
                .Build();

            (var deliveryOrder, var rawBody) = await _cdekClient.ExecuteWithRawBodyAsync<CreatedDeliveryOrder>(restRequest).ConfigureAwait(false);

            var order = deliveryOrder!.ToDeliveryOrder();
            var orderContainer = new DeliveryOrderContainer(order, rawBody);

            return orderContainer;
        }

        /// <inheritdoc/>
        public override async Task<List<PrintingDocument>> PrintDeliveryOrderAsync(Delivery.PrintDeliveryOrderRequest printDeliveryOrderRequest)
        {
            if (printDeliveryOrderRequest.DeliveryOrders.Count > 100)
            {
                throw new InvalidOperationException("You cannot send more than 100 order numbers in one request.");
            }

            var cdekPrintDeliveryOrderRequest = printDeliveryOrderRequest.ToPrintOrderRequest();

            var createPrintingReceiptRequest = new CreatePrintingReceiptRequest
            {
                CopyCount = cdekPrintDeliveryOrderRequest.ReceiptCopyCount ?? _options.PrintingReceiptCopyCount,
                Type = cdekPrintDeliveryOrderRequest.ReceiptType ?? _options.PrintingReceiptType
            };

            var createPrintingBarcodeRequest = new CreatePrintingBarcodeRequest
            {
                CopyCount = cdekPrintDeliveryOrderRequest.BarcodeCopyCount ?? _options.PrintingBarcodeCopyCount,
                Format = cdekPrintDeliveryOrderRequest.BarcodeFormat ?? _options.PrintingBarcodeFormat,
                Lang = cdekPrintDeliveryOrderRequest.BarcodeLang ?? _options.PrintingBarcodeLang
            };

            foreach (var deliveryOrder in cdekPrintDeliveryOrderRequest.DeliveryOrders)
            {
                var uuid = deliveryOrder.Uuid;
                int? number = int.TryParse(deliveryOrder.Number, out var resultNumber) ? resultNumber : null;

                var printingOrder = new PrintingOrder
                {
                    OrderUuid = uuid?.ToString(),
                    CdekNumber = number
                };

                createPrintingReceiptRequest.Orders.Add(printingOrder);
                createPrintingBarcodeRequest.Orders.Add(printingOrder);
            }

            var createdPrintingReceipt = await CreatePrintingReceiptAsync(createPrintingReceiptRequest).ConfigureAwait(false);
            var createdPrintingBarcode = await CreatePrintingBarcodeAsync(createPrintingBarcodeRequest).ConfigureAwait(false);

            await Task.Delay(2000).ConfigureAwait(false);

            var getPrintingReceipt = await GetPrintingReceiptAsync(createdPrintingReceipt.Entity.Uuid);
            if (getPrintingReceipt.Entity.Url == null)
            {
                ValidatePrintingStatuses(getPrintingReceipt.Entity.Statuses);

                var dateTime = DateTime.Now.AddSeconds(_options.MaxWaitingTimeSecondsToEnsureStatus);

                while (true)
                {
                    await Task.Delay(4000).ConfigureAwait(false);

                    getPrintingReceipt = await GetPrintingReceiptAsync(createdPrintingReceipt.Entity.Uuid);

                    if (getPrintingReceipt.Entity.Url != null)
                        break;

                    ValidatePrintingStatuses(getPrintingReceipt.Entity.Statuses);

                    if (DateTime.Now > dateTime)
                        break;
                }

                ValidatePrintingStatuses(getPrintingReceipt.Entity.Statuses);

                if (getPrintingReceipt.Entity.Url == null)
                {
                    throw new InvalidOperationException("Printing receipt is not created. Try again later.");
                }
            }

            var getPrintingBarcode = await GetPrintingBarcodeAsync(createdPrintingBarcode.Entity.Uuid);
            if (getPrintingBarcode.Entity.Url == null)
            {
                ValidatePrintingStatuses(getPrintingBarcode.Entity.Statuses);

                var dateTime = DateTime.Now.AddSeconds(_options.MaxWaitingTimeSecondsToEnsureStatus);

                while (true)
                {
                    await Task.Delay(4000).ConfigureAwait(false);

                    getPrintingBarcode = await GetPrintingBarcodeAsync(createdPrintingBarcode.Entity.Uuid);

                    if (getPrintingBarcode.Entity.Url != null)
                        break;

                    ValidatePrintingStatuses(getPrintingBarcode.Entity.Statuses);

                    if (DateTime.Now > dateTime)
                        break;
                }

                ValidatePrintingStatuses(getPrintingBarcode.Entity.Statuses);

                if (getPrintingBarcode.Entity.Url == null)
                {
                    throw new InvalidOperationException("Printing barcode is not created. Try again later.");
                }
            }

            var receiptData = await DownloadPrintingReceiptAsync(getPrintingReceipt.Entity.Uuid);
            var barcodeData = await DownloadPrintingBarcodeAsync(getPrintingBarcode.Entity.Uuid);

            var orderText = createPrintingReceiptRequest.Orders.Count > 1 ? $"заказам ({createPrintingReceiptRequest.Orders.Count})" : "заказу";

            var result = new List<PrintingDocument>()
            {
                new(receiptData, DocumentFormat.Pdf, $"Квитанция к {orderText}"),
                new(barcodeData, DocumentFormat.Pdf, $"ШК места к {orderText}"),
            };

            return result;
        }

        private static void ValidatePrintingStatuses(List<PrintingOrderStatus> statuses)
        {
            var invalidStatus = statuses.FirstOrDefault(x => x.Code == PrintingOrderStatusCode.INVALID);
            if (invalidStatus != null)
            {
                throw new InvalidOperationException(invalidStatus.Name);
            }

            var removedStatus = statuses.FirstOrDefault(x => x.Code == PrintingOrderStatusCode.REMOVED);
            if (removedStatus != null)
            {
                throw new InvalidOperationException(removedStatus.Name);
            }
        }

        /// <inheritdoc/>
        public override async Task<Delivery.CourierPickupContainer> CreateCourierPickupAsync(Delivery.CreateCourierPickupRequest createCourierPickupRequest, bool ensureStatus)
        {
            var model = createCourierPickupRequest.ToCreatePickupRequest();
            var restRequest = new RestRequestFactory(RestHttpMethod.Post, "intakes")
                .WithJsonContent(model)
                .Build();

            (var deliveryCourierPickup, var rawBody) = await _cdekClient.ExecuteWithRawBodyAsync<CreatedCourierPickup>(restRequest).ConfigureAwait(false);

            var courierPickup = deliveryCourierPickup!.ToDeliveryCourierPickup();
            var courierPickupContainer = new CourierPickupContainer(courierPickup, rawBody);

            if (ensureStatus)
            {
                if (courierPickupContainer.CourierPickup!.Status == null)
                {
                    var dateTime = DateTime.Now.AddSeconds(_options.MaxWaitingTimeSecondsToEnsureStatus);
                    var firstStatus = PickupStatus.ACCEPTED.ToString();

                    while (true)
                    {
                        await Task.Delay(4000).ConfigureAwait(false);

                        courierPickupContainer = await GetCourierPickupAsync(new() { Uuid = courierPickupContainer.CourierPickup!.Uuid!.Value }).ConfigureAwait(false);

                        if (courierPickupContainer.CourierPickup!.Status != null && courierPickupContainer.CourierPickup!.Status != firstStatus)
                            break;

                        if (DateTime.Now > dateTime)
                            break;
                    }
                }

                if (courierPickupContainer.CourierPickup!.Status == PickupStatus.INVALID.ToString())
                {
                    var message = "The created courier pickup order is invalid.";
                    if (courierPickupContainer.CourierPickup!.Errors?.Count > 0)
                    {
                        message += Environment.NewLine + String.Join(Environment.NewLine, courierPickupContainer.CourierPickup!.Errors);
                    }

                    throw new InvalidOperationException(message);
                }
            }

            return courierPickupContainer;
        }

        /// <inheritdoc/>
        public override async Task<Delivery.CourierPickupContainer> GetCourierPickupAsync(GetCourierPickupRequest getCourierPickupRequest)
        {
            if (getCourierPickupRequest.Uuid == default)
                throw new ArgumentNullException(nameof(getCourierPickupRequest.Uuid));

            var uri = $"intakes/{getCourierPickupRequest.Uuid}";

            var restRequest = new RestRequestFactory(RestHttpMethod.Get, uri)
                .Build();

            (var deliveryCourierPickup, var rawBody) = await _cdekClient.ExecuteWithRawBodyAsync<CourierPickup>(restRequest).ConfigureAwait(false);

            var courierPickup = deliveryCourierPickup?.ToDeliveryCourierPickup();
            var courierPickupContainer = new CourierPickupContainer(courierPickup, rawBody);

            return courierPickupContainer;
        }

        /// <inheritdoc/>
        public override async Task<Delivery.CourierPickupContainer> DeleteCourierPickupAsync(string pickupOrderId)
        {
            var restRequest = new RestRequestFactory(RestHttpMethod.Delete, $"intakes/{pickupOrderId}")
                .Build();

            (var deliveryCourierPickup, var rawBody) = await _cdekClient.ExecuteWithRawBodyAsync<CreatedCourierPickup>(restRequest).ConfigureAwait(false);

            var courierPickup = deliveryCourierPickup!.ToDeliveryCourierPickup();
            var courierPickupContainer = new CourierPickupContainer(courierPickup, rawBody);

            return courierPickupContainer;
        }
    }
}
