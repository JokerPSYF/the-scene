using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheScene.Core.Interface;
using TheScene.Core.Models.Event;
using TheScene.Core.Models.PerfomanceModels;
using TheScene.Core.Service;
using TheScene.Models;

namespace TheScene.Controllers
{
    [Authorize]
    public class PerfomanceController : Controller
    {
        private readonly IPerfomanceService perfomanceService;
        private readonly ICommonService commonService;

        public PerfomanceController(IPerfomanceService _perfomanceService,
            ICommonService _commonService)
        {
            this.perfomanceService = _perfomanceService;
            this.commonService = _commonService;
        }

        /// <summary>
        /// Return All Events
        /// </summary>
        /// <param name="query">AllEventsQueryModel</param>
        /// <returns>Events</returns>
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllPerfomanceQueryModel query)
        {
            var result = await perfomanceService.All(
                query.Genre,
                query.PerfomanceType,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllPerfomanceQueryModel.PerfomancePerPage);

            query.TotalPerfomanceCount = result.TotalCount;
            query.Genres = await commonService.AllGenresNames();
            query.PerfomanceTypes = await commonService.AllPerfomanceTypesNames();
            query.Perfomances = result.Collection;

            return View(query);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if (!(await perfomanceService.Exists(id)))
            {
                return RedirectToAction(nameof(All));
            }

            var model = await perfomanceService.DetailsById(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            // TODO Check User id

            var model = new AddPerfomanceModel()
            {
                Genres = await commonService.AllGenres()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPerfomanceModel model)
        {
            // TODO Check User id        

            if (!(await commonService.GenreExists(model.GenreId)))
            {
                ModelState.AddModelError(nameof(model.GenreId), "Genre does not exists");
            }

            if (!ModelState.IsValid)
            {
                model.Genres = await commonService.AllGenres();
                return View(model);
            }

            int id = await perfomanceService.Create(model);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!(await perfomanceService.Exists(id)))
            {
                return RedirectToAction(nameof(All));
            }


            var perfomance = await perfomanceService.DetailsById(id);

            var model = new AddPerfomanceModel()
            {
                Id = perfomance.Id,
                Title = perfomance.Title,
                Director = perfomance.Director,
                GenreId = perfomance.Genre.
            };

            model.Perfomances = await commonService.AllPerfomances();
            model.Locations = await commonService.AllLocations();

            return View(model);
        }

        // POST: PerfomanceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(All));
            }
            catch
            {
                return View();
            }
        }

        // GET: PerfomanceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PerfomanceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(All));
            }
            catch
            {
                return View();
            }
        }
    }
}
