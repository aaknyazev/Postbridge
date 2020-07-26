using PostBridge.Domain.Postmessage;
using System.Collections.Generic;

namespace PostBridge.Publisher.Service
{
    public interface IPostmessageService
    {
        Postmessage CreatePostmessage();
        IReadOnlyList<Postmessage> GetPostmessageByStatus( PostmessageStatus status );
        Postmessage UpdatePostmessage(Postmessage postmessage);
        bool SendPostmessageToBus(Postmessage postmessage);
        bool CheckPostmessageInBus(Postmessage postmessage);
    }
}
