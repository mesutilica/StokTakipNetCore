using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StokTakip.DAL.Repositories
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

        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate);

        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);

        Task AddAsync(T entity);
    }
}