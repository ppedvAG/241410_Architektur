using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ppedv.PuecklerPalace.Model.Contracts.Data;
using ppedv.PuecklerPalace.Model.DomainModel;

namespace ppedv.PuecklerPalace.UI.WebMVC.Controllers
{
    public class EisController : Controller
    {
        private readonly IRepository repo;

        public EisController(IRepository repo)
        {
            this.repo = repo;
        }

        // GET: EisController
        public ActionResult Index()
        {
            var eis = repo.GetAll<Eissorte>();
            return View(eis);
        }

        // GET: EisController/Details/5
        public ActionResult Details(int id)
        {
            return View(repo.Get<Eissorte>(id));
        }

        // GET: EisController/Create
        public ActionResult Create()
        {
            return View(new Eissorte() { Name = "NEU", Preis = 3.11m });
        }

        // POST: EisController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Eissorte eis)
        {
            try
            {
                repo.Add(eis);
                repo.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EisController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repo.Get<Eissorte>(id));
        }

        // POST: EisController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Eissorte eis)
        {
            try
            {
                repo.Update(eis);
                repo.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EisController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repo.Get<Eissorte>(id));
       }

        // POST: EisController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Eissorte eis)
        {
            try
            {
                repo.Delete(eis);
                repo.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
