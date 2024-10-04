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
    }
}
