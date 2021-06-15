using StokTakip.DAL;
using StokTakip.Entities;
using System.Collections.Generic;
using System.Linq;

namespace StokTakip.BL
{
    public class MarkaManager
    {
        DatabaseContext context = new DatabaseContext();
        public List<Marka> GetAll()
        {
            return context.Markalar.ToList();//veritabanındaki markaları liste olarak döndür
        }
        public Marka Get(int id)
        {
            return context.Markalar.Find(id);//marka tablosundaki markalardan id si parametreden gelen id ye eşit olan markayı bul ve geri döndür
        }
        public int Add(Marka marka)
        {
            context.Markalar.Add(marka);//parametreden gelen markayı veritabanına ekle
            return context.SaveChanges();//ekleme işlemini veritabanına kaydet ve geriye etkilenen kayıt sayısını döndür
        }
        public int Update(Marka marka)
        {
            context.Markalar.Update(marka);//parametreden gelen markayı veritabanına ekle
            return context.SaveChanges();//ekleme işlemini veritabanına kaydet ve geriye etkilenen kayıt sayısını döndür
        }
        public int Delete(int id)
        {
            context.Markalar.Remove(this.Get(id));//this.Get(id) kodu delete metoduna parametre olarak gelen id yi alır ve yine buradaki get metoduna bu id yi göndererek ilgili kaydı bulup bulunan markanın veritabanından silinmesini sağlar
            return context.SaveChanges();
        }
    }
}
