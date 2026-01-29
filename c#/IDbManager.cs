using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace Backend;

public interface IDbManager
{
    DbConnection GetConnection(string datasource, string mode = "ReadWrite");

    Task<IDictionary<string, int>> GetCountryPopulationsAsync(DbConnection dbConnection);
}
