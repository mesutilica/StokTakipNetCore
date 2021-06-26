using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.DAL.UnitOfWork
{
    public class Uow
    {
        private readonly DatabaseContext _context;

        public Uow(DatabaseContext context)
        {
            _context = context;
        }
        //public IRepository<T> GetRepository<T>() where T : class, new()
        //{
        //    return new Repository<T>(_context);
        //}
    }
}
