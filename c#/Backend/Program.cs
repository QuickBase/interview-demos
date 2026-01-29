using Backend.Business;
using Backend.DataAccess;
using Backend.Services;
using System;
using System.Collections.Generic;
using System.Linq;

Console.WriteLine("Started.");

IDbManager dbManager = new SqliteDbManager();
IStatService statService = new ConcreteStatService();
IPopulationAggregator aggregator = new PopulationAggregator(dbManager, statService, "citystatecountry.db");

IDictionary<string, int> combinedPopulations = await aggregator.GetCombinedCountryPopulationsAsync();

foreach (var country in combinedPopulations.OrderBy(x => x.Key))
{
    Console.WriteLine($"Country: {country.Key}, Population: {country.Value}");
}

Console.WriteLine("Finished.");