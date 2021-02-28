package com.quickbase.services.country;

import com.quickbase.dtos.CountryDto;
import org.apache.commons.lang3.tuple.Pair;

import java.util.List;

public interface ICountryService {
	List<CountryDto> getAllDtos();
	CountryDto getDtoById(Integer id);
	List<Pair<String, Integer>> getAllCountryNamesAndPopulations();
	List<Pair<String, Integer>> getUpdatedCountryNamesAndPopulations();
	CountryDto create(CountryDto cityDto);
	CountryDto update(CountryDto cityDto);
	void deleteById(Integer id);
}
