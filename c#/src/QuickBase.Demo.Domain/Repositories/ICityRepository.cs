using Abp.Domain.Repositories;
using QuickBase.Demo.Domain.Models;

namespace QuickBase.Demo.Domain.Repositories
{
    public interface ICityRepository : IRepository<City, int>
    {
    }
}
