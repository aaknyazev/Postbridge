namespace Postbridge.MessageBroker.Bus
{
    public interface ITransitManager
    {
        bool Publish<T>(string subject, T message) where T : class;

        void Receive<T>(string subject, IMessageHandler<T> handler) where T : class;
    }
}
