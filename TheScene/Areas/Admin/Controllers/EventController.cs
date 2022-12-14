// ***********************************************************************
// Assembly         : TheScene
// Author           : Admin
// Created          : 12-16-2022
//
// Last Modified By : Admin
// Last Modified On : 12-16-2022
// ***********************************************************************
// <copyright file="EventController.cs" company="TheScene">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheScene.Areas.Admin.Models;
using TheScene.Core.Interface;
using TheScene.Core.Models.Event;

namespace TheScene.Areas.Admin.Controllers
{
    /// <summary>
    /// Class EventController.
    /// Implements the <see cref="TheScene.Areas.Admin.Controllers.BaseController" />
    /// </summary>
    /// <seealso cref="TheScene.Areas.Admin.Controllers.BaseController" />
    public class EventController : BaseController
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
        /// Initializes a new instance of the <see cref="EventController"/> class.
        /// </summary>
        /// <param name="_eventService">The event service.</param>
        /// <param name="_commonService">The common service.</param>
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

        /// <summary>
        /// Show details of an event
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if (!(await eventService.Exists(id)))
            {
                return RedirectToAction("All");
            }

            var model = await eventService.DetailsById(id);

            return View(model);
        }

        /// <summary>
        /// GET Add new event
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            // TODO Check User id

            var model = new EventModel()
            {
                Perfomances = await commonService.AllPerfomances(),
                Locations = await commonService.AllLocations()
            };

            return View(model);
        }

        /// <summary>
        /// POST Add new event
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(EventModel model)
        {
            // TODO Check User id

            if (!(await commonService.LocationExists(model.LocationId)))
            {
                ModelState.AddModelError(nameof(model.LocationId), "Location does not exists");
            }

            if (!(await commonService.PerfomancesExists(model.PerfomanceId)))
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

            return RedirectToAction(nameof(Details), new { id });
        }

        /// <summary>
        /// GET Edit evet
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!(await eventService.Exists(id)))
            {
                return RedirectToAction("All");
            }


            var Event = await eventService.DetailsById(id);

            var model = new EventModel()
            {
                Id = Event.Id,
                PerfomanceId = Event.Perfomance.Id,
                LocationId = Event.Location.Id,
                PricePerTicket = Event.PricePerTicket,
                Date = Event.Date,
                IsPremiere = Event.IsPremiere
            };

            model.Perfomances = await commonService.AllPerfomances();
            model.Locations = await commonService.AllLocations();

            return View(model);
        }

        /// <summary>
        /// POST edit event
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">Event model</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EventModel model)
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

            return RedirectToAction(nameof(Details), new { id = model.Id });
        }

        /// <summary>
        /// GET delete event
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (!(await eventService.Exists(id)))
            {
                return RedirectToAction("All");
            }

            var Event = await eventService.DetailsById(id);
            var model = new DeleteEventModel()
            {
                Title = Event.Perfomance.Title,
                Location = Event.Location.Name,
                Image = Event.Perfomance.ImageURL,
                Date = Event.Date
            };

            return View(model);
        }

        /// <summary>
        /// POST Delete event
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public async Task<IActionResult> Delete(int id, DeleteEventModel model)
        {
            if (!(await eventService.Exists(id)))
            {
                return RedirectToAction("All");
            }

            //if ((await adminService.HasAgentWithId(id, User.Id())) == false)
            //{
            //    return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            //}

            await eventService.Delete(id);

            return RedirectToAction("All");
        }
    }
}
