using Backend.Business;
using Backend.DataAccess;
using Backend.Services;
using Moq;
using System.Data.Common;

namespace Backend.Tests.Business;

public class PopulationAggregatorTests
{
    private readonly Mock<IDbManager> mockDbManager;
    private readonly Mock<IStatService> mockStatService;
    private readonly Mock<DbConnection> mockDbConnection;
    private const string TestDatasource = "test-datasource";

    public PopulationAggregatorTests()
    {
        mockDbManager = new Mock<IDbManager>();
        mockStatService = new Mock<IStatService>();
        mockDbConnection = new Mock<DbConnection>();
    }

    [Fact]
    public void Constructor_WithNullDbManager_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => 
            new PopulationAggregator(null, mockStatService.Object, TestDatasource));
    }

    [Fact]
    public void Constructor_WithNullStatService_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => 
            new PopulationAggregator(mockDbManager.Object, null, TestDatasource));
    }

    [Fact]
    public void Constructor_WithNullDatasource_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => 
            new PopulationAggregator(mockDbManager.Object, mockStatService.Object, null));
    }

    [Fact]
    public async Task GetCombinedCountryPopulationsAsync_WithNoData_ReturnsEmptyDictionary()
    {
        // Arrange
        mockDbManager.Setup(m => m.GetConnection(TestDatasource, It.IsAny<string>()))
            .Returns(mockDbConnection.Object);
        
        mockDbManager.Setup(m => m.GetCountryPopulationsAsync(mockDbConnection.Object))
            .ReturnsAsync(new Dictionary<string, int>());
        
        mockStatService.Setup(s => s.GetCountryPopulationsAsync())
            .ReturnsAsync(new Dictionary<string, int>());

        PopulationAggregator aggregator = new(mockDbManager.Object, mockStatService.Object, TestDatasource);

        // Act
        var result = await aggregator.GetCombinedCountryPopulationsAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetCombinedCountryPopulationsAsync_WithOnlyDatabaseData_ReturnsDatabaseData()
    {
        // Arrange
        Dictionary<string, int> dbPopulations = new()
        {
            { "USA", 331000000 },
            { "Canada", 38000000 }
        };

        mockDbManager.Setup(m => m.GetConnection(TestDatasource, It.IsAny<string>()))
            .Returns(mockDbConnection.Object);
        
        mockDbManager.Setup(m => m.GetCountryPopulationsAsync(mockDbConnection.Object))
            .ReturnsAsync(dbPopulations);
        
        mockStatService.Setup(s => s.GetCountryPopulationsAsync())
            .ReturnsAsync(new Dictionary<string, int>());

        PopulationAggregator aggregator = new(mockDbManager.Object, mockStatService.Object, TestDatasource);

        // Act
        var result = await aggregator.GetCombinedCountryPopulationsAsync();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal(331000000, result["USA"]);
        Assert.Equal(38000000, result["Canada"]);
    }

    [Fact]
    public async Task GetCombinedCountryPopulationsAsync_WithOnlyServiceData_ReturnsServiceData()
    {
        // Arrange
        Dictionary<string, int> servicePopulations = new()
        {
            { "Mexico", 129000000 },
            { "Brazil", 212000000 }
        };

        mockDbManager.Setup(m => m.GetConnection(TestDatasource, It.IsAny<string>()))
            .Returns(mockDbConnection.Object);
        
        mockDbManager.Setup(m => m.GetCountryPopulationsAsync(mockDbConnection.Object))
            .ReturnsAsync(new Dictionary<string, int>());
        
        mockStatService.Setup(s => s.GetCountryPopulationsAsync())
            .ReturnsAsync(servicePopulations);

        PopulationAggregator aggregator = new(mockDbManager.Object, mockStatService.Object, TestDatasource);

        // Act
        var result = await aggregator.GetCombinedCountryPopulationsAsync();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal(129000000, result["Mexico"]);
        Assert.Equal(212000000, result["Brazil"]);
    }

    [Fact]
    public async Task GetCombinedCountryPopulationsAsync_WithDifferentCountries_CombinesBothSources()
    {
        // Arrange
        Dictionary<string, int> dbPopulations = new()
        {
            { "USA", 331000000 },
            { "Canada", 38000000 }
        };

        Dictionary<string, int> servicePopulations = new()
        {
            { "Mexico", 129000000 },
            { "Brazil", 212000000 }
        };

        mockDbManager.Setup(m => m.GetConnection(TestDatasource, It.IsAny<string>()))
            .Returns(mockDbConnection.Object);
        
        mockDbManager.Setup(m => m.GetCountryPopulationsAsync(mockDbConnection.Object))
            .ReturnsAsync(dbPopulations);
        
        mockStatService.Setup(s => s.GetCountryPopulationsAsync())
            .ReturnsAsync(servicePopulations);

        PopulationAggregator aggregator = new(mockDbManager.Object, mockStatService.Object, TestDatasource);

        // Act
        var result = await aggregator.GetCombinedCountryPopulationsAsync();

        // Assert
        Assert.Equal(4, result.Count);
        Assert.Equal(331000000, result["USA"]);
        Assert.Equal(38000000, result["Canada"]);
        Assert.Equal(129000000, result["Mexico"]);
        Assert.Equal(212000000, result["Brazil"]);
    }

    [Fact]
    public async Task GetCombinedCountryPopulationsAsync_WithDuplicateCountries_DatabaseTakesPrecedence()
    {
        // Arrange
        Dictionary<string, int> dbPopulations = new()
        {
            { "USA", 331000000 },
            { "Canada", 38000000 }
        };

        Dictionary<string, int> servicePopulations = new()
        {
            { "USA", 300000000 },  // Different value from database
            { "Mexico", 129000000 }
        };

        mockDbManager.Setup(m => m.GetConnection(TestDatasource, It.IsAny<string>()))
            .Returns(mockDbConnection.Object);
        
        mockDbManager.Setup(m => m.GetCountryPopulationsAsync(mockDbConnection.Object))
            .ReturnsAsync(dbPopulations);
        
        mockStatService.Setup(s => s.GetCountryPopulationsAsync())
            .ReturnsAsync(servicePopulations);

        PopulationAggregator aggregator = new(mockDbManager.Object, mockStatService.Object, TestDatasource);

        // Act
        var result = await aggregator.GetCombinedCountryPopulationsAsync();

        // Assert
        Assert.Equal(3, result.Count);
        Assert.Equal(331000000, result["USA"]); // Database value, not service value
        Assert.Equal(38000000, result["Canada"]);
        Assert.Equal(129000000, result["Mexico"]);
    }

    [Fact]
    public async Task GetCombinedCountryPopulationsAsync_CallsGetConnectionWithCorrectParameters()
    {
        // Arrange
        mockDbManager.Setup(m => m.GetConnection(TestDatasource, It.IsAny<string>()))
            .Returns(mockDbConnection.Object);
        
        mockDbManager.Setup(m => m.GetCountryPopulationsAsync(mockDbConnection.Object))
            .ReturnsAsync(new Dictionary<string, int>());
        
        mockStatService.Setup(s => s.GetCountryPopulationsAsync())
            .ReturnsAsync(new Dictionary<string, int>());

        PopulationAggregator aggregator = new(mockDbManager.Object, mockStatService.Object, TestDatasource);

        // Act
        await aggregator.GetCombinedCountryPopulationsAsync();

        // Assert
        mockDbManager.Verify(m => m.GetConnection(TestDatasource, It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public async Task GetCombinedCountryPopulationsAsync_CallsGetCountryPopulationsAsyncOnBothServices()
    {
        // Arrange
        mockDbManager.Setup(m => m.GetConnection(TestDatasource, It.IsAny<string>()))
            .Returns(mockDbConnection.Object);
        
        mockDbManager.Setup(m => m.GetCountryPopulationsAsync(mockDbConnection.Object))
            .ReturnsAsync(new Dictionary<string, int>());
        
        mockStatService.Setup(s => s.GetCountryPopulationsAsync())
            .ReturnsAsync(new Dictionary<string, int>());

        PopulationAggregator aggregator = new(mockDbManager.Object, mockStatService.Object, TestDatasource);

        // Act
        await aggregator.GetCombinedCountryPopulationsAsync();

        // Assert
        mockDbManager.Verify(m => m.GetCountryPopulationsAsync(mockDbConnection.Object), Times.Once);
        mockStatService.Verify(s => s.GetCountryPopulationsAsync(), Times.Once);
    }
}
