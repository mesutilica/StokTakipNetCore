using System;
using System.ComponentModel;

namespace StokTakip.Entities
{
    public class Urun : IEntity
    {
        public int Id { get; set; }
        public int KategoriId { get; set; }
        public int MarkaId { get; set; }
        [DisplayName("Ürün Adı")]
        public string UrunAdi { get; set; }
        [DisplayName("Ürün Açıklaması")]
        public string UrunAciklamasi { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        [DisplayName("Fiyat")]
        public decimal UrunFiyati { get; set; }
        public int Kdv { get; set; }
        [DisplayName("Stok")]
        public int StokMiktari { get; set; }
        public bool Aktif { get; set; }
        public bool Anasayfa { get; set; }
        public string Resim { get; set; }
        public virtual Kategori Kategori { get; set; }//urun sınıfı ile kategori sınıfı arasında bire bir ilişki kurduk
        public virtual Marka Marka { get; set; }
    }
}