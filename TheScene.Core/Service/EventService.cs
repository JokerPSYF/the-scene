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
        private readonly IRepository repository;
        private readonly IGuard guard;

        public EventService(IRepository _repo, IGuard _guard)
        {
            this.repository = _repo;
            this.guard = _guard;
        }

        public async Task<EventQueryModel> All(
            string? Genre = null, string? perfomanceType = null,
            string? searchTerm = null, EventSorting sorting = EventSorting.Newest,
            int currentPage = 1, int eventPerPage = 5)
        {
            var result = new EventQueryModel();
            var events = repository.AllReadonly<Event>()
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

                bool IsYearOfPerfomance = int.TryParse(searchTerm, out int year);

                if (IsDate)
                {
                    events = events
                        .Where(e => e.Date == date);
                }
                else if (IsYearOfPerfomance)
                {
                    events = events
                        .Where(e => e.Perfomance.Year == year);
                }
                else
                {
                    searchTerm = $"%{searchTerm.ToLower()}%";

                    events = events
                        .Where(e =>
                            EF.Functions.Like(e.Perfomance.Title.ToLower(), searchTerm) ||
                            EF.Functions.Like(e.Location.Name.ToLower(), searchTerm) ||
                            EF.Functions.Like(e.Perfomance.Director!.ToLower(), searchTerm) ||
                            EF.Functions.Like(e.Perfomance.Genre.Name.ToLower(), searchTerm) ||
                            EF.Functions.Like(e.Perfomance.Actors!.ToLower(), searchTerm));
                }

            }

            switch (sorting)
            {
                case EventSorting.Newest:
                    events = events.OrderByDescending(e => e.Date);
                    break;
                case EventSorting.Oldest:
                    events = events.OrderBy(e => e.Date);
                    break;
                case EventSorting.PremiereFirst:
                    events = events.OrderBy(e => e.IsPremiere);
                    break;
                default:
                    events = events.OrderBy(e => e.Id);
                    break;
            }

            result.Events = await events
                .Skip((currentPage - 1) * eventPerPage)
                .Take(eventPerPage)
                .Select(e => new AllEventModel()
                {
                    Id = e.Id,
                    PerfomanceTitle = e.Perfomance.Title,
                    LocationName = e.Location.Name,
                    PricePerTicket = e.PricePerTicket,
                    Date = e.Date,
                    IsPremiere = e.IsPremiere ?? false
                })
                .ToListAsync();

            result.TotalEventsCount = await events.CountAsync();

            return result;
        }

        public async Task<int> Create(AddEventModel model)
        {
            var eventEntity = new Event()
            {
                PerfomanceId = model.PerfomanceId,
                LocationId = model.LocationId,
                OccupiedSeats = 0,
                PricePerTicket = model.PricePerTicket,
                IsPremiere = model.IsPremiere
            };

            // We want the to take the seats from the location of the event
            var location = await repository.GetByIdAsync<Location>(model.LocationId);

            // Add them in freeSeats couse all free
            eventEntity.FreeSeats = location.Seats;

            await repository.AddAsync(eventEntity);
            await repository.SaveChangesAsync();

            return eventEntity.Id;
        }

        public async Task Delete(int eventId)
        {
            var eventEntity = await repository.GetByIdAsync<Event>(eventId);

            eventEntity.IsActive = false;

            await repository.SaveChangesAsync();
        }
    }
}
