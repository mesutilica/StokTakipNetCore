using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StokTakip.Entities
{
    public class Kategori : IEntity
    {
        public int Id { get; set; }
        [DisplayName("Kategori")]
        public string KategoriAdi { get; set; }
        [DisplayName("Açıklama"), DataType(dataType:DataType.MultilineText)]
        public string KategoriAciklamasi { get; set; }
        [ScaffoldColumn(false)]
        public DateTime EklenmeTarihi { get; set; }
        public bool Aktif { get; set; }
    }
}
