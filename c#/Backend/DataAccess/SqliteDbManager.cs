using Backend.Models;
using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DataAccess;

public class SqliteDbManager : IDbManager
{
    public DbConnection GetConnection(string datasource, string mode = "ReadWrite")
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
            Console.WriteLine($"Error opening DB Connection to {datasource}: {ex.Message}");
            //ToDo: make specific handling and logging based on SqliteException

            return null;
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error opening DB Connection to {datasource}: {ex.Message}");
            //ToDo: make specific handling and logging based on Exception

            return null;
        }
    }

    public async Task<IDictionary<string, int>> GetCountryPopulationsAsync(DbConnection dbConnection)
    {
        string sql = @"
SELECT c.CountryName, SUM(CAST(ci.Population AS INTEGER)) as TotalPopulation
FROM Country c
INNER JOIN State s ON c.CountryId = s.CountryId
INNER JOIN City ci ON s.StateId = ci.StateId
GROUP BY c.CountryName
";

        Console.WriteLine("Executing SQL query to get country populations...");

        try
        {
            if (dbConnection == null)
            {
                throw new ArgumentNullException(nameof(dbConnection), "Database connection not available.");
            }

            IEnumerable<CountryPopulation> result = await dbConnection.QueryAsync<CountryPopulation>(sql);

            IDictionary<string, int> countryPopulations = result.ToDictionary(
                item => item.CountryName,
                item => item.TotalPopulation
            );

            Console.WriteLine("SQL query executed successfully.");

            return countryPopulations;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error executing SQL query: {ex.Message}");
            //ToDo: Make sure to log the exception properly in a real-world application and raise some alarms.
            //The method seemlesly returns nothing in case of an error which will not break user-facing functionality,
            //but the issue should be logged and monitored for further investigation.

            return new Dictionary<string, int>();
        }
    }
}
