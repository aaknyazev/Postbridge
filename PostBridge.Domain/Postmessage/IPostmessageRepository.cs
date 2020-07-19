using System.Collections.Generic;

namespace PostBridge.Domain.Postmessage
{
    public interface IPostmessageRepository: IBaseRepository<Postmessage>
    {
        IReadOnlyList<Postmessage> GetByStatus(PostmessageStatus status);
    }
}
