using Microsoft.EntityFrameworkCore;
using TheScene.Core.Interface;
using TheScene.Core.Models.Common;
using TheScene.Core.Models.Event;
using TheScene.Core.Models.Location;
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

        /// <summary>
        /// All events by the given criteria
        /// </summary>
        /// <param name="genre">genre name</param>
        /// <param name="perfomanceType">perfomance type name</param>
        /// <param name="searchTerm">search filter</param>
        /// <param name="sorting">EventSortning sort</param>
        /// <param name="currentPage">current page (int)</param>
        /// <param name="eventPerPage">how many events per page</param>
        /// <returns>QueryModel of AllEventModel</returns>
        public async Task<QueryModel<AllEventModel>> All(
            string? genre = null, string? perfomanceType = null,
            string? searchTerm = null, EventSorting sorting = EventSorting.Soonest,
            int currentPage = 1, int eventPerPage = 6)
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
                bool IsYearOfPerfomance = int.TryParse(searchTerm, out int year);
                if (IsYearOfPerfomance)
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
                            EF.Functions.Like(e.Perfomance.Description!.ToLower(), searchTerm) ||
                            EF.Functions.Like(e.Perfomance.Actors!.ToLower(), searchTerm));
                }

            }

            switch (sorting)
            {
                case EventSorting.Soonest:
                    events = events.OrderBy(e => e.Date);
                    break;
                case EventSorting.PremiereFirst:
                    events = events.OrderByDescending(e => e.IsPremiere);
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
                    IsPremiere = e.IsPremiere ?? false,
                    Year = e.Perfomance.Year,
                })
                .ToListAsync();

            result.TotalCount = await events.CountAsync();

            return result;
        }

        /// <summary>
        /// Create Event
        /// </summary>
        /// <param name="model">EventModel</param>
        /// <returns>event id</returns>
        public async Task<int> Create(EventModel model)
        {
            var eventEntity = new Event()
            {
                PerfomanceId = model.PerfomanceId,
                LocationId = model.LocationId,
                PricePerTicket = model.PricePerTicket,
                IsPremiere = model.IsPremiere,
                Date = model.Date
            };

            await repository.AddAsync(eventEntity);
            await repository.SaveChangesAsync();

            return eventEntity.Id;
        }

        /// <summary>
        /// Delete event
        /// </summary>
        /// <param name="eventId">event id</param>
        public async Task Delete(int eventId)
        {
            var eventEntity = await repository.GetByIdAsync<Event>(eventId);

            eventEntity.IsActive = false;

            await repository.SaveChangesAsync();
        }

        /// <summary>
        /// Show event details
        /// </summary>
        /// <param name="eventId">event id</param>
        public async Task<DetailEventModel> DetailsById(int eventId)
        {
            var result = await repository.AllReadonly<Event>()
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
                    Location = new LocationModel()
                    {
                        Id = e.Location.Id,
                        Name = e.Location.Name,
                        Address = e.Location.Address,
                        Seats = e.Location.Seats,
                        PlaceTypeId = e.Location.PlaceTypeId,
                        PlaceTypeName = e.Location.PlaceType.Name,
                        Link = e.Location.Link
                    },
                    //LocationId = e.Location.Id,
                    //LocationName = e.Location.Name,
                    //Address = e.Location.Address,
                    PricePerTicket = e.PricePerTicket,
                    Date = e.Date,
                    IsPremiere = e.IsPremiere ?? false
                }).FirstAsync();
            return result;
        }

        /// <summary>
        /// Edit event
        /// </summary>
        /// <param name="eventId">event id</param>
        /// <param name="model">event model (changed)</param>
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

        /// <summary>
        /// check if event exists
        /// </summary>
        /// <param name="eventId">event id</param>
        /// <returns>bool</returns>
        public async Task<bool> Exists(int eventId)
        {
            return await repository.AllReadonly<Event>()
                .AnyAsync(e => e.IsActive && e.Id == eventId);
        }
    }
}
