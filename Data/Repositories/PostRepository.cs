using Core.Repositories;
using Data.EntityFramework;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    internal class PostRepository : Repository<Post>, IPostRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public PostRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Post>> GetAllPostsBySlugsAndCategoriesAsync()
        {
            return await _appDbContext.Posts.Include(x=>x.Slug).Include(x => x.Category).ToListAsync();
        }
    }
}