package com.quickbase.devint.dao;

import com.quickbase.devint.entity.Country;
import com.quickbase.devint.service.stat.ConcreteStatService;
import com.quickbase.devint.service.stat.StatService;
import org.junit.jupiter.api.Test;
import org.apache.commons.lang3.tuple.ImmutablePair;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;

import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.Mockito.when;

@ExtendWith(MockitoExtension.class)
class CountryStatDaoTest {
    private final static String TEST_COUNTRY_NAME = "Test1";
    private final static Integer TEST_COUNTRY_SIZE = 1;

    @Mock
    ConcreteStatService concreteStatService;

    @Test
    void getAll_mapsEntriesProperly() {
        when(concreteStatService.getCountryPopulations()).thenReturn(List.of(
                new ImmutablePair<String, Integer>(TEST_COUNTRY_NAME, TEST_COUNTRY_SIZE)
        ));
        Dao<Country> countryStatDao = new CountryStatDao(concreteStatService);

        List<Country> countries = countryStatDao.getAll();
        assertEquals(1, countries.size());
        assertEquals(TEST_COUNTRY_NAME, countries.get(0).getName());
        assertEquals(TEST_COUNTRY_SIZE, countries.get(0).getPopulation());
    }
}