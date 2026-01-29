using Backend;
using System;
using System.Data.Common;

Console.WriteLine("Started.");

IDbManager db = new SqliteDbManager();

using DbConnection dbConnection = db.GetConnection("citystatecountry.db");

if (dbConnection == null)
{
    throw new Exception("Failed to get DB Connection");
}

Console.WriteLine("Finished.");