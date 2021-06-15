using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakipNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KategoriController : Controller
    {
        // GET: KategoriController
        public ActionResult Index()
        {
            return View();
        }

        // GET: KategoriController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: KategoriController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KategoriController/Create
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

        // GET: KategoriController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: KategoriController/Edit/5
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

        // GET: KategoriController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KategoriController/Delete/5
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
