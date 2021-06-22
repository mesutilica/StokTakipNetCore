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
                    urun.Resim = FileHelper.FileLoader(Resim, filePath: "/Img/Urunler/");
                    urun.EklenmeTarihi = DateTime.Now;
                    manager.Add(urun);
                    return RedirectToAction(nameof(Index));
                }
                
            }
            catch
            {
                ModelState.AddModelError("","Hata Oluştu!");
            }
            ViewBag.KategoriId = new SelectList(kategoriManager.GetAll(), "Id", "KategoriAdi");
            ViewBag.MarkaId = new SelectList(markaManager.GetAll(), "Id", "MarkaAdi");
            return View();
        }

        // GET: UrunController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.KategoriId = new SelectList(kategoriManager.GetAll(), "Id", "KategoriAdi");
            ViewBag.MarkaId = new SelectList(markaManager.GetAll(), "Id", "MarkaAdi");
            return View();
        }

        // POST: UrunController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Urun urun, IFormFile Resim)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.KategoriId = new SelectList(kategoriManager.GetAll(), "Id", "KategoriAdi");
                ViewBag.MarkaId = new SelectList(markaManager.GetAll(), "Id", "MarkaAdi");
                return View();
            }
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
