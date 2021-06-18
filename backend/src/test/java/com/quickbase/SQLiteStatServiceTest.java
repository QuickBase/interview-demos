package com.quickbase;

import com.google.common.collect.ImmutableList;
import com.quickbase.devint.DBManager;
import com.quickbase.devint.DBManagerImpl;
import com.quickbase.devint.SQLiteStatService;
import lombok.extern.slf4j.Slf4j;
import org.apache.commons.lang3.tuple.Pair;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.TestInfo;
import reactor.test.StepVerifier;

import java.io.File;
import java.sql.DriverManager;
import java.sql.SQLException;

import static org.junit.jupiter.api.Assertions.assertFalse;

@Slf4j
public class SQLiteStatServiceTest {

    private static final String CREATE_TABLE_COUNTRY = "CREATE TABLE Country (CountryName TEXT, CountryId INTEGER);";
    private static final String CREATE_TABLE_STATE  = "CREATE TABLE State " +
            "(StateId INTEGER, StateName TEXT, CountryId INTEGER , " +
            "Primary key (StateId), Foreign key (CountryId) references Country(CountryId));";
    private static final String CREATE_TABLE_CITY = "CREATE TABLE City " +
            "(CityId INTEGER , CityName TEXT , StateId INTEGER , Population INTEGER, " +
            "Primary key (CityId), Foreign key (StateId) references State(StateId));";


    @BeforeEach
    private void createDataSource(TestInfo info) throws SQLException {
        try (var c = DriverManager.getConnection("jdbc:sqlite:" + testDbName(info)); var st = c.createStatement()) {
            st.executeUpdate(CREATE_TABLE_COUNTRY);
            st.executeUpdate(CREATE_TABLE_STATE);
            st.executeUpdate(CREATE_TABLE_CITY);
        }
    }

    @AfterEach
    private void deleteDataSource(TestInfo info) {
        final var f = new File(testDbName(info));
        log.info("Deleting: {}", f.getAbsolutePath());
        f.delete();
    }

    private String testDbName(TestInfo info) {
        return info.getTestMethod().get().getName();
    }

    private void insertCountry(DBManager db, int id, String name) throws SQLException {
        executeUpdate(db, "INSERT INTO Country(CountryId, CountryName) VALUES(" + id + ",'" + name + "')");
    }

    private void insertState(DBManager db, int id, String name, int countryId) throws SQLException {
        executeUpdate(db, "INSERT INTO State(StateId, StateName, CountryId) VALUES(" + id + ",'" + name + "'," + countryId + ")");
    }

    private void insertCity(DBManager db, String name, int stateId, int population) throws SQLException {
        executeUpdate(db, "INSERT INTO City(CityName, StateId, Population) VALUES('" + name + "'," + stateId + "," + population + ")");
    }

    private void executeUpdate(DBManager db, String... updates) throws SQLException {
        try (var c = db.getConnection(); var st = c.createStatement()) {
            for (String update : updates) {
                st.executeUpdate(update);
            }
        }
    }

    @Test
    void verifyPopulationQuery(TestInfo testInfo) throws SQLException, ClassNotFoundException {
        final var db = new DBManagerImpl("jdbc:sqlite:" + testDbName(testInfo));
        try (var c = db.getConnection(); var st = c.createStatement()) {
            final var service = new SQLiteStatService(db);
            {
                final var rs = st.executeQuery("select * from Country");
                assertFalse(rs.next(), "New Data Source should be empty");
                rs.close();
            }

            insertCountry(db, 1, "A");
            insertState(db, 1, "StateA", 1);
            insertCity(db, "StateACity1", 1, 1);
            // single country single city
            StepVerifier.create(service.getCountryPopulations())
                    .as("Country with single city should have the population of the city")
                    .expectNextMatches(l -> l.size() == 1 && l.get(0).getValue() == 1)
                    .expectComplete()
                    .verify();

            insertCity(db, "StateACity2", 1, 1);
            // single country multiple cities
            StepVerifier.create(service.getCountryPopulations())
                    .as("Country with multiple cities should have the total population of the cities")
                    .expectNextMatches(l -> l.size() == 1 && l.get(0).getValue() == 2)
                    .expectComplete()
                    .verify();

            insertState(db, 2, "StateB", 1);
            insertCity(db, "StateACity2", 2, 1);

            // single country multiple states
            StepVerifier.create(service.getCountryPopulations())
                    .as("Country with multiple states and cities should have a total of the combined population")
                    .expectNextMatches(l -> l.size() == 1 && l.get(0).getValue() == 3)
                    .expectComplete()
                    .verify();

            // multiple countries
            insertCountry(db, 2, "B");
            insertState(db, 3, "StateC", 2);
            insertCity(db, "StateCCity1", 3, 10);
            insertCity(db, "StateCCity2", 3, 10);

            StepVerifier.create(service.getCountryPopulations())
                    .as("Multiple countries population is grouped properly")
                    .expectNextMatches(l -> {
                        final var expected = ImmutableList.of(Pair.of("A", 3), Pair.of("B", 20));
                        return l.size() == 2 &&  l.containsAll(expected);
                    })
                    .expectComplete()
                    .verify();

        }
    }
}
