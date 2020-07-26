using Postbridge.MessageBroker.Bus;
using PostBridge.Domain.Postmessage;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace PostBridge.Publisher.Service
{
    internal class PostmessageService : IPostmessageService
    {
        private readonly IPostmessageRepository _postmessageRepository;
        private readonly IMessageResolver _messageResolver;
        private readonly ITransitManager _transitManager;

        public PostmessageService(
            IPostmessageRepository postmessageRepository,
            IMessageResolver messageResolver,
            ITransitManager transitManager)
        {
            _postmessageRepository = postmessageRepository;
            _messageResolver = messageResolver;
            _transitManager = transitManager;
        }

        public bool CheckPostmessageInBus(Postmessage postmessage)
        {
            throw new System.NotImplementedException();
        }

        public Postmessage CreatePostmessage()
        {
            Postmessage postmessage = new Postmessage
            {
                CreationDate = DateTime.Now,
                Status = PostmessageStatus.Creation,
                Message = _messageResolver.Resolve(),
                SentDate = (DateTime)SqlDateTime.MinValue,
                ReceivedDate = (DateTime)SqlDateTime.MinValue
            };
            _postmessageRepository.Create(postmessage);

            return postmessage;
        }

        public IReadOnlyList<Postmessage> GetPostmessageByStatus(PostmessageStatus status)
        {
            return _postmessageRepository.GetByStatus(status);
        }

        public bool SendPostmessageToBus(Postmessage postmessage)
        {
            return _transitManager.Publish("PostBridge.Publisher", postmessage);
        }

        public Postmessage UpdatePostmessage(Postmessage postmessage)
        {
            _postmessageRepository.Update(postmessage);

            return postmessage;
        }
    }
}
