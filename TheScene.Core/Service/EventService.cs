using Microsoft.EntityFrameworkCore;
using System.Globalization;
using TheScene.Core.Interface;
using TheScene.Core.Models.Common;
using TheScene.Core.Models.Event;
using TheScene.Core.Models.PerfomanceModels;
using TheScene.Infrastructure.Data.Common;
using TheScene.Infrastructure.Data.Entities;

namespace TheScene.Core.Service
{
    public class EventService : IEventService
    {
        private readonly IRepository repository;

        public EventService(IRepository _repo)
        {
            this.repository = _repo;
        }

        public async Task<QueryModel<AllEventModel>> All(
            string? genre = null, string? perfomanceType = null,
            string? searchTerm = null, EventSorting sorting = EventSorting.Newest,
            int currentPage = 1, int eventPerPage = 5)
        {
            var result = new QueryModel<AllEventModel>();
            var events = repository.AllReadonly<Event>()
                .Where(e => e.IsActive && e.Date >= DateTime.Today);

            if (!string.IsNullOrEmpty(genre))
                events = events.Where(e => e.Perfomance.Genre.Name == genre);

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
                    events = events.OrderBy(e => e.Date);
                    break;
                case EventSorting.Oldest:
                    events = events.OrderBy(e => e.Date);
                    break;
                case EventSorting.PremiereFirst:
                    events = events.OrderBy(e => e.IsPremiere);
                    break;
                default:
                    events = events.OrderBy(e => e.Date);
                    break;
            }

            result.Collection = await events
                .Skip((currentPage - 1) * eventPerPage)
                .Take(eventPerPage)
                .Select(e => new AllEventModel()
                {
                    Id = e.Id,
                    PerfomanceTitle = e.Perfomance.Title,
                    ImageUrl = e.Perfomance.ImageURL,
                    LocationName = e.Location.Name,
                    PricePerTicket = e.PricePerTicket,
                    Date = e.Date,
                    IsPremiere = e.IsPremiere ?? false
                })
                .ToListAsync();

            result.TotalCount = await events.CountAsync();

            return result;
        }

        public async Task<int> Create(EventModel model)
        {
            var eventEntity = new Event()
            {
                PerfomanceId = model.PerfomanceId,
                LocationId = model.LocationId,
                OccupiedSeats = 0,
                PricePerTicket = model.PricePerTicket,
                IsPremiere = model.IsPremiere,
                Date = model.Date
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

        public async Task<DetailEventModel> DetailsById(int eventId)
        {
            return await repository.AllReadonly<Event>()
                .Where(e => e.IsActive && e.Id == eventId)
                .Select(e => new DetailEventModel()
                {
                    Id = e.Id,
                    Perfomance = new DetailPerfomanceModel()
                    {
                        Id = e.Perfomance.Id,
                        Title = e.Perfomance.Title,
                        Director = e.Perfomance.Director,
                        Genre = e.Perfomance.Genre.Name,
                        Actors = e.Perfomance.Actors,
                        PerfomanceType = e.Perfomance.PerfomanceType.Name,
                        Year = e.Perfomance.Year,
                        ImageURL = e.Perfomance.ImageURL,
                        Description = e.Perfomance.Description
                    },
                    LocationName = e.Location.Name,
                    Address = e.Location.Address,
                    OccupiedSeats = e.OccupiedSeats,
                    FreeSeats = e.FreeSeats,
                    PricePerTicket = e.PricePerTicket,
                    Date = e.Date,
                    IsPremiere = e.IsPremiere ?? false
                }).FirstAsync();
        }

        public async Task Edit(int eventId, EventModel model)
        {
            var eventEntity = await repository.GetByIdAsync<Event>(eventId);

            eventEntity.PerfomanceId = model.PerfomanceId;
            eventEntity.LocationId = model.LocationId;
            eventEntity.PricePerTicket = model.PricePerTicket;
            eventEntity.Date = model.Date;
            eventEntity.IsPremiere = model.IsPremiere;

            await repository.SaveChangesAsync();
        }

        public async Task<bool> Exists(int eventId)
        {
            return await repository.AllReadonly<Event>()
                .AnyAsync(e => e.IsActive && e.Id == eventId);
        }

        public async Task<int> GetEventGenreId(int houseId)
        {
            return (await repository.GetByIdAsync<Event>(houseId)).Perfomance.GenreId;
        }

        public async Task<int> GetEventPerfomanceTypeId(int houseId)
        {
            return (await repository.GetByIdAsync<Event>(houseId)).Perfomance.PerfomanceTypeId;
        }

    }
}
