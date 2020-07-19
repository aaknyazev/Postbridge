using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PostBridge.Domain.Postmessage;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PostBridge.Publisher
{
    public class Core : IHostedService, IDisposable
    {
        private readonly IPostmessageRepository _postmessageRepository;
        private Timer _timer;
        private readonly ILogger<Core> _logger;

        public Core (IPostmessageRepository postmessageRepository, ILogger<Core> logger)
        {
            _postmessageRepository = postmessageRepository;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Publisher Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
            TimeSpan.FromSeconds(1));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            int executionCount = 0;
            var count = Interlocked.Increment(ref executionCount);

            _logger.LogInformation(
                "Publisher Service is working. Count: {Count}", count);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Publisher Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
