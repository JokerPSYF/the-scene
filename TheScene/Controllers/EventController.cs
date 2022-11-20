using Microsoft.AspNetCore.Mvc;
using TheScene.Core.Models.Event;

namespace TheScene.Controllers
{
    public class EventController : Controller
    {
        public async Task<IActionResult> Details()
        {
            var model = new DetailEventModel();

            return View(model);
        }

        public async Task<IActionResult> All()
        {
            var model = new EventQueryModel();

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
