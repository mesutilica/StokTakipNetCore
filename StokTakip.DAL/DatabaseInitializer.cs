using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StokTakip.Entities;
using System.Linq;

namespace StokTakip.DAL
{
    public static class DatabaseInitializer
    //CreateDatabaseIfNotExists<DatabaseContext> bu kod veritabanı yoksa bizim yazdığımız DatabaseContext sınıfı içerisindeki dbset lere bakarak ilgili tabloları veritabanında oluşturmayı sağlar
    {
        public static void Seed(IApplicationBuilder app)//Seed metodu parametre olarak aldığı DatabaseContext context elemanınını kullanarak veritabanı oluştuktan sonra işlem yapmamızı sağlar
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<DatabaseContext>();
            context.Database.Migrate(); // dotnet ef database update

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Kullanicilar.FirstOrDefault() == null)//entity framework linq kullanarak context.Kullanici.FirstOrDefault() koduyla veritabanındaki kullanıcı tablosunda her hangi bir kayıt var mı diye kontrol ettik eğer kayıt yoksa aşağıdaki kullanıcıyı veritabanına ekleyecek
                {
                    context.Kullanicilar.Add(new Kullanici()
                    {
                        Adi = "Admin",
                        Aktif = true,
                        Email = "admin@stoktakipweb.com",
                        KullaniciAdi = "admin",
                        KullaniciSifre = "123456"
                    }
                    );
                    context.SaveChanges();//veritabanındaki değişiklikleri(yani kullanıcı ekleme işlemini) kaydet
                }
            }
        }
    }
}
