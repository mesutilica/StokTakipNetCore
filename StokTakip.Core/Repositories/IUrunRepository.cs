using StokTakip.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StokTakip.Core.Repositories
{
    public interface IUrunRepository : IRepository<Urun>
    {
        Task<IEnumerable<Urun>> GetAllPostsBySlugsAndCategoriesAsync();
    }
}