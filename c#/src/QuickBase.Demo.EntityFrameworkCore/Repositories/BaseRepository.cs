using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;

namespace QuickBase.Demo.EntityFrameworkCore.Repositories
{
    //Base class for all repositories in my application
    public class BaseRepository<TEntity, TPrimaryKey> : EfCoreRepositoryBase<DemoDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public BaseRepository(IDbContextProvider<DemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        //add common methods for all repositories
    }

    //A shortcut for entities which have an integer Id, do not add a method here
    public class BaseRepository<TEntity> : BaseRepository<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        public BaseRepository(IDbContextProvider<DemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
