using Microsoft.Extensions.Logging;
using Postbridge.MessageBroker.Bus;
using PostBridge.Domain.Postmessage;
using PostBridge.Reader.Consumers;

namespace PostBridge.Reader.Service
{
    internal class PostmessageService : IPostmessageService
    {
        private readonly ILogger<PostmessageService> _logger;
        private readonly ITransitManager _transitManager;
        private readonly IPostmessageConsumer _postmessageConsumer;

        public PostmessageService(
            ILogger<PostmessageService> logger,
            ITransitManager transitManager,
            IPostmessageConsumer postmessageConsumer)
        {
            _logger = logger;
            _transitManager = transitManager;
            _postmessageConsumer = postmessageConsumer;
        }

        public void ReceivePostmessageFromBus()
        {
            _transitManager.Receive("PostBridge.Publisher", _postmessageConsumer);
            _logger.LogInformation("Reader Service running.");
        }
    }
}
