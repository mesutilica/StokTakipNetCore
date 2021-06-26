using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StokTakip.BL;
using StokTakip.Entities;

namespace StokTakipNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KullaniciController : Controller
    {
        KullaniciManager manager = new KullaniciManager();
        // GET: KullaniciController
        public ActionResult Index()
        {
            return View(manager.GetAll());
        }

        // GET: KullaniciController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: KullaniciController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KullaniciController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kullanici kullanici)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    manager.Add(kullanici);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                ModelState.AddModelError("", "Kayıt eklenirken hata oluştu");
            }
            return View(kullanici);
        }

        // GET: KullaniciController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Kullanici kullanici = manager.Get(id.Value);
            if (kullanici == null)
            {
                return NotFound();
            }
            return View(kullanici);
        }

        // POST: KullaniciController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Kullanici kullanici)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    manager.Update(kullanici);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                ModelState.AddModelError("", "Kayıt güncellenirken hata oluştu");
            }
            return View(kullanici);
        }

        // GET: KullaniciController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Kullanici kullanici = manager.Get(id.Value);
            if (kullanici == null)
            {
                return NotFound();
            }
            return View(kullanici);
        }

        // POST: KullaniciController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Kullanici kullanici = manager.Get(id);
                manager.Delete(kullanici.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
