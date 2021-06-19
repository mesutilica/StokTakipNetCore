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
    public class KategoriController : Controller
    {
        KategoriManager kategoriManager = new KategoriManager();
        // GET: KategoriController
        public ActionResult Index()
        {
            return View(kategoriManager.GetAll());
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
        public ActionResult Create(Kategori kategori)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    kategori.EklenmeTarihi = DateTime.Now;
                    kategoriManager.Add(kategori);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Kayıt eklenirken hata oluştu");
            }
            return View(kategori);
        }

        // GET: KategoriController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Kategori kategori = kategoriManager.Get(id.Value);
            if (kategori == null)
            {
                return NotFound();
            }
            return View(kategori);
        }

        // POST: KategoriController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Kategori kategori)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    kategoriManager.Update(kategori);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                ModelState.AddModelError("", "Kayıt güncellenirken hata oluştu");
            }
            return View(kategori);
        }

        // GET: KategoriController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Kategori kategori = kategoriManager.Get(id.Value);
            if (kategori == null)
            {
                return NotFound();
            }
            return View(kategori);
        }

        // POST: KategoriController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Kategori kategori = kategoriManager.Get(id);
                kategoriManager.Delete(kategori.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
