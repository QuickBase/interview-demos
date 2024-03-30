package com.quickbase.devint.dao;

import com.quickbase.devint.entity.Country;
import lombok.extern.slf4j.Slf4j;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

/**
 * This CountryDbDao exposes population data stored in the database.
 */
@Slf4j
public class CountryDb implements Dao<Country> {
    private final static String GET_POPULATION_BY_COUNTRY = "SELECT country, population FROM CountryPopulation";
    private final String connection;

    public CountryDb(String connection) {
        this.connection = connection;
    }

    public Connection getConnection() {
        Connection c;
        log.debug("Connecting to {}", connection);
        try {
            c = DriverManager.getConnection(connection);
            createPopulationView(c);
        } catch (SQLException ex) {
            throw new RuntimeException(ex);
        }
        log.debug("Opened database successfully");

        return c;
    }

    @Override
    public List<Country> getAll() {
        List<Country> output = new ArrayList<>();
        try (Connection conn = getConnection(); Statement stmt = conn.createStatement()) {
            ResultSet rs = stmt.executeQuery(GET_POPULATION_BY_COUNTRY);
            while (rs.next()) {
                output.add(Country.of(rs.getString("country"), rs.getInt("population")));
            }
            rs.close();
        } catch (SQLException ex) {
            throw new RuntimeException(ex);
        }

        return output;
    }

    /**
     * The CityStateCountry database contains population numbers per city, so it requires a complicated query to get the
     * number per country. This method creates a temporary view that exposes the population per country.
     * TODO: Consider creating a table similar to the view defined here, so we can delete this method and query the
     *  database directly.
     */
    private void createPopulationView(Connection conn) {
        log.debug("Creating the CountryPopulation view");
        try (Statement stmt = conn.createStatement()) {
            stmt.executeUpdate("CREATE TEMP VIEW CountryPopulation AS SELECT " +
                    "c.CountryName country, " +
                    "SUM(city.Population) population " +
                    "FROM Country c " +
                    "JOIN State s " +
                    "ON c.CountryId = s.CountryId " +
                    "JOIN City city " +
                    "ON s.StateId = city.StateId " +
                    "GROUP BY country");
        } catch (SQLException sqle) {
            log.error("sql exception:" + sqle);
        }
    }
}
