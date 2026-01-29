using System;
using System.Data.Common;
using System.Diagnostics;
using Microsoft.Data.Sqlite;

namespace Backend;

public class SqliteDbManager : IDbManager
{
    public DbConnection GetConnection(string datasource, string mode = "ReadWrite") //citystatecountry.db
    {
        DbConnection connection = null;

        Console.WriteLine("Getting DB Connection...");

        try
        {
            connection = new SqliteConnection($"Data Source={datasource};Mode={mode}");
            connection.Open();

            Console.WriteLine($"DB Connection to {datasource} opened successfully in {mode} mode.");
            
            return connection;
        }
        catch(SqliteException ex)
        {
            Console.WriteLine($"Error oppening DB Connection to {datasource}: {ex.Message}");
            //ToDo: make specific handling and logging based on SqliteException
            
            return null;
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error oppening DB Connection to {datasource}: {ex.Message}");
            //ToDo: make specific handling and logging based on Exception
            
            return null;
        }
        finally
        {
            Console.WriteLine($"Closing the DB connection to {datasource}...");

            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                Console.WriteLine($"DB connection to {datasource} closed.");
            }
            else
            {
                Console.WriteLine($"DB connection to {datasource} was not opened.");
            }
        }
    }
}
