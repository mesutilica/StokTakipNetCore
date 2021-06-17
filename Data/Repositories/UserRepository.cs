using Core.Repositories;
using Data.EntityFramework;
using Entities;

namespace Data.Repositories
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}