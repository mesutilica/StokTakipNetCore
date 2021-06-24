using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StokTakip.BL;
using StokTakip.Entities;
using StokTakipNetCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakipNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UrunController : Controller
    {
        UrunManager manager = new UrunManager();
        KategoriManager kategoriManager = new KategoriManager();
        MarkaManager markaManager = new MarkaManager();
        // GET: UrunController
        public ActionResult Index()
        {
            return View(manager.GetAll()) ;
        }

        // GET: UrunController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UrunController/Create
        public ActionResult Create()
        {
            ViewBag.KategoriId = new SelectList(kategoriManager.GetAll(), "Id", "KategoriAdi");
            ViewBag.MarkaId = new SelectList(markaManager.GetAll(), "Id", "MarkaAdi");
            return View();
        }

        // POST: UrunController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Urun urun, IFormFile Resim)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    urun.EklenmeTarihi = DateTime.Now;
                    urun.Resim = FileHelper.FileLoader(Resim, filePath: "/Img/Urunler/");
                    manager.Add(urun);
                    return RedirectToAction(nameof(Index));
                }
                else ModelState.AddModelError("", "Kayıt Eklenemedi!");
            }
            catch
            {
                ModelState.AddModelError("","Hata Oluştu!");
            }
            ViewBag.KategoriId = new SelectList(kategoriManager.GetAll(), "Id", "KategoriAdi");
            ViewBag.MarkaId = new SelectList(markaManager.GetAll(), "Id", "MarkaAdi");
            return View(urun);
        }

        // GET: UrunController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return BadRequest();
            Urun urun = manager.Get(id.Value);
            if (urun == null) return NotFound();
            ViewBag.KategoriId = new SelectList(kategoriManager.GetAll(), "Id", "KategoriAdi", urun.KategoriId);
            ViewBag.MarkaId = new SelectList(markaManager.GetAll(), "Id", "MarkaAdi", urun.MarkaId);
            return View(urun);
        }

        // POST: UrunController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Urun urun, int id, IFormFile Resim, string resmiSil)
        {
            if (id != urun.Id)
            {
                return NotFound();
            }
            try
            {
                if (ModelState.IsValid)
                {
                    if (resmiSil == "on")
                        if (FileHelper.FileTerminator("/Img/Urunler/", urun.Resim)) urun.Resim = string.Empty;
                    if (Resim != null && Resim.Length > 0) urun.Resim = FileHelper.FileLoader(Resim, filePath: "/Img/Urunler/");
                    manager.Update(urun);
                    return RedirectToAction(nameof(Index));
                }
                else ModelState.AddModelError("", "Kayıt Güncellenemedi!");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            ViewBag.KategoriId = new SelectList(kategoriManager.GetAll(), "Id", "KategoriAdi", urun.KategoriId);
            ViewBag.MarkaId = new SelectList(markaManager.GetAll(), "Id", "MarkaAdi", urun.MarkaId);
            return View(urun);
        }

        // GET: UrunController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UrunController/Delete/5
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
