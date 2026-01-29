using System.Data.Common;

namespace Backend;

public interface IDbManager
{
    DbConnection GetConnection(string datasource, string mode = "ReadWrite");
}
