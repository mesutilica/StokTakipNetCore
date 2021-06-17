using Core.Repositories;
using Data.EntityFramework;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    internal class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public CategoryRepository(AppDbContext context) : base(context)
        {
            
        }
        public async Task<Category> GetWithSlugByIdAsync(int categoryId)
        {
            return await _appDbContext.Categories.Include(x => x.Slug).SingleOrDefaultAsync(x => x.Id == categoryId);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesBySlugsAsync()
        {
            return await _appDbContext.Categories.Include(x => x.Slug).ToListAsync();
        }
    }
}