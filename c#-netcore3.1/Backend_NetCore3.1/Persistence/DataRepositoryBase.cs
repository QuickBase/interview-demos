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

        public abstract T GetById<T>(int id) where T : DataModelBase;
    }
}
