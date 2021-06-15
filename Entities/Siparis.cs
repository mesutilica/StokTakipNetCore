using System;
using System.Collections.Generic;

namespace StokTakip.Entities
{
    public class Siparis : IEntity
    {
        public int Id { get; set; }
        public string MusteriAdi { get; set; }
        public string MusteriSoyadi { get; set; }
        public string Ulke { get; set; }
        public string Adres { get; set; }
        public string SiparisNo { get; set; }
        public int UrunId { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public DateTime TeslimatTarihi { get; set; }
        public virtual List<Urun> Urunler { get; set; }
    }
}
