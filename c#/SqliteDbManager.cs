using System;
using System.Data.Common;
using Microsoft.Data.Sqlite;

namespace Backend;

public class SqliteDbManager : IDbManager
{
    public DbConnection GetConnection()
    {
        try
        {
            var connection = new SqliteConnection("Data Source=citystatecountry.db;Mode=ReadWrite");
            connection.Open();
            return connection;
        }
        catch(SqliteException ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
}
