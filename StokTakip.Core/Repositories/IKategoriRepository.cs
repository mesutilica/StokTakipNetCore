using StokTakip.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StokTakip.Core.Repositories
{
    public interface IKategoriRepository : IRepository<Kategori>
    {
        Task<Kategori> GetWithSlugByIdAsync(int categoryId);
        Task<IEnumerable<Kategori>> GetAllCategoriesBySlugsAsync();
    }
}