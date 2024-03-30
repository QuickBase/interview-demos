package com.quickbase.devint.service.aggregation;

import com.quickbase.devint.dao.CountryDbDao;
import com.quickbase.devint.dao.CountryStatDao;
import com.quickbase.devint.entity.Country;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;

import java.util.List;
import java.util.Map;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.Mockito.when;

@ExtendWith(MockitoExtension.class)
class DefaultPopulationAggregatorTest {
    private final static String COUNTRY_1_NAME = "Country1";
    private final static String COUNTRY_2_NAME = "Country2";
    private final static Integer COUNTRY_1_POPULATION = 1;
    private final static Integer COUNTRY_2_POPULATION = 2;

    DefaultPopulationAggregator populationAggregator;

    @Mock
    CountryStatDao countryStatDao;

    @Mock
    CountryDbDao countryDbDao;

    @BeforeEach
    void setup() {
        this.populationAggregator =
                new DefaultPopulationAggregator(List.of(countryStatDao, countryDbDao));
    }

    @Test
    void getPopulationData_returnsOnNoData() {
        when(countryDbDao.getAll()).thenReturn(List.of());
        when(countryStatDao.getAll()).thenReturn(List.of());

        Map<String, Integer> result = populationAggregator.getPopulationData();
        assertEquals(0, result.size());
    }

    @Test
    void getPopulationData_mergesCountriesFromDifferentSources() {
        when(countryDbDao.getAll())
                .thenReturn(List.of(Country.of(COUNTRY_1_NAME, COUNTRY_1_POPULATION)));
        when(countryStatDao.getAll())
                .thenReturn(List.of(Country.of(COUNTRY_2_NAME, COUNTRY_2_POPULATION)));

        Map<String, Integer> result = populationAggregator.getPopulationData();
        assertEquals(COUNTRY_1_POPULATION, result.get(COUNTRY_1_NAME));
        assertEquals(COUNTRY_2_POPULATION , result.get(COUNTRY_2_NAME));
        assertEquals(2, result.keySet().size());
    }

    @Test
    void getPopulationData_overwritesDuplicateCountries() {
        when(countryDbDao.getAll()).thenReturn(
                List.of(
                        Country.of(COUNTRY_1_NAME, 10),
                        Country.of(COUNTRY_2_NAME, 20)
                ));
        when(countryStatDao.getAll()).thenReturn(
                List.of(
                        Country.of(COUNTRY_1_NAME, COUNTRY_1_POPULATION),
                        Country.of(COUNTRY_2_NAME, COUNTRY_2_POPULATION)
                ));

        Map<String, Integer> result = populationAggregator.getPopulationData();
        assertEquals(10, result.get(COUNTRY_1_NAME));
        assertEquals(20, result.get(COUNTRY_2_NAME));
        assertEquals(2, result.keySet().size());
    }
}