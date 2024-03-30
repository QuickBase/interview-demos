package com.quickbase.devint.dao;

import com.quickbase.devint.entity.Country;
import com.quickbase.devint.service.stat.StatService;
import org.apache.commons.lang3.tuple.ImmutablePair;
import org.apache.commons.lang3.tuple.Pair;

import java.util.ArrayList;
import java.util.List;

public class CountryStatDao implements Dao<Country> {
    private final StatService statService;

    public CountryStatDao(StatService statService) {
        this.statService = statService;
    }

    @Override
    public List<Country> getAll() {
        List<Country> result = new ArrayList<>();
        List<Pair<String, Integer>> list = statService.getCountryPopulations();

        list.forEach(pair -> result.add(Country.of(pair.getKey(), pair.getValue())));

        return result;
    }
}
