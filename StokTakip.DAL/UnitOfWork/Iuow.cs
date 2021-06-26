using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.DAL.UnitOfWork
{
    interface Iuow
    {
        IRepository<T> GetRepository<T>() where T : class, new();
    }
}
