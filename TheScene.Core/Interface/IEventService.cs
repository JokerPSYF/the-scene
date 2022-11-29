using TheScene.Core.Models.Common;
using TheScene.Core.Models.Event;

namespace TheScene.Core.Interface
{
    public interface IEventService
    {
        public Task<QueryModel<AllEventModel>> All(
            string? genre = null, string? perfomanceType = null,
            string? searchTerm = null, EventSorting sorting = EventSorting.Newest,
            int currentPage = 1, int eventPerPage = 5);

        public Task<int> Create(AddEventModel model);

        public Task Delete(int eventId);

        public Task<DetailEventModel> DetailsById(int eventId);

        public Task Edit(int eventId, EditEventModel model);

        public Task<bool> Exists(int eventId);

        public Task<int> GetEventGenreId(int houseId);

        public Task<int> GetEventPerfomanceTypeId(int houseId);
    }
}
