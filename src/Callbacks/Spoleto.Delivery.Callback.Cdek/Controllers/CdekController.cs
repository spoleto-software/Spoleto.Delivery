using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Spoleto.Common.Helpers;
using Spoleto.Delivery.Callback.Cdek.Models;
using Spoleto.Delivery.Callback.Common.Services;

namespace Spoleto.Delivery.Callback.Cdek.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("api/webhooks/incoming/[controller]")]
    public class CdekController : ControllerBase
    {
        private readonly ILogger<CdekController> _logger;
        private readonly IRepository _cisRepository;

        public CdekController(ILogger<CdekController> logger, IRepository cisRepository)
        {
            _logger = logger;
            _cisRepository = cisRepository;
        }

        [AllowAnonymous]
        [HttpPost("status")]
        public async Task<IActionResult> CdekOrderStatusWebhookHandler(CdekWebhookMessage<OrderStatus> data)
        {
            if (data?.Type == CdekWebhookMessageType.ORDER_STATUS)
            {
                var success = await _cisRepository.UpdateDeliveryOrderStatusAsync(data.Uuid.ToString(), data.Attributes.Code);

                var result = success ? "successfully" : "not";

                _logger.Log(success ? LogLevel.Information : LogLevel.Error,
                    "The delivery order with the external id = {id} was {result} updated.{newline}The incoming webhook: {json}",
                    data.Uuid, result, Environment.NewLine, JsonHelper.ToJson(data));
            }

            return Ok();
        }
    }
}
