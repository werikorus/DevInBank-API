using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftBank_api.Controllers
{
    public class RelatoriosController : Controller
    {
        // GET: RelatoriosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RelatoriosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RelatoriosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RelatoriosController/Create
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

        // GET: RelatoriosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RelatoriosController/Edit/5
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

        // GET: RelatoriosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RelatoriosController/Delete/5
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
