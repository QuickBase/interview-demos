using Backend.DataAccess;
using Backend.Services;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace Backend.Business;

public class PopulationAggregator : IPopulationAggregator
{
    private readonly IDbManager dbManager;
    private readonly IStatService statService;
    private readonly string datasource;

    public PopulationAggregator(IDbManager dbManager, IStatService statService, string datasource)
    {
        this.dbManager = dbManager ?? throw new ArgumentNullException(nameof(dbManager));
        this.statService = statService ?? throw new ArgumentNullException(nameof(statService));
        this.datasource = datasource ?? throw new ArgumentNullException(nameof(datasource));
    }

    public async Task<IDictionary<string, int>> GetCombinedCountryPopulationsAsync()
    {
        IDictionary<string, int> primaryPopulations;

        using (DbConnection dbConnection = this.dbManager.GetConnection(datasource))
        {
            primaryPopulations = await this.dbManager.GetCountryPopulationsAsync(dbConnection);
        }

        IDictionary<string, int> secondaryPopulations = await this.statService.GetCountryPopulationsAsync();
        
        IDictionary<string, int> combinedPopulations = new Dictionary<string, int>(secondaryPopulations);

        // Add the missing populations or override with primary (database) populations where duplicates exist
        foreach (var country in primaryPopulations)
        {
            combinedPopulations[country.Key] = country.Value;
        }

        return combinedPopulations;
    }
}
