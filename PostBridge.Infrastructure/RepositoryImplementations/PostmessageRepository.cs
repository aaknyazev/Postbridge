using PostBridge.Domain.Postmessage;
using PostBridge.Infrastructure.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace PostBridge.Infrastructure.RepositoryImplementations
{
    internal class PostmessageRepository: BaseRepository<Postmessage>, IPostmessageRepository
    {
        public PostmessageRepository(PostBridgeMsSqlServerContext context) : base(context)
        {
        }

        public IReadOnlyList<Postmessage> GetByStatus(PostmessageStatus status)
        {
            return Entities
                .Where(e => e.Status == status)
                .ToList();
        }
    }
}
