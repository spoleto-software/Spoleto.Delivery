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
    }
}
