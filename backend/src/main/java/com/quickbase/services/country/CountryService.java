package com.quickbase.services.country;

import com.quickbase.dtos.CountryDto;
import com.quickbase.entities.Country;
import com.quickbase.exceptions.EntityNotFoundResponseStatusException;
import com.quickbase.mappers.CountryMapper;
import com.quickbase.repositories.CountryRepository;
import org.mapstruct.factory.Mappers;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
public class CountryService implements ICountryService {
	private static final CountryMapper mapper = Mappers.getMapper(CountryMapper.class);

	@Autowired
	private CountryRepository countryRepository;

	@Override
	public List<CountryDto> getAllDtos() {
		return getAll().stream().map(mapper::toDto).collect(Collectors.toList());
	}

	public List<Country> getAll() {
		return countryRepository.findAll();
	}

	@Override
	public CountryDto getDtoById(Integer id) {
		return mapper.toDto(getById(id));
	}

	public Country getById(Integer id) {
		return countryRepository.findById(id).orElseThrow(() -> new EntityNotFoundResponseStatusException(Country.class, id));
	}

	@Override
	public CountryDto create(CountryDto countryDto) {
		return mapper.toDto(countryRepository.save(mapper.toEntity(countryDto)));
	}

	@Override
	public CountryDto update(CountryDto countryDto) {
		validateExistingCountry(countryDto.getId());
		return mapper.toDto(countryRepository.save(mapper.toEntity(countryDto)));
	}

	@Override
	public void deleteById(Integer id) {
		validateExistingCountry(id);
		countryRepository.deleteById(id);
	}

	private void validateExistingCountry(Integer id) {
		if (!countryRepository.existsById(id)) {
			throw new EntityNotFoundResponseStatusException(Country.class, id);
		}
	}
}
