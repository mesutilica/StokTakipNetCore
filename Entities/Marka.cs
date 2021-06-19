using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StokTakip.Entities
{
    public class Marka : IEntity
    {
        public int Id { get; set; }
        [DisplayName("Marka")]
        public string MarkaAdi { get; set; }
        [DisplayName("Açıklama")]
        public string MarkaAciklamasi { get; set; }
        [ScaffoldColumn(false)]
        public DateTime EklenmeTarihi { get; set; }
        public bool Aktif { get; set; }
        public string MarkaLogo { get; set; }
    }
}
