using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TheScene.Controllers
{
    public class PerfomanceController : Controller
    {
        // GET: PerfomanceController
        public ActionResult All()
        {
            return View();
        }

        // GET: PerfomanceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PerfomanceController/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: PerfomanceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(IFormCollection collection)
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
