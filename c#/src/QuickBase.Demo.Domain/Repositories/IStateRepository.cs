using Abp.Domain.Repositories;
using QuickBase.Demo.Domain.Models;

namespace QuickBase.Demo.Domain.Repositories
{
    public interface IStateRepository : IRepository<State, int>
    {
    }
}
