using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using TheScene.Core.Interface;
using TheScene.Core.Models.Event;
using TheScene.Infrastructure.Data.Entities;
using TheScene.Models;

namespace TheScene.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventService eventService;
        private readonly ICommonService commonService;

        public EventController(IEventService _eventService,
            ICommonService _commonService)
        {
            this.eventService = _eventService;
            this.commonService = _commonService;
        }

        /// <summary>
        /// Return All Events
        /// </summary>
        /// <param name="query">AllEventsQueryModel</param>
        /// <returns>Events</returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllEventsQueryModel query)
        {
            var result = await eventService.All(
                query.Genre,
                query.PerfomanceType,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllEventsQueryModel.EventsPerPage);

            query.TotalEventsCount = result.TotalCount;
            query.Genres = await commonService.AllGenresNames();
            query.PerfomanceTypes = await commonService.AllPerfomanceTypesNames();
            query.Events = result.Collection;

            return View(query);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if (!(await eventService.Exists(id)))
            {
                return RedirectToAction(nameof(All));
            }

            var model = await eventService.DetailsById(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            // TODO Check User id

            var model = new AddEventModel()
            {
                Perfomances = await commonService.AllPerfomances(),
                Locations = await commonService.AllLocations()
            };

            return View(model); 
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEventModel model)
        {
            // TODO Check User id

            if (!(await commonService.LocationExists(model.LocationId)))
            {
                ModelState.AddModelError(nameof(model.LocationId), "Location does not exists");
            }

            if (!(await commonService.LocationExists(model.PerfomanceId)))
            {
                ModelState.AddModelError(nameof(model.PerfomanceId), "Perfomance does not exists");
            }

            if (!ModelState.IsValid)
            {
                model.Locations = await commonService.AllLocations();
                model.Perfomances = await commonService.AllPerfomances();

                return View(model);
            }

            int id = await eventService.Create(model);

            return RedirectToAction(nameof(Details), new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!(await eventService.Exists(id)))
            {
                return RedirectToAction(nameof(All));
            }


            var Event = await eventService.DetailsById(id);

            var model = new EditEventModel()
            {
                Id = Event.Id,
                PerfomanceId = Event.Perfomance.Id,
                LocationId = Event.Perfomance.Id,
                OccupiedSeats = Event.OccupiedSeats,
                FreeSeats = Event.FreeSeats,
                PricePerTicket = Event.PricePerTicket,
                Date = Event.Date,
                IsPremiere = Event.IsPremiere
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditEventModel model)
        {
            //if (id != model.Id)
            //{
            //    return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            //}

            if (!(await eventService.Exists(model.Id)))
            {
                ModelState.AddModelError("", "Event does not exist");
                return View(model);
            }

            if (!ModelState.IsValid)
                return View(model);

            await eventService.Edit(model.Id, model);

            return RedirectToAction(nameof(Details), new {id = model.Id});
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (!(await eventService.Exists(id)))
            {
                return RedirectToAction(nameof(All));
            }

            var Event = await eventService.DetailsById(id);
            var model = new DeleteViewModel()
            {
                Title = Event.Perfomance.Title,
                Location = Event.LocationName,
                Image = Event.Perfomance.ImageURL,
                Date = Event.Date,
                PricePerTicket = Event.PricePerTicket,
                IsPremiere = Event.IsPremiere
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, DeleteViewModel model)
        {
            if (!(await eventService.Exists(id)))
            {
                return RedirectToAction(nameof(All));
            }

            //if ((await houseService.HasAgentWithId(id, User.Id())) == false)
            //{
            //    return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            //}

            await eventService.Delete(id);

            return RedirectToAction(nameof(All));
        }
    }
}
