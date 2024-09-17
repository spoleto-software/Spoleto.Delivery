
namespace Spoleto.Delivery.Callback.Services
{
    public class MasterPostStatusChecker : BackgroundService
    {
        private int executionCount = 0;
        private readonly ILogger<MasterPostStatusChecker> _logger;

        public MasterPostStatusChecker(ILogger<MasterPostStatusChecker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                executionCount++;

                _logger.LogInformation(
                    "Scoped Processing Service is working. Count: {Count}", executionCount);

                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}
