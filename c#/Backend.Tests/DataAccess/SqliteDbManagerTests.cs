using Backend.DataAccess;
using Backend.Models;
using Dapper;
using Moq;
using Moq.Dapper;
using System.Data.Common;

namespace Backend.Tests.DataAccess;

public class SqliteDbManagerTests
{
    private readonly SqliteDbManager dbManager;
    private readonly Mock<DbConnection> mockDbConnection;

    public SqliteDbManagerTests()
    {
        dbManager = new SqliteDbManager();
        mockDbConnection = new Mock<DbConnection>();
    }

    [Fact]
    public async Task GetCountryPopulationsAsync_WithValidConnection_ReturnsPopulations()
    {
        // Arrange
        List<CountryPopulation> databaseResults = new()
        {
            new CountryPopulation { CountryName = "USA", TotalPopulation = 331000000 },
            new CountryPopulation { CountryName = "Canada", TotalPopulation = 38000000 },
            new CountryPopulation { CountryName = "Mexico", TotalPopulation = 129000000 }
        };

        mockDbConnection
            .SetupDapperAsync(c => c.QueryAsync<CountryPopulation>(
                It.IsAny<string>(),
                null,
                null,
                null,
                null))
            .ReturnsAsync(databaseResults);

        // Act
        var result = await dbManager.GetCountryPopulationsAsync(mockDbConnection.Object);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
        Assert.Equal(331000000, result["USA"]);
        Assert.Equal(38000000, result["Canada"]);
        Assert.Equal(129000000, result["Mexico"]);
    }

    [Fact]
    public async Task GetCountryPopulationsAsync_WithNoData_ReturnsEmptyDictionary()
    {
        // Arrange
        List<CountryPopulation> databaseResults = new();

        mockDbConnection
            .SetupDapperAsync(c => c.QueryAsync<CountryPopulation>(
                It.IsAny<string>(),
                null,
                null,
                null,
                null))
            .ReturnsAsync(databaseResults);

        // Act
        var result = await dbManager.GetCountryPopulationsAsync(mockDbConnection.Object);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetCountryPopulationsAsync_WithSingleCountry_ReturnsSingleEntry()
    {
        // Arrange
        List<CountryPopulation> databaseResults = new()
        {
            new CountryPopulation { CountryName = "USA", TotalPopulation = 331000000 }
        };

        mockDbConnection
            .SetupDapperAsync(c => c.QueryAsync<CountryPopulation>(
                It.IsAny<string>(),
                null,
                null,
                null,
                null))
            .ReturnsAsync(databaseResults);

        // Act
        var result = await dbManager.GetCountryPopulationsAsync(mockDbConnection.Object);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(331000000, result["USA"]);
    }

    [Fact]
    public async Task GetCountryPopulationsAsync_WithNullConnection_ReturnsEmptyDictionary()
    {
        // Act
        var result = await dbManager.GetCountryPopulationsAsync(null);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetCountryPopulationsAsync_WithDatabaseException_ReturnsEmptyDictionary()
    {
        // Arrange
        mockDbConnection
            .SetupDapperAsync(c => c.QueryAsync<CountryPopulation>(
                It.IsAny<string>(),
                null,
                null,
                null,
                null))
            .Throws(new Exception("Database error"));

        // Act
        var result = await dbManager.GetCountryPopulationsAsync(mockDbConnection.Object);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }
}
