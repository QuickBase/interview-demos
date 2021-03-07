using System;
using System.Data.Common;

namespace Backend
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started");
            Console.WriteLine("Getting DB Connection...");

            IDbManager db = new SqliteDbManager();
            DbConnection conn = db.getConnection();

            if (conn == null)
            {
                Console.WriteLine("Failed to get connection");
            }
        }
    }
}
