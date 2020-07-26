using Postbridge.MessageBroker.Bus;
using PostBridge.Domain.Postmessage;

namespace PostBridge.Reader.Consumers
{
    public interface IPostmessageConsumer : IMessageHandler<Postmessage>
    {
    }
}
