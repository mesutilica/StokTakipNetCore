using Microsoft.EntityFrameworkCore;
using StokTakip.DAL;
using StokTakip.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StokTakip.BL
{
    public class Repository<T> where T : class, IEntity, new()
    {
        DatabaseContext context;
        DbSet<T> _dbSet;
        public Repository()//Repository class ımızın constructor ı, bu class newlendiğinde içindeki kodlar ilk olarak çalışır
        {
            if (context == null)//eğer yukarda tanımladığımız context nesnesi boşsa
            {
                context = new DatabaseContext();//context i doldur
                _dbSet = context.Set<T>();
            }
        }
        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public List<T> List(Expression<Func<T, bool>> expression)//List metodu ile weritabanını linq metoduyla sorgular gönderip verileri filtreye göre getirtebiliriz
        {//Expression linq ile verileri sorgulamada kullanılan c# yapısıdır
            return _dbSet.Where(expression).ToList();//Burada ToList demeden önce where ifadesini ekliyoruz ve parantez içinde de gelen sorgumuzu çalıştıracağız expression kısmından
        }
        public T Get(int id)//T get metodu gelen id değerine göre veritabanındaki ilgili kaydı geri döndürür
        {
            return _dbSet.Find(id);//find metoduna verilen id değeri T tipinde yani bu metot hangi class için kullanılıyorsa (kullanıcı, kategori, ürün classı vb gibi) geriye ilgili id ye sahip kaydı döndürür
        }
        public T Get(Expression<Func<T, bool>> expression = null)//veritabanındaki 1 tane kaydı lambda expression kullanarak (x=>x. şeklinde yazarak) bulup getirmek için bu metodu yazdık
        {
            //return expression == null ? _dbSet.FirstOrDefault() : _dbSet.FirstOrDefault(expression);//Bu kod metodun kullanıldığı yerde bir lambda sorgusu yazılmışsa o sorguya uyan kaydı döndürür, lambda sorgusu yazılmadan çağrılırsa ilgili tablodaki ilk kaydı döndürür, eğer kayıt bulunamazsa null döndürür
            return _dbSet.FirstOrDefault(expression);
        }
        public int Add(T entity)
        {
            _dbSet.Add(entity);
            return context.SaveChanges();
        }
        public int Update(T entity)
        {
            _dbSet.Update(entity);//parametreden gelen entitiyi güncelle
            return context.SaveChanges();//ekleme işlemini veritabanına kaydet ve geriye etkilenen kayıt sayısını döndür
        }
        public int Delete(int id)
        {
            _dbSet.Remove(this.Get(id));
            return context.SaveChanges();
        }
    }
}
