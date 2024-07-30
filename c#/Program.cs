using Backend;
using System;
using System.Data.Common;

Console.WriteLine("Started");
Console.WriteLine("Getting DB Connection...");

IDbManager db = new SqliteDbManager();
DbConnection conn = db.GetConnection();

if (conn == null)
{
    Console.WriteLine("Failed to get connection");
}