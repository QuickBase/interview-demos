using Microsoft.Data.Sqlite;
using Persistence.Interfaces;
using System;
using System.Data.Common;

namespace Persistence
{
    public class SqliteDbManager : IDbManager
    {
        private SqliteConnection _sqlLiteConnection = null;
        public DbConnection GetConnection()
        {
            try
            {
                if (_sqlLiteConnection != null &&
                    _sqlLiteConnection.State != System.Data.ConnectionState.Closed)
                {
                    return _sqlLiteConnection;
                }

                _sqlLiteConnection = new SqliteConnection("Data Source=citystatecountry.db;Version=3;FailIfMissing=True");
                _sqlLiteConnection.Open();

                return _sqlLiteConnection;
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
