using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheScene.Core.Interface;
using TheScene.Models;

namespace TheScene.Controllers
{
    /// <summary>
    /// The only thing that the normal user will see
    /// </summary>
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
        public async Task<IActionResult> Index([FromQuery] EventsQueryModel query)
        {
            if (this.User.IsInRole())
            {
                return RedirectToAction("All", "Event", new { area = "Admin" });
            }

            var result = await eventService.All(
                query.Genre,
                query.SearchTerm,
                null,
                query.Sorting,
                query.CurrentPage,
                EventsQueryModel.EventsPerPage);

            query.TotalEventsCount = result.TotalCount;
            query.Genres = await commonService.AllGenresNames();
            query.Events = result.Collection;

            return View(query);
        }

        /// <summary>
        /// Return All Theatrical plays
        /// </summary>
        /// <param name="query">AllEventsQueryModel</param>
        /// <returns>Events</returns>
        [HttpGet]
        public async Task<IActionResult> Theatre([FromQuery] EventsQueryModel query)
        {
            //if (this.User.IsInRole())
            //{
            //    return RedirectToAction("All", "Event", new { area = "Admin"});
            //}

            var result = await eventService.All(
                query.Genre,
                "Theatrical play",
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                EventsQueryModel.EventsPerPage);

            query.TotalEventsCount = result.TotalCount;
            query.Genres = await commonService.AllGenresNames();
            query.Events = result.Collection;

            return View(query);
        }

        /// <summary>
        /// Return All Movies
        /// </summary>
        /// <param name="query">AllEventsQueryModel</param>
        /// <returns>Events</returns>
        [HttpGet]
        public async Task<IActionResult> Movie([FromQuery] EventsQueryModel query)
        {
            //if (this.User.IsInRole())
            //{
            //    return RedirectToAction("All", "Event", new { area = "Admin"});
            //}

            var result = await eventService.All(
                query.Genre,
                "Movie",
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                EventsQueryModel.EventsPerPage);

            query.TotalEventsCount = result.TotalCount;
            query.Genres = await commonService.AllGenresNames();
            query.Events = result.Collection;

            return View(query);
        }

        /// <summary>
        /// Return All Opera's
        /// </summary>
        /// <param name="query">AllEventsQueryModel</param>
        /// <returns>Events</returns>
        [HttpGet]
        public async Task<IActionResult> Opera([FromQuery] EventsQueryModel query)
        {
            //if (this.User.IsInRole())
            //{
            //    return RedirectToAction("All", "Event", new { area = "Admin"});
            //}

            var result = await eventService.All(
                query.Genre,
                "Opera",
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                EventsQueryModel.EventsPerPage);

            query.TotalEventsCount = result.TotalCount;
            query.Genres = await commonService.AllGenresNames();
            query.Events = result.Collection;

            return View(query);
        }

        /// <summary>
        /// Return All Ballets
        /// </summary>
        /// <param name="query">AllEventsQueryModel</param>
        /// <returns>Events</returns>
        [HttpGet]
        public async Task<IActionResult> Ballet([FromQuery] EventsQueryModel query)
        {
            //if (this.User.IsInRole())
            //{
            //    return RedirectToAction("All", "Event", new { area = "Admin"});
            //}

            var result = await eventService.All(
                query.Genre,
                "Ballet",
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                EventsQueryModel.EventsPerPage);

            query.TotalEventsCount = result.TotalCount;
            query.Genres = await commonService.AllGenresNames();
            query.Events = result.Collection;

            return View(query);
        }

        /// <summary>
        /// Return All Opera's
        /// </summary>
        /// <param name="query">AllEventsQueryModel</param>
        /// <returns>Events</returns>
        [HttpGet]
        public async Task<IActionResult> Concert([FromQuery] EventsQueryModel query)
        {
            //if (this.User.IsInRole())
            //{
            //    return RedirectToAction("All", "Event", new { area = "Admin"});
            //}

            var result = await eventService.All(
                query.Genre,
                "Concert",
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                EventsQueryModel.EventsPerPage);

            query.TotalEventsCount = result.TotalCount;
            query.Genres = await commonService.AllGenresNames();
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