using Core.Repositories;
using Data.EntityFramework;
using Entities;

namespace Data.Repositories
{
    internal class NewsletterRepository : Repository<Newsletter>, INewsletterRepository
    {
        public NewsletterRepository(AppDbContext context) : base(context)
        {
        }
    }
}