using Microsoft.EntityFrameworkCore;
using StokTakip.Core.Entities;

namespace StokTakip.DAL
{
    public class DatabaseContext : DbContext
    {
        /*public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DatabaseContext()
        {
            Database.EnsureCreated();
            using (DatabaseContext context = new DatabaseContext())
            {
                if (context.Kullanicilar.FirstOrDefault() == null)
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
                    context.SaveChanges();
                }
            }
        }*/
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Marka> Markalar { get; set; }
        public DbSet<Siparis> Siparis { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=StokTakipNetCore;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            base.OnModelCreating(modelBuilder);
        }
    }
}
