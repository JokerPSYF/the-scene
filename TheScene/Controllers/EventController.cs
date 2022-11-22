using Microsoft.AspNetCore.Mvc;
using TheScene.Core.Interface;
using TheScene.Core.Models.Event;
using TheScene.Models;

namespace TheScene.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService eventService;

        public EventController(IEventService _eventService)
        {
            this.eventService = _eventService;
        }

        public async Task<IActionResult> Details()
        {
            var model = new DetailEventModel();

            return View(model);
        }

        public async Task<IActionResult> All([FromQuery] AllEventsQueryModel query)
        {
            var model = await eventService.All(
                query.Genre,
                query.PerfomanceType,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllEventsQueryModel.EventsPerPage);

            return View(model);
        }

        public IActionResult Add() => View();

        public async Task<IActionResult> Add(AddEventModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }
    }
}
