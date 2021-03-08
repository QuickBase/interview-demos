using Microsoft.EntityFrameworkCore;
using Persistence.Interfaces;
using System.Linq;

namespace Persistence
{
    public abstract class DataRepositoryBase : IDataRepository
    {
        protected readonly DbContext _dbContext;

        public DataRepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected abstract IQueryable<T> Get<T>() where T : DataModelBase;
    }
}
