using Microsoft.AspNetCore.Mvc;
using TheScene.Core.Interface;
using TheScene.Core.Models.Event;

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

        public async Task<IActionResult> All(string? genre = null, string? perfomanceType = null,
            string? searchTerm = null, EventSorting sorting = EventSorting.Newest,
            int currentPage = 1, int eventPerPage = 5)
        {
            var model = eventService.All(genre, perfomanceType, searchTerm, sorting, currentPage, eventPerPage);

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
