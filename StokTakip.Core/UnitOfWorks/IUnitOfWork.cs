using System.Threading.Tasks;
//using StokTakip.Core.Repositories;

namespace StokTakip.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        //IBrandRepository brand { get; }
        //ICategoryRepository categories { get; }
        //IContactRepository contact { get; }
        //INewsletterRepository newsletter { get; }
        //INewsRepository news { get; }
        //IPostRepository post { get; }
        //ISettingRepository setting { get; }
        //ISliderRepository slider { get; }
        //ISlugRepository slug { get; }
        //IUserRepository user { get; }
        Task CommitAsync();
        void Commit();
    }
}