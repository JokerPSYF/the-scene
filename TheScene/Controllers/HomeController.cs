using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheScene.Models;

namespace TheScene.Controllers
{
    public class HomeController : Controller
    {
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