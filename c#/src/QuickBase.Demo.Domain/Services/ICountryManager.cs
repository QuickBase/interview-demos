using Abp.Domain.Services;
using QuickBase.Demo.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace QuickBase.Demo.Domain.Services
{
    public interface ICountryManager : IDomainService
    {
        IQueryable<CountryPopulation> GetCountryPopulations();
        Task<IQueryable<CountryPopulation>> GetCountryPopulationsAsync();
    }
}
