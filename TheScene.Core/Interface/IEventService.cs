using TheScene.Core.Models.Event;

namespace TheScene.Core.Interface
{
    public interface IEventService
    {
        public Task<EventQueryModel> All(
            string? Genre = null, string? perfomanceType = null,
            string? searchTerm = null, EventSorting sorting = EventSorting.Newest,
            int currentPage = 1, int eventPerPage = 5);

        public Task<int> Create(AddEventModel model);

        public Task Delete(int eventId);

       // public Task Edit(int eventId), EditEventModel;
    }
}
