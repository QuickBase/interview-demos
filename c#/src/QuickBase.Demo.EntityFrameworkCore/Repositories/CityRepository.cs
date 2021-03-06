using Abp.EntityFrameworkCore;
using QuickBase.Demo.Domain.Models;
using QuickBase.Demo.Domain.Repositories;

namespace QuickBase.Demo.EntityFrameworkCore.Repositories
{
    public class CityRepository : BaseRepository<City, int>, ICityRepository
    {
        public CityRepository(IDbContextProvider<DemoDbContext> dbContextProvider)
        : base(dbContextProvider)
        {
        }
    }
}
