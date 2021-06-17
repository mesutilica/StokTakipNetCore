using Core.Repositories;
using Data.EntityFramework;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    internal class NewsRepository : Repository<News>, INewsRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public NewsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<News>> GetAllNewsBySlugsAsync()
        {
            return await _appDbContext.News.Include(x => x.Slug).ToListAsync();
        }

        public async Task<News> GetWithSlugByAsync()
        {
            return await _appDbContext.News.Include(x => x.Slug).FirstOrDefaultAsync();
        }
    }
}