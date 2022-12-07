using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheScene.Core.Interface;
using TheScene.Core.Models.Event;
using TheScene.Core.Models.PerfomanceModels;
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

            var model = new PerfomanceModel()
            {
                Genres = await commonService.AllGenres(),
                PerfomanceTypes = await commonService.AllPerfomancesTypes()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PerfomanceModel model)
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

            var model = new PerfomanceModel()
            {
                Id = perfomance.Id,
                Title = perfomance.Title,
                Director = perfomance.Director,
                GenreId = perfomance.GenreId,
                PerfomanceTypeId = perfomance.PerfomanceTypeId,
                Description = perfomance.Description,
                Year = perfomance.Year,
                ImageURL = perfomance.ImageURL
            };

            model.Genres = await commonService.AllGenres();
            model.PerfomanceTypes = await commonService.AllPerfomancesTypes();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PerfomanceModel model)
        {
            //if (id != model.Id)
            //{
            //    return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            //}

            if (!(await perfomanceService.Exists(model.Id)))
            {
                ModelState.AddModelError("", "Perfomance does not exist");
                model.Genres = await commonService.AllGenres();
                model.PerfomanceTypes = await commonService.AllPerfomancesTypes();
                return View(model);
            }

            if (!(await commonService.GenreExists(model.GenreId)))
            {
                ModelState.AddModelError(nameof(model.GenreId), "Genre does not exist");
                model.Genres = await commonService.AllGenres();
                model.PerfomanceTypes = await commonService.AllPerfomancesTypes();
                return View(model);
            }

            if (!(await commonService.PerfomanceTypesExists(model.PerfomanceTypeId)))
            {
                ModelState.AddModelError(nameof(model.PerfomanceTypeId), "Perfomance type does not exist");
                model.Genres = await commonService.AllGenres();
                model.PerfomanceTypes = await commonService.AllPerfomancesTypes();
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                model.Genres = await commonService.AllGenres();
                model.PerfomanceTypes = await commonService.AllPerfomancesTypes();
                return View(model);
            }

            await perfomanceService.Edit(model.Id, model);

            return RedirectToAction(nameof(Details), new { id = model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (!(await perfomanceService.Exists(id)))
            {
                return RedirectToAction(nameof(All));
            }

            var perf = await perfomanceService.DetailsById(id);
            var model = new DeletePerfomanceModel()
            {
                Title = perf.Title,
                ImageURL = perf.ImageURL,
                Director = perf.Director,
                Genre = perf.Genre,
                Actors = perf.Actors,
                PerfomanceType = perf.PerfomanceType,
                Year = perf.Year
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, DeleteEventModel model)
        {
            if (!(await perfomanceService.Exists(id)))
            {
                return RedirectToAction(nameof(All));
            }

            //if ((await houseService.HasAgentWithId(id, User.Id())) == false)
            //{
            //    return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            //}

            await perfomanceService.Delete(id);

            return RedirectToAction(nameof(All));
        }
    }
}
