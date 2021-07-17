using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class SqliteDbManager : IDbManager
    {
        public DbConnection getConnection()
        {
            try
            {
                var connection = new SQLiteConnection("Data Source=citystatecountry.db;Version=3;FailIfMissing=True");
                return connection.OpenAndReturn();
            }
            catch(SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
