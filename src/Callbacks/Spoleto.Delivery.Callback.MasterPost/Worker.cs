using Microsoft.Extensions.Options;
using Spoleto.Delivery.Callback.Common.Services;
using Spoleto.Delivery.Callback.MasterPost.Models;

namespace Spoleto.Delivery.Callback.MasterPost
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly MasterPostCallbackOptions _options;
        private readonly IServiceProvider _serviceProvider;

        private readonly TimeSpan _interval;
        private readonly Random _random = new();

        public Worker(ILogger<Worker> logger, IOptions<MasterPostCallbackOptions> options, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _options = options?.Value ?? throw new ArgumentNullException(nameof(MasterPostCallbackOptions));
            _serviceProvider = serviceProvider;
            _interval = TimeSpan.FromMinutes(_options.StatusCheckIntervalMinutes);
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("MasterPost status checker service running at: {datetime}", DateTime.Now);
                }

                using (IServiceScope scope = _serviceProvider.CreateScope())
                {
                    var cisRepository = scope.ServiceProvider.GetRequiredService<IRepository>();
                    var deliveryService = scope.ServiceProvider.GetRequiredService<IDeliveryService>();

                    var orders = await cisRepository.GetDeliveryOrdersWithNonFinalStatusAsync(cancellationToken);
                    _logger.LogInformation("Loaded {n} orders to check their delivery status.", orders.Count);

                    var successCount = 0;
                    foreach (var order in orders)
                    {
                        await Task.Delay(TimeSpan.FromSeconds(_random.Next(1, 30)), cancellationToken);

                        var actualOrder = await deliveryService.GetDeliveryOrderAsync(new() { Number = order.ExternalId });

                        var success = await cisRepository.UpdateDeliveryOrderStatusAsync(order.ExternalId, actualOrder.Status, cancellationToken);
                        if (success)
                        {
                            successCount++;
                        }
                    }

                    _logger.LogInformation("{n} orders were updated.", successCount);
                }

                _logger.LogInformation("The next status checking will start in {time}.", TimeSpanToString(_interval));
                await Task.Delay(_interval, cancellationToken);
            }
        }

        private string TimeSpanToString(TimeSpan interval)
        {
            string format;

            // Check if there are any days
            if (interval.Days > 0)
            {
                // Include days in the format string
                format = "d'd 'hh':'mm':'ss";
            }
            else
            {
                // Only include hours, minutes, and seconds
                format = "hh':'mm':'ss";
            }

            var toString = interval.ToString(format);
            return toString;
        }
    }
}
