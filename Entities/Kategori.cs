using System;
using System.ComponentModel;

namespace StokTakip.Entities
{
    public class Kategori : IEntity
    {
        public int Id { get; set; }
        [DisplayName("Kategori")]
        public string KategoriAdi { get; set; }
        [DisplayName("Açıklama")]
        public string KategoriAciklamasi { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public bool Aktif { get; set; }
    }
}
