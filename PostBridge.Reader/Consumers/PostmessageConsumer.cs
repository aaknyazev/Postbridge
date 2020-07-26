using PostBridge.Domain.Postmessage;
using System;

namespace PostBridge.Reader.Consumers
{
    internal class PostmessageConsumer : IPostmessageConsumer
    {
        private readonly IPostmessageRepository _postmessageRepository;

        public PostmessageConsumer(IPostmessageRepository postmessageRepository)
        {
            _postmessageRepository = postmessageRepository;
        }

        public void Handle(Postmessage message)
        {
            message.Status = PostmessageStatus.Receved;
            message.ReceivedDate = DateTime.Now;
            _postmessageRepository.Update(message);
        }
    }
}
