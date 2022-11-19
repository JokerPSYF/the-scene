using Microsoft.AspNetCore.Mvc;
using TheScene.Core.Models.Event;

namespace TheScene.Core.Interface
{
    public interface IEventController
    {
        public Task<IActionResult> All();

        public Task<IActionResult> Details();

        public IActionResult Add();

        public Task<IActionResult> Add(AddEventModel model);
    }
}
