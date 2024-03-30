package com.quickbase.devint.dao;

import com.quickbase.devint.entity.Country;
import org.junit.jupiter.api.Test;

import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;

class CountryDbDaoTest {
    // TODO: Setup an in-memory database when we need advanced test cases.
    private static final String testDb = "jdbc:sqlite:resources/test/citystatecountry.db";  // contains 1 country

    @Test
    public void getCountries_returnsExpectedPopulation() {
        CountryDbDao countryDbDao = new CountryDbDao(testDb);
        List<Country> countries = countryDbDao.getAll();

        assertEquals(1, countries.size());
        assertEquals("U.S.A.", countries.get(0).getName());
        assertEquals(311976362, countries.get(0).getPopulation());
    }
}