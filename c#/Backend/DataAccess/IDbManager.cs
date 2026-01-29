using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace Backend.DataAccess;

/// <summary>
/// Manages database connections and operations for retrieving data.
/// </summary>
public interface IDbManager
{
    /// <summary>
    /// Gets a database connection to the specified datasource.
    /// </summary>
    /// <param name="datasource">The datasource connection string or identifier.</param>
    /// <param name="mode">The connection mode (default is "ReadWrite").</param>
    /// <returns>A <see cref="DbConnection"/> instance for the specified datasource.</returns>
    DbConnection GetConnection(string datasource, string mode = "ReadWrite");

    /// <summary>
    /// Retrieves the total population for each country from the database.
    /// </summary>
    /// <param name="dbConnection">The database connection to use for the query.</param>
    /// <returns>A dictionary mapping country names to their total population values.</returns>
    Task<IDictionary<string, int>> GetCountryPopulationsAsync(DbConnection dbConnection);
}
