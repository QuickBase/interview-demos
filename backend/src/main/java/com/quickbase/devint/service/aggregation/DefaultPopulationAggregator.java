package com.quickbase.devint.service.aggregation;

import com.quickbase.devint.dao.Dao;
import com.quickbase.devint.entity.Country;
import com.quickbase.devint.service.names.CountryNameResolver;
import lombok.extern.slf4j.Slf4j;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * This class aggregates population data from a List of DAOs. Note that DAOs further up the list will
 * overwrite duplicated countries found in previous providers, i.e. the last DAO has the highest
 * priority.
 * TODO: Implement a better mechanism to configure data provider priority.
 */
@Slf4j
public class DefaultPopulationAggregator implements PopulationAggregator {
    private final List<Dao<Country>> countryDaos;
    private final CountryNameResolver countryNameResolver;

    public DefaultPopulationAggregator(List<Dao<Country>> countryDaos, CountryNameResolver countryNameMapper) {
        this.countryDaos = countryDaos;
        this.countryNameResolver = countryNameMapper;
    }

    @Override
    public Map<String, Integer> getPopulationData() {
        Map<String, Integer> result = new HashMap<>();

        for (Dao<Country> dao : countryDaos) {
            for (Country country : dao.getAll()) {
                String officialName = countryNameResolver.getOfficialName(country.getName());
                if (result.containsKey(officialName)) {
                    log.debug("Replacing country {}. Population changed from {} to {}",
                            officialName, result.get(officialName), country.getPopulation());
                }
                result.put(officialName, country.getPopulation());
            }
        }

        return result;
    }
}
