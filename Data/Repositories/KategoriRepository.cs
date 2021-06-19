using Core.Repositories;
using Data.EntityFramework;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    internal class KategoriRepository : Repository<Kategori>, IKategoriRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public KategoriRepository(AppDbContext context) : base(context)
        {
            
        }
        public async Task<Kategori> GetWithSlugByIdAsync(int KategoriId)
        {
            return await _appDbContext.Categories.Include(x => x.Slug).SingleOrDefaultAsync(x => x.Id == KategoriId);
        }

        public async Task<IEnumerable<Kategori>> GetAllCategoriesBySlugsAsync()
        {
            return await _appDbContext.Categories.Include(x => x.Slug).ToListAsync();
        }
    }
}