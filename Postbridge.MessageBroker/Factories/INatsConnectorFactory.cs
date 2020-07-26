using NATS.Client;

namespace Postbridge.MessageBroker.Factories
{
    public interface INatsConnectorFactory
    {
        IEncodedConnection GetConnector(string queueName);
    }
}
