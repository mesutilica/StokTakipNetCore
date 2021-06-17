using Core.Repositories;
using Data.EntityFramework;
using Entities;

namespace Data.Repositories
{
    internal class SlugRepository : Repository<Slug>, ISlugRepository
    {
        public SlugRepository(AppDbContext context) : base(context)
        {
        }
    }
}