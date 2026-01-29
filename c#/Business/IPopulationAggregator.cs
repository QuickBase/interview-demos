using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Business;

/// <summary>
/// Aggregates population data from multiple sources, combining database and external service data.
/// </summary>
public interface IPopulationAggregator
{
    /// <summary>
    /// Gets combined country populations from both database and external service sources.
    /// Database populations take precedence over service populations when duplicates exist.
    /// </summary>
    /// <returns>A dictionary mapping country names to their population values.</returns>
    Task<IDictionary<string, int>> GetCombinedCountryPopulationsAsync();
}
