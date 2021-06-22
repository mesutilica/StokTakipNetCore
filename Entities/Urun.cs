using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StokTakip.Entities
{
    public class Urun : IEntity
    {
        public int Id { get; set; }
        [Required]
        public int KategoriId { get; set; }
        [Required]
        public int MarkaId { get; set; }
        [DisplayName("Ürün Adı")]
        [Required]
        public string UrunAdi { get; set; }
        [DisplayName("Ürün Açıklaması")]
        public string UrunAciklamasi { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        [DisplayName("Fiyat")]
        [Required]
        public decimal UrunFiyati { get; set; }
        public int Kdv { get; set; }
        [DisplayName("Stok")]
        public int StokMiktari { get; set; }
        public bool Aktif { get; set; }
        public bool Anasayfa { get; set; }
        public string Resim { get; set; }
        [Required]
        public virtual Kategori Kategori { get; set; }//urun sınıfı ile kategori sınıfı arasında bire bir ilişki kurduk
        [Required]
        public virtual Marka Marka { get; set; }
    }
}