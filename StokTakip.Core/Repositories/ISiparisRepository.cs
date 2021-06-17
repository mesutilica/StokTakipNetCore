using StokTakip.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StokTakip.Core.Repositories
{
    public interface ISiparisRepository : IRepository<Siparis>
    {
        Task<Siparis> GetWithSlugByAsync();
        Task<IEnumerable<Siparis>> GetAllNewsBySlugsAsync();
    }
}