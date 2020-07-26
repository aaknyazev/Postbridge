using NATS.Client;

namespace Postbridge.MessageBroker.Bus
{
    public class CommonConsumer<T>
    {
        private readonly IMessageHandler<T> _messageHandler;

        public CommonConsumer(IMessageHandler<T> messageHandler)
        {
            _messageHandler = messageHandler;
        }

        internal void Process(EncodedMessageEventArgs args)
        {
            _messageHandler.Handle((T)args.ReceivedObject);
            args.Message.ArrivalSubscription.Unsubscribe();
        }
    }
}
