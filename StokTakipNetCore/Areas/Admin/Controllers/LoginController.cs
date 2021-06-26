using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StokTakip.BL;
using StokTakip.Entities;

namespace StokTakipNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        KullaniciManager manager = new KullaniciManager();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Kullanici kullanici)
        {
            var admin = manager.Get(m => m.Email == kullanici.Email && m.KullaniciSifre == kullanici.KullaniciSifre && m.Aktif == true);
            if (admin != null) //eğer kullanıcı null sa yani bulunamadıysa
            {
                //Session kullanmak için nuget dan Microsoft.AspNetCore.Session paketini yüklüyoruz
                //Startup a services.AddSession(); ve app.UseSession(); ı ekliyoruz
                HttpContext.Session.SetString("admin", admin.KullaniciAdi); // Yeni bir session oluşturma.

                return Redirect("/Admin");//Sayfayı admin girişine yönlendir
            }
            ModelState.AddModelError("", "Kullanıcı Bulunamadı!");

            return View(kullanici);
        }
        public IActionResult Logout()
        {
            //HttpContext.Session.GetString("admin"); // Sessiondan değer getirme.
            HttpContext.Session.Clear(); // Tüm sessionları temizleme.
            return Redirect("/Admin/Login");
        }
    }
}
