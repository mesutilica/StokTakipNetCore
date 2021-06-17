using Core.Repositories;
using Data.EntityFramework;
using Entities;

namespace Data.Repositories
{
    internal class SettingRepository : Repository<Setting>, ISettingRepository
    {
        public SettingRepository(AppDbContext context) : base(context)
        {
        }
    }
}