using Core.Repositories;
using Data.EntityFramework;
using Entities;

namespace Data.Repositories
{
    internal class SliderRepository : Repository<Slider>, ISliderRepository
    {
        public SliderRepository(AppDbContext context) : base(context)
        {
        }
    }
}