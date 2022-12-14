// ***********************************************************************
// Assembly         : TheScene
// Author           : Admin
// Created          : 11-12-2022
//
// Last Modified By : Admin
// Last Modified On : 12-17-2022
// ***********************************************************************
// <copyright file="HomeController.cs" company="TheScene">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheScene.Core.Interface;
using TheScene.Models;
using static TheScene.Areas.Admin.Constants.AdminConstants;

namespace TheScene.Controllers
{
    /// <summary>
    /// The only thing that the normal user will see
    /// </summary>
    [Authorize]
    public class HomeController : Controller
    {

        /// <summary>
        /// The event service
        /// </summary>
        private readonly IEventService eventService;
        /// <summary>
        /// The common service
        /// </summary>
        private readonly ICommonService commonService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="_eventService">The event service.</param>
        /// <param name="_commonService">The common service.</param>
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
            if (this.User.IsInRole(Administrator))
            {
                return RedirectToAction("All", "Event", new { area = "Admin" });
            }

            var result = await eventService.All(
                query.Genre,
                query.PerfomanceType,
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
        /// We use it redirect to Index but to show only the events of the right perfomance type
        /// </summary>
        /// <param name="perfType">perfomance type</param>
        /// <returns>Events</returns>
        [HttpGet]
        public async Task<IActionResult> NavBar(string perfType)
        {
            //if (this.User.IsInRole())
            //{
            //    return RedirectToAction("All", "Event", new { area = "Admin" });
            //}

            EventsQueryModel query = new EventsQueryModel();

            //var result = await eventService.All(perfomanceType: perfType);

            query.PerfomanceType = perfType;

            return RedirectToAction("Index", routeValues: query);
        }

        /// <summary>
        /// Show details of an event
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        public async Task<IActionResult> Details(int id)
        {
            if (!(await eventService.Exists(id)))
            {
                return RedirectToAction("Index", "Home");
            }

            var model = await eventService.DetailsById(id);

            return View(model);
        }

        /// <summary>
        /// Show Error
        /// </summary>
        /// <returns>IActionResult.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}