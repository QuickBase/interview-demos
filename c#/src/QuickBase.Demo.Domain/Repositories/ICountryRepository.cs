using Abp.Domain.Repositories;
using QuickBase.Demo.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace QuickBase.Demo.Domain.Repositories
{
    public interface ICountryRepository : IRepository<Country, int>
    {
        IQueryable<CountryPopulation> GetCountryPopulations();
        Task<IQueryable<CountryPopulation>> GetCountryPopulationsAsync();
    }
}
