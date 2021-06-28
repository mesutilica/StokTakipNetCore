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
    public class SiparisController : Controller
    {
        SiparisManager manager = new SiparisManager();
        // GET: SiparisController
        public async Task<ActionResult> Index()
        {
            return View(await manager.GetAllAsync());
        }

        // GET: SiparisController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SiparisController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SiparisController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Siparis siparis)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //manager.Add(kullanici);
                    await manager.AddAsync(siparis);
                    manager.Save();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                ModelState.AddModelError("", "Kayıt eklenirken hata oluştu");
            }
            return View(siparis);
        }

        // GET: SiparisController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var kayit = manager.Get(id.Value);
            if (kayit == null)
            {
                return NotFound();
            }
            return View(kayit);
        }

        // POST: SiparisController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Siparis siparis)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    manager.Update(siparis);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                ModelState.AddModelError("", "Kayıt güncellenirken hata oluştu");
            }
            return View(siparis);
        }

        // GET: SiparisController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var kayit = manager.Get(id.Value);
            if (kayit == null)
            {
                return NotFound();
            }
            return View(kayit);
        }

        // POST: SiparisController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var kayit = manager.Get(id);
                manager.Delete(kayit.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
