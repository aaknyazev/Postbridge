namespace Postbridge.MessageBroker.Bus
{
    public interface IMessageHandler<TRequest>
    {
        void Handle(TRequest message);
    }
}
