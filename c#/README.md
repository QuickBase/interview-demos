# Materials for developer interviews for Quickbase

## Purpose
The purpose of this exercise is not to give a "gotcha" question or puzzle, but a straight-forward (albeit contrived)
example of the kind of requirement that might arise in a real project so that we have shared context for a technical 
conversation during the interview. We are interested in how you approach a project, so you should feel free to add new 
class files as well modify the files that are provided as you see fit. Use of your favorite libraries or frameworks is
encouraged, but not required. How you demonstrate the correctness of your implementation is up to you.

## Requirements
The project requirement is to aggregate data (in this case population statistics) from two disparate sources.
We've provided two classes to represent those sources. `SqliteDbManager.cs`, provides access to a SQL database containing population
data for cities.  Each city is in a state within a country.  You need to write a method to retrieve the total
population for each country.  The other class, `IStatService.cs`, returns a `List<Tuple<String, Integer>>` containing 
country population data. For the purposes of this exercise, we've provided a concrete class that just returns a 
hard-coded list, but in a real project, assume it would be calling an API.

The assignment is to implement a solution that consumes these two data sources and returns the combined list of
countries and their populations. In the event of duplicate population data for a given country, the data from
the sql database should be used. 

## Building and Running the code

This project assumes you're using Visual Studio 2022 or newer and depends on nuget.

That said, feel free to challenge any of the current limitations with your demo. Just keep the time limit in mind.

## Solution Structure

The solution has been organized into a clean, testable architecture:

```
Backend/
  Business/
    IPopulationAggregator.cs      # Interface for population aggregation logic
    PopulationAggregator.cs       # Combines data from DB and API sources
  DataAccess/
    IDbManager.cs                 # Interface for database operations
    SqliteDbManager.cs            # SQLite database implementation
  Services/
    IStatService.cs               # Interface for external API service
    ConcreteStatService.cs        # Implementation of stat service
  Models/
    CountryPopulation.cs          # Data model for country population
  Program.cs                      # Application entry point
```

### Key Design Decisions

1. **Separation of Concerns**: Business logic, data access, and external services are separated into distinct layers
2. **Dependency Injection**: All classes depend on interfaces for maximum testability
3. **PopulationAggregator**: New business class that encapsulates the logic for combining data sources

### Testing
The architecture is designed to be fully unit testable:
- Mock `IDbManager` to test business logic without a database
- Mock `IStatService` to simulate API responses
- Test `PopulationAggregator` independently with mocked dependencies
