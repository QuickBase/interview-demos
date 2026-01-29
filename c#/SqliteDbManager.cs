using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;

namespace Backend;

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
            IEnumerable<CountryPopulationDTO> result = await dbConnection.QueryAsync<CountryPopulationDTO>(sql);

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

            throw;
        }
    }
}
