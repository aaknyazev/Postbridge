using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PostBridge.Domain.Postmessage;
using PostBridge.Publisher.Service;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PostBridge.Publisher
{
    public class Worker : IHostedService, IDisposable
    {
        private readonly IPostmessageService _postmessageService;
        private Timer _timer;
        private readonly ILogger<Worker> _logger;

        public Worker (ILogger<Worker> logger, IPostmessageService postmessageService)
        {
            _logger = logger;
            _postmessageService = postmessageService;
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

            Postmessage postmessage = _postmessageService.CreatePostmessage();
            if (_postmessageService.SendPostmessageToBus(postmessage))
            {
                postmessage.Status = PostmessageStatus.Sent;
            }
            else
            {
                postmessage.Status = PostmessageStatus.TrySend;
            };
            _postmessageService.UpdatePostmessage(postmessage);
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
