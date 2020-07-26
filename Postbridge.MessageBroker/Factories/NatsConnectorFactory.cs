using NATS.Client;

namespace Postbridge.MessageBroker.Factories
{
    internal class NatsConnectorFactory : INatsConnectorFactory
    {
        public IEncodedConnection GetConnector(string url)
        {
            return new ConnectionFactory().CreateEncodedConnection(url);
        }
    }
}
