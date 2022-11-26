using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheScene.Core.Interface;
using TheScene.Core.Models.Event;
using TheScene.Models;

namespace TheScene.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventService eventService;
        private readonly IGenreService genreService;
        private readonly IPerfomanceTypeService perfomanceTypeService;

        public EventController(IEventService _eventService, IGenreService _genreService, IPerfomanceTypeService _perfomanceTypeService)
        {
            this.eventService = _eventService;
            this.genreService = _genreService;
            this.perfomanceTypeService = _perfomanceTypeService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
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
            query.Genres = await genreService.AllGenresNames();
            query.PerfomanceTypes = await perfomanceTypeService.AllPErfomanceTypesNames();
            query.Events = result.Collection;

            return View(result);
        }

        public async Task<IActionResult> Details()
        {
            var model = new DetailEventModel();

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
