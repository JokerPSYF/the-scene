using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheScene.Core.Interface;
using TheScene.Models;

namespace TheScene.Controllers
{
    public class HomeController : Controller
    {

        private readonly IEventService eventService;
        private readonly ICommonService commonService;

        public HomeController(IEventService _eventService,
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
        public async Task<IActionResult> Index([FromQuery] AllEventsQueryModel query)
        {
            //if (this.User.IsInRole())
            //{
            //    return RedirectToAction("All", "Event", new { area = "Admin"});
            //}

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

        /// <summary>
        /// Show details of an event
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int id)
        {
            if (!(await eventService.Exists(id)))
            {
                return RedirectToAction(nameof(Index));
            }

            var model = await eventService.DetailsById(id);

            return View(model);
        }

        /// <summary>
        /// Show Error
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}