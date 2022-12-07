using TheScene.Core.Models.Common;
using TheScene.Core.Models.Event;

namespace TheScene.Core.Interface
{
    public interface IEventService
    {
        public Task<QueryModel<AllEventModel>> All(
            string? genre = null, string? perfomanceType = null,
            string? searchTerm = null, EventSorting sorting = EventSorting.Soonest,
            int currentPage = 1, int eventPerPage = 5);

        public Task<int> Create(EventModel model);

        public Task Delete(int eventId);

        public Task<DetailEventModel> DetailsById(int eventId);

        public Task Edit(int eventId, EventModel model);

        public Task<bool> Exists(int eventId);

        public Task<int> GetEventGenreId(int houseId);

        public Task<int> GetEventPerfomanceTypeId(int houseId);
    }
}
