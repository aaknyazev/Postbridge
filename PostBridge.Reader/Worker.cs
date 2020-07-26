using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PostBridge.Domain.Postmessage;
using PostBridge.Reader.Service;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PostBridge.Reader
{
    public class Worker : IHostedService, IDisposable
    {
        private readonly IPostmessageService _postmessageService;
        private Timer _timer;
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger, IPostmessageService postmessageService)
        {
            _logger = logger;
            _postmessageService = postmessageService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Reader Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
            TimeSpan.FromSeconds(1));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            int executionCount = 0;
            var count = Interlocked.Increment(ref executionCount);

            _logger.LogInformation(
                "Reader Service is working. Count: {Count}", count);

            _postmessageService.ReceivePostmessageFromBus();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Reader Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
