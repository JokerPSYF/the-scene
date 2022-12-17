// ***********************************************************************
// Assembly         : TheScene
// Author           : Admin
// Created          : 12-16-2022
//
// Last Modified By : Admin
// Last Modified On : 12-16-2022
// ***********************************************************************
// <copyright file="LocationController.cs" company="TheScene">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheScene.Core.Interface;
using TheScene.Core.Models.Location;
using TheScene.Models;

namespace TheScene.Areas.Admin.Controllers
{
    /// <summary>
    /// Class LocationController.
    /// Implements the <see cref="TheScene.Areas.Admin.Controllers.BaseController" />
    /// </summary>
    /// <seealso cref="TheScene.Areas.Admin.Controllers.BaseController" />
    [Authorize]
    public class LocationController : BaseController
    {
        /// <summary>
        /// The common service
        /// </summary>
        private readonly ICommonService commonService;
        /// <summary>
        /// The location service
        /// </summary>
        private readonly ILocationService locationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationController"/> class.
        /// </summary>
        /// <param name="commonService">The common service.</param>
        /// <param name="locationService">The location service.</param>
        public LocationController(ICommonService commonService, ILocationService locationService)
        {
            this.commonService = commonService;
            this.locationService = locationService;
        }

        /// <summary>
        /// Return All Locations
        /// </summary>
        /// <param name="query">AllEventsQueryModel</param>
        /// <returns>Events</returns>
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllLocationQueryModel query)
        {
            var result = await locationService.AllLocationsInfo(
                query.PlaceType,
                query.SearchTerm,
                query.CurrentPage,
                AllLocationQueryModel.LocationsPerPage);

            query.TotalLocationCount = result.TotalCount;
            query.PlaceTypes = await commonService.AllPlaceTypesNames();
            query.Locations = result.Collection;

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
            if (!(await commonService.LocationExists(id)))
            {
                return RedirectToAction(nameof(All));
            }

            var model = await locationService.LocationDetailsById(id);

            return View(model);
        }

        /// <summary>
        /// Get View of add Location
        /// </summary>
        /// <returns>location model</returns>
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            // TODO Check User id

            var model = new LocationModel()
            {
                PlaceTypes = await commonService.AllPlaceTypes()
            };

            return View(model);
        }

        /// <summary>
        /// Post, Add new Location
        /// </summary>
        /// <param name="model">location model</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(LocationModel model)
        {
            // TODO Check User id        

            if (!ModelState.IsValid)
            {
                model.PlaceTypes = await commonService.AllPlaceTypes();
                return View(model);
            }

            int id = await locationService.CreateLocation(model);

            return RedirectToAction(nameof(All), new { id });
        }

        /// <summary>
        /// GET Edit Location
        /// </summary>
        /// <param name="id">location id</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!(await commonService.LocationExists(id)))
            {
                return RedirectToAction(nameof(All));
            }


            var location = await locationService.LocationDetailsById(id);
            location.PlaceTypes = await commonService.AllPlaceTypes();

            return View(location);
        }

        /// <summary>
        /// POST Edit location
        /// </summary>
        /// <param name="id">location id</param>
        /// <param name="model">location model</param>
        /// <returns>Ok</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(int id, LocationModel model)
        {
            //if (id != model.Id)
            //{
            //    return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            //}

            if (!(await commonService.LocationExists(model.Id)))
            {
                ModelState.AddModelError("", "location does not exist");
                model.PlaceTypes = await commonService.AllPlaceTypes();
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                model.PlaceTypes = await commonService.AllPlaceTypes();
                return View(model);
            }

            await locationService.LocationEdit(model.Id, model);

            return RedirectToAction(nameof(Details), new { id = model.Id });
        }

        /// <summary>
        /// GET view of delete location
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (!(await commonService.LocationExists(id)))
            {
                return RedirectToAction(nameof(All));
            }

            var loc = await locationService.LocationDetailsById(id);
            var model = new DeleteLocationModel()
            {
                Name = loc.Name,
                Address = loc.Address,
                Seats = loc.Seats,
                PlaceType = loc.PlaceTypeName
            };

            return View(model);
        }

        /// <summary>
        /// POST Delete location
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public async Task<IActionResult> Delete(int id, LocationModel model)
        {
            if (!(await commonService.LocationExists(id)))
            {
                return RedirectToAction(nameof(All));
            }

            await locationService.LocationDelete(id);

            return RedirectToAction(nameof(All));
        }
    }
}
