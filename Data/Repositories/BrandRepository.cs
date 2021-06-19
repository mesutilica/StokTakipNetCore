using Core.Repositories;
using Data.EntityFramework;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public BrandRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Brand>> GetAllBrandsBySlugsAsync()
        {
            return await _appDbContext.Brands.Include(x => x.Slug).ToListAsync();
        }
    }
}