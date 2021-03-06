using Abp.EntityFrameworkCore;
using QuickBase.Demo.Domain.Models;
using QuickBase.Demo.Domain.Repositories;

namespace QuickBase.Demo.EntityFrameworkCore.Repositories
{
    public class StateRepository : BaseRepository<State, int>, IStateRepository
    {
        public StateRepository(IDbContextProvider<DemoDbContext> dbContextProvider)
        : base(dbContextProvider)
        {
        }
    }
}
