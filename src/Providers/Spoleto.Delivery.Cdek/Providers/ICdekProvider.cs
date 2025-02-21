namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// CDEK delivery provider for delivery of goods.
    /// </summary>
    /// <remarks>
    /// <see href="https://api-docs.cdek.ru/29923741.html"/>
    /// </remarks>
    public interface ICdekProvider : IDeliveryProvider
    {
        /// <summary>
        /// Creates a webhook.
        /// </summary>
        /// <param name="webhookRequest">The creating webhook request.</param>
        /// <returns>The created webhook.</returns>
        WebhookBase CreateWebhook(WebhookRequest webhookRequest);

        /// <summary>
        /// Async creates a webhook.
        /// </summary>
        /// <param name="webhookRequest">The creating webhook request.</param>
        /// <returns>The created webhook.</returns>
        Task<WebhookBase> CreateWebhookAsync(WebhookRequest webhookRequest);

        /// <summary>
        /// Gets the webhook.
        /// </summary>
        /// <param name="webhookUuid">The webhook identifier.</param>
        /// <returns>The webhook.</returns>
        Webhook GetWebhook(Guid webhookUuid);

        /// <summary>
        /// Async gets the webhook.
        /// </summary>
        /// <param name="webhookUuid">The webhook identifier.</param>
        /// <returns>The webhook.</returns>
        Task<Webhook> GetWebhookAsync(Guid webhookUuid);

        /// <summary>
        /// Deletes the webhook.
        /// </summary>
        /// <param name="webhookUuid">The webhook identifier.</param>
        /// <returns>The deleted webhook.</returns>
        WebhookBase DeleteWebhook(Guid webhookUuid);

        /// <summary>
        /// Async deletes the webhook.
        /// </summary>
        /// <param name="webhookUuid">The webhook identifier.</param>
        /// <returns>The deleted webhook.</returns>
        Task<WebhookBase> DeleteWebhookAsync(Guid webhookUuid);

        /// <summary>
        /// Gets all webhooks.
        /// </summary>
        /// <returns>The list of webhooks.</returns>
        List<WebhookEntity> GetAllWebhooks();

        /// <summary>
        /// Async gets all webhooks.
        /// </summary>
        /// <returns>The list of webhooks.</returns>
        Task<List<WebhookEntity>> GetAllWebhooksAsync();

        /// <summary>
        /// Creates printing receipt for delivery order/orders.
        /// </summary>
        /// <param name="printingReceiptRequest">The request to search delivery orders.</param>
        /// <returns>The printing receipt information.</returns>
        CreatedPrintingReceipt CreatePrintingReceipt(CreatePrintingReceiptRequest printingBarcodeRequest);

        /// <summary>
        /// Async creates printing receipt for delivery order/orders.
        /// </summary>
        /// <param name="printingReceiptRequest">The request to search delivery orders.</param>
        /// <returns>The printing receipt information.</returns>
        Task<CreatedPrintingReceipt> CreatePrintingReceiptAsync(CreatePrintingReceiptRequest printingBarcodeRequest);

        /// <summary>
        /// Gets printing receipt for delivery order/orders.
        /// </summary>
        /// <param name="printingReceiptUuid">The printing receipt identifier.</param>
        /// <returns>The printing receipt information.</returns>
        PrintingReceipt GetPrintingReceipt(Guid printingReceiptUuid);

        /// <summary>
        /// Async gets printing receipt for delivery order/orders.
        /// </summary>
        /// <param name="printingReceiptUuid">The printing receipt identifier.</param>
        /// <returns>The printing receipt information.</returns>
        Task<PrintingReceipt> GetPrintingReceiptAsync(Guid printingReceiptUuid);

        /// <summary>
        /// Downloads printing receipt for delivery order/orders.
        /// </summary>
        /// <param name="printingReceiptUuid">The printing receipt identifier.</param>
        /// <returns>The printing receipt in byte array (Pdf format).</returns>
        byte[] DownloadPrintingReceipt(Guid printingReceiptUuid);

        /// <summary>
        /// Async downloads printing receipt for delivery order/orders.
        /// </summary>
        /// <param name="printingReceiptUuid">The printing receipt identifier.</param>
        /// <returns>The printing receipt in byte array (Pdf format).</returns>
        Task<byte[]> DownloadPrintingReceiptAsync(Guid printingReceiptUuid);

        /// <summary>
        /// Creates printing barcode for delivery order/orders.
        /// </summary>
        /// <param name="printingBarcodeRequest">The request to search delivery orders.</param>
        /// <returns>The printing barcode information.</returns>
        CreatedPrintingBarcode CreatePrintingBarcode(CreatePrintingBarcodeRequest printingBarcodeRequest);

        /// <summary>
        /// Async creates printing barcode for delivery order/orders.
        /// </summary>
        /// <param name="printingBarcodeRequest">The request to search delivery orders.</param>
        /// <returns>The printing barcode information.</returns>
        Task<CreatedPrintingBarcode> CreatePrintingBarcodeAsync(CreatePrintingBarcodeRequest printingBarcodeRequest);

        /// <summary>
        /// Gets printing barcode for delivery order/orders.
        /// </summary>
        /// <param name="printingBarcodeUuid">The printing barcode identifier.</param>
        /// <returns>The printing barcode information.</returns>
        PrintingBarcode GetPrintingBarcode(Guid printingBarcodeUuid);

        /// <summary>
        /// Async gets printing barcode for delivery order/orders.
        /// </summary>
        /// <param name="printingBarcodeUuid">The printing barcode identifier.</param>
        /// <returns>The printing barcode information.</returns>
        Task<PrintingBarcode> GetPrintingBarcodeAsync(Guid printingBarcodeUuid);

        /// <summary>
        /// Downloads printing barcode for delivery order/orders.
        /// </summary>
        /// <param name="printingBarcodeUuid">The printing barcode identifier.</param>
        /// <returns>The printing barcode in byte array (Pdf format).</returns>
        byte[] DownloadPrintingBarcode(Guid printingBarcodeUuid);

        /// <summary>
        /// Async downloads printing barcode for delivery order/orders.
        /// </summary>
        /// <param name="printingBarcodeUuid">The printing barcode identifier.</param>
        /// <returns>The printing barcode in byte array (Pdf format).</returns>
        Task<byte[]> DownloadPrintingBarcodeAsync(Guid printingBarcodeUuid);
    }
}
