using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Services;

/// <summary>
/// Provides access to external statistics service for retrieving population data.
/// </summary>
public interface IStatService
{
    /// <summary>
    /// Gets country populations from the statistics service synchronously.
    /// </summary>
    /// <returns>A dictionary mapping country names to their population values.</returns>
    IDictionary<string, int> GetCountryPopulations();

    /// <summary>
    /// Gets country populations from the statistics service asynchronously.
    /// </summary>
    /// <returns>A dictionary mapping country names to their population values.</returns>
    Task<IDictionary<string, int>> GetCountryPopulationsAsync();
}
