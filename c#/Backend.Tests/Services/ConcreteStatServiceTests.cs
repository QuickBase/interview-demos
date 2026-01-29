using Backend.Services;

namespace Backend.Tests.Services;

public class ConcreteStatServiceTests
{
    private readonly ConcreteStatService statService;

    public ConcreteStatServiceTests()
    {
        statService = new ConcreteStatService();
    }

    // TODO: Add tests for IStatService once the actual implementation is available.
    // Current tests are using the concrete service that returns hardcoded data.
    // Future tests should include:
    // - Testing error handling for API failures
    // - Testing response parsing and validation
    // - Testing timeout scenarios
    // - Testing retry logic if implemented
    // - Testing caching mechanisms if implemented

    [Fact]
    public async Task GetCountryPopulationsAsync_ReturnsPopulations_Success()
    {
        // Act
        var result = await statService.GetCountryPopulationsAsync();

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.True(result.Count == 28);
    }

    [Fact]
    public async Task GetCountryPopulationsAsync_ReturnsSameDataAsSync()
    {
        // Act
        var syncResult = statService.GetCountryPopulations();
        var asyncResult = await statService.GetCountryPopulationsAsync();

        // Assert
        Assert.Equal(syncResult.Count, asyncResult.Count);
        foreach (var country in syncResult)
        {
            Assert.True(asyncResult.ContainsKey(country.Key));
            Assert.Equal(country.Value, asyncResult[country.Key]);
        }
    }
}

