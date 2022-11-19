using Microsoft.AspNetCore.Mvc;
using TheScene.Core.Interface;
using TheScene.Core.Models;
using TheScene.Core.Models.Event;

namespace TheScene.Controllers
{
    public class EventController : Controller, IEventController
    {
        public async Task<IActionResult> Details()
        {
            var model = new DetailEventModel();

            return View(model);
        }

        public async Task<IActionResult> All()
        {
            var model = new AllEventModel();

            return View(model);
        }

        public IActionResult Add() => View();

        public Task<IActionResult> Add(AddEventModel model)
        {
            throw new NotImplementedException();
        }
    }
}
