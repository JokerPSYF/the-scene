using Microsoft.EntityFrameworkCore;
using System.Globalization;
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
                bool IsDate = DateTime.TryParseExact(
                    searchTerm, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out DateTime date);

                if (IsDate)
                {
                    events = events
                        .Where(e => e.Date == date);
                }
                else
                {
                    searchTerm = $"%{searchTerm.ToLower()}%";

                    events = events
                        .Where(e => EF.Functions.Like(e.Perfomance.Title.ToLower(), searchTerm) ||
                            EF.Functions.Like(e.Location.Name.ToLower(), searchTerm) ||
                            (e.Perfomance.Year? == int.TryParse(searchTerm, out int year))
                            );
                }

            }

            return null;
        }

    }
}
