using Backend;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

Console.WriteLine("Started.");

IDbManager db = new SqliteDbManager();
IStatService statService = new ConcreteStatService();

using DbConnection dbConnection = db.GetConnection("citystatecountry.db");

if (dbConnection == null)
{
    throw new Exception("Failed to get DB Connection.");
}

IDictionary<string, int> primaryPopulations = await db.GetCountryPopulationsAsync(dbConnection);
IDictionary<string, int> secondaryPopulations = await statService.GetCountryPopulationsAsync();
IDictionary<string, int> combinedPopulations = new Dictionary<string, int>(secondaryPopulations);

foreach (var country in primaryPopulations)
{
    combinedPopulations[country.Key] = country.Value;
}

foreach (var country in combinedPopulations.OrderBy(x => x.Key))
{
    Console.WriteLine($"Country: {country.Key}, Population: {country.Value}");
}

Console.WriteLine("Finished.");