using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheScene.Core.Interface;

namespace TheScene.Controllers
{
    public class PerfomanceController : Controller, IPerfomanceController
    {
        // GET: PerfomanceController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PerfomanceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PerfomanceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PerfomanceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PerfomanceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PerfomanceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
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
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
