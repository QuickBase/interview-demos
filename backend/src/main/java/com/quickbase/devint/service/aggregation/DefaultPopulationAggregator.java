package com.quickbase.devint.service.aggregation;

import com.quickbase.devint.dao.Dao;
import com.quickbase.devint.entity.Country;
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

    public DefaultPopulationAggregator(List<Dao<Country>> countryDaos) {
        this.countryDaos = countryDaos;
    }

    /**
     * This implementation has a potential problem:
     * Country names are returned as provided by the data source. When a country exists under different names,
     * e.g. U.S.A. and United States of America, we would return both entries.
     * TODO: Consider the following improvements:
     *  1. Return a well-known set of names, e.g. ISO 3166 country codes.
     *  2. Process the names from each data source and handle discrepancies.
     */
    @Override
    public Map<String, Integer> getPopulationData() {
        Map<String, Integer> result = new HashMap<>();

        for (Dao<Country> dao : countryDaos) {
            for (Country country : dao.getAll()) {
                // We overwrite countries already inserted by previous DAOs. This is desired behaviour.
                if (result.containsKey(country.getName())) {
                    log.debug("Replacing country {}. Population changed from {} to {}",
                            country.getName(), result.get(country.getName()), country.getPopulation());
                }
                result.put(country.getName(), country.getPopulation());
            }
        }

        return result;
    }
}
