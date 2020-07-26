using NATS.Client;
using Postbridge.MessageBroker.Factories;

namespace Postbridge.MessageBroker.Bus
{
    internal class TransitManager : ITransitManager
    {
        private const string defaultNatsURL = "nats://localhost:4222";
        private readonly INatsConnectorFactory _natsConnectorFactory;

        public TransitManager(INatsConnectorFactory natsConnectorFactory)
        {
            _natsConnectorFactory = natsConnectorFactory;
        }

        public bool Publish<T>(string subject, T message) where T : class
        {
            try
            {
                using (IEncodedConnection connector = _natsConnectorFactory.GetConnector(defaultNatsURL))
                {
                    connector.Publish(subject, message);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Receive<T>(string subject, IMessageHandler<T> handler) where T: class
        {
            CommonConsumer<T> consumer = new CommonConsumer<T>(handler);
            using (IEncodedConnection connector = _natsConnectorFactory.GetConnector(defaultNatsURL))
            {
                IAsyncSubscription s = connector.SubscribeAsync(subject, (sender, args) => { consumer.Process(args); });
            }
        }
    }
}
