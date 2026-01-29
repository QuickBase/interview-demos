using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend;

interface IStatService
{
    IDictionary<string, int> GetCountryPopulations();
    Task<IDictionary<string, int>> GetCountryPopulationsAsync();
}
