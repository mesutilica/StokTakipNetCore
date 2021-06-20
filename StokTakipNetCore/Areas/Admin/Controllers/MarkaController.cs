using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StokTakip.BL;
using StokTakip.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakipNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MarkaController : Controller
    {
        MarkaManager manager = new MarkaManager();
        // GET: MarkaController
        public ActionResult Index()
        {
            return View(manager.GetAll());
        }

        // GET: MarkaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MarkaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MarkaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Marka marka)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    marka.EklenmeTarihi = DateTime.Now;
                    manager.Add(marka);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Kayıt eklenirken hata oluştu");
            }
            return View(marka);
        }

        // GET: MarkaController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Marka marka = manager.Get(id.Value);
            if (marka == null)
            {
                return NotFound();
            }
            return View(marka);
        }

        // POST: MarkaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Marka marka)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    manager.Update(marka);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                ModelState.AddModelError("", "Kayıt güncellenirken hata oluştu");
            }
            return View(marka);
        }

        // GET: MarkaController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Marka marka = manager.Get(id.Value);
            if (marka == null)
            {
                return NotFound();
            }
            return View(marka);
        }

        // POST: MarkaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Marka marka = manager.Get(id);
                manager.Delete(marka.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
