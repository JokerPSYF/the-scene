using TheScene.Core.Exception;
using TheScene.Core.Interface;
using TheScene.Core.Models.Event;
using TheScene.Infrastructure.Data.Common;
using TheScene.Infrastructure.Data.Entities;

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

        public async Task<AllEventModel> All(
            string? Genre = null, string? perfomanceType = null,
            string? searchTerm = null, EventSorting sorting = EventSorting.Newest,
            int currentPage = 1, int housesPerPage = 5)
        {
            var result = new AddEventModel();
            var events = this.repo.AllReadonly<Event>()
                .Where(e => e.IsActive);

            if (!string.IsNullOrEmpty(Genre))
                events = events.Where(e => e.Perfomance.Genre.Name == Genre);

            if (!string.IsNullOrEmpty(perfomanceType))
                events = events.Where(e => e.Perfomance.PerfomanceType.Name == perfomanceType);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = $"%{searchTerm.ToLower()}%";
            }

            return null;
        }

    }
}
