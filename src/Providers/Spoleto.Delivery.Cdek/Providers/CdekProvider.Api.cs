using Spoleto.RestClient;

namespace Spoleto.Delivery.Providers.Cdek
{
    public partial class CdekProvider : ICdekProvider
    {
        private List<Delivery.AdditionalService> GetAdditionalServices()
        {
            var list = new List<Delivery.AdditionalService>();

            foreach (AdditionalServiceType enumValue in Enum.GetValues(typeof(AdditionalServiceType)))
            {
                var code = enumValue.ToString();
                var name = enumValue.GetDescription()!;
                var additionalService = new Delivery.AdditionalService { Code = code, Name = name };

                var parameterInfo = enumValue.ToAdditionalServiceParameterInfo();
                if (parameterInfo.ParameterType != null)
                {
                    additionalService.ParameterType = parameterInfo.ParameterType;
                    additionalService.Description = parameterInfo.ParameterDescription;
                }

                list.Add(additionalService);
            }

            return list;
        }

        /// <inheritdoc/>
        public WebhookBase CreateWebhook(WebhookRequest webhookRequest)
            => CreateWebhookAsync(webhookRequest).GetAwaiter().GetResult();

        /// <inheritdoc/>
        public async Task<WebhookBase> CreateWebhookAsync(WebhookRequest webhookRequest)
        {
            var restRequest = new RestRequestFactory(RestHttpMethod.Post, $"webhooks")
                .WithJsonContent(webhookRequest)
                .Build();

            var webhook = await _cdekClient.ExecuteAsync<WebhookBase>(restRequest).ConfigureAwait(false);

            return webhook;
        }

        /// <inheritdoc/>
        public Webhook GetWebhook(Guid webhookUuid)
            => GetWebhookAsync(webhookUuid).GetAwaiter().GetResult();

        /// <inheritdoc/>
        public async Task<Webhook> GetWebhookAsync(Guid webhookUuid)
        {
            var restRequest = new RestRequestFactory(RestHttpMethod.Get, $"webhooks/{webhookUuid}")
                .Build();

            var webhook = await _cdekClient.ExecuteAsync<Webhook>(restRequest).ConfigureAwait(false);

            return webhook;
        }

        /// <inheritdoc/>
        public WebhookBase DeleteWebhook(Guid webhookUuid)
            => DeleteWebhookAsync(webhookUuid).GetAwaiter().GetResult();

        /// <inheritdoc/>
        public async Task<WebhookBase> DeleteWebhookAsync(Guid webhookUuid)
        {
            var restRequest = new RestRequestFactory(RestHttpMethod.Delete, $"webhooks/{webhookUuid}")
                .Build();

            var webhook = await _cdekClient.ExecuteAsync<WebhookBase>(restRequest).ConfigureAwait(false);

            return webhook;
        }

        /// <inheritdoc/>
        public List<WebhookEntity> GetAllWebhooks()
            => GetAllWebhooksAsync().GetAwaiter().GetResult();

        /// <inheritdoc/>
        public async Task<List<WebhookEntity>> GetAllWebhooksAsync()
        {
            var restRequest = new RestRequestFactory(RestHttpMethod.Get, $"webhooks")
                .Build();

            var webhooks = await _cdekClient.ExecuteAsync<List<WebhookEntity>>(restRequest).ConfigureAwait(false);

            return webhooks;
        }

        public CreatedPrintingReceipt CreatePrintingReceipt(CreatePrintingReceiptRequest printingReceiptRequest)
            => CreatePrintingReceiptAsync(printingReceiptRequest).GetAwaiter().GetResult();

        public async Task<CreatedPrintingReceipt> CreatePrintingReceiptAsync(CreatePrintingReceiptRequest printingReceiptRequest)
        {
            var restRequest = new RestRequestFactory(RestHttpMethod.Post, $"print/orders")
                .WithJsonContent(printingReceiptRequest)
                .Build();

            var printingReceipt = await _cdekClient.ExecuteAsync<CreatedPrintingReceipt>(restRequest).ConfigureAwait(false);

            return printingReceipt;
        }

        public PrintingReceipt GetPrintingReceipt(Guid printingReceiptUuid)
            => GetPrintingReceiptAsync(printingReceiptUuid).GetAwaiter().GetResult();

        public async Task<PrintingReceipt> GetPrintingReceiptAsync(Guid printingReceiptUuid)
        {
            var restRequest = new RestRequestFactory(RestHttpMethod.Get, $"print/orders/{printingReceiptUuid}")
                .Build();

            var printingReceipt = await _cdekClient.ExecuteAsync<PrintingReceipt>(restRequest).ConfigureAwait(false);

            return printingReceipt;
        }
        public byte[] DownloadPrintingReceipt(Guid printingReceiptUuid)
            => DownloadPrintingReceiptAsync(printingReceiptUuid).GetAwaiter().GetResult();

        public async Task<byte[]> DownloadPrintingReceiptAsync(Guid printingReceiptUuid)
        {
            var restRequest = new RestRequestFactory(RestHttpMethod.Get, $"print/orders/{printingReceiptUuid}.pdf")
                .Build();

            var binaryResponse = await _cdekClient.ExecuteAsBytesAsync(restRequest).ConfigureAwait(false);
            if (binaryResponse == null)
            {
                throw new InvalidOperationException("Orders are not found for printing.");
            }

            return binaryResponse.Content;
        }

        public CreatedPrintingBarcode CreatePrintingBarcode(CreatePrintingBarcodeRequest printingBarcodeRequest)
            => CreatePrintingBarcodeAsync(printingBarcodeRequest).GetAwaiter().GetResult();

        public async Task<CreatedPrintingBarcode> CreatePrintingBarcodeAsync(CreatePrintingBarcodeRequest printingBarcodeRequest)
        {
            var restRequest = new RestRequestFactory(RestHttpMethod.Post, $"print/barcodes")
                .WithJsonContent(printingBarcodeRequest)
                .Build();

            var printingBarcode = await _cdekClient.ExecuteAsync<CreatedPrintingBarcode>(restRequest).ConfigureAwait(false);

            return printingBarcode;
        }

        public PrintingBarcode GetPrintingBarcode(Guid printingBarcodeUuid)
            => GetPrintingBarcodeAsync(printingBarcodeUuid).GetAwaiter().GetResult();

        public async Task<PrintingBarcode> GetPrintingBarcodeAsync(Guid printingBarcodeUuid)
        {
            var restRequest = new RestRequestFactory(RestHttpMethod.Get, $"print/barcodes/{printingBarcodeUuid}")
                .Build();

            var printingBarcode = await _cdekClient.ExecuteAsync<PrintingBarcode>(restRequest).ConfigureAwait(false);

            return printingBarcode;
        }

        public byte[] DownloadPrintingBarcode(Guid printingBarcodeUuid)
            => DownloadPrintingBarcodeAsync(printingBarcodeUuid).GetAwaiter().GetResult();

        public async Task<byte[]> DownloadPrintingBarcodeAsync(Guid printingBarcodeUuid)
        {
            var restRequest = new RestRequestFactory(RestHttpMethod.Get, $"print/barcodes/{printingBarcodeUuid}.pdf")
                .Build();

            var binaryResponse = await _cdekClient.ExecuteAsBytesAsync(restRequest).ConfigureAwait(false);
            if (binaryResponse == null)
            {
                throw new InvalidOperationException("Orders are not found for printing.");
            }

            return binaryResponse.Content;
        }
    }
}
