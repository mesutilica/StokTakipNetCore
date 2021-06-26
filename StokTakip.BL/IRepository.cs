using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.BL
{
    public interface IRepository<T> where T : class, new()
    {
        List<T> GetAll();
        List<T> List(Expression<Func<T, bool>> expression);
        T Get(int id);
        T Get(Expression<Func<T, bool>> expression = null);
        int Add(T entity);
        int Update(T entity);
        int Delete(int id);
    }
}
