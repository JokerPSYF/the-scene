using TheScene.Core.Exception;
using TheScene.Core.Interface;
using TheScene.Infrastructure.Data.Common;

namespace TheScene.Core.Service
{
    public class EventService : IEventService
    {
        private readonly IRepository repo;
        private readonly IGuard guard;

        public EventService(IRepository _repo, IGuard _guard)
        {
            this.repo = _repo;
            this.guard = _guard;
        }
    }
}
