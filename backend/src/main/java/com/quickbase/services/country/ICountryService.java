package com.quickbase.services.country;

import com.quickbase.dtos.CountryDto;

import java.util.List;

public interface ICountryService {
	List<CountryDto> getAllDtos();
	CountryDto getDtoById(Integer id);
	CountryDto create(CountryDto cityDto);
	CountryDto update(CountryDto cityDto);
	void deleteById(Integer id);
}
