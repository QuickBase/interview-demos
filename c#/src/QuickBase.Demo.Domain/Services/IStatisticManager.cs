using Abp.Domain.Services;
using QuickBase.Demo.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickBase.Demo.Domain.Services
{
    public interface IStatisticManager : IDomainService
    {
        IEnumerable<CountryPopulation> GetCountryPopulations();
        Task<IEnumerable<CountryPopulation>> GetCountryPopulationsAsync();
    }
}
