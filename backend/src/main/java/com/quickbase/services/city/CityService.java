package com.quickbase.services.city;

import com.quickbase.dtos.CityDto;
import com.quickbase.entities.City;
import com.quickbase.exceptions.EntityNotFoundResponseStatusException;
import com.quickbase.mappers.CityMapper;
import com.quickbase.repositories.CityRepository;
import org.mapstruct.factory.Mappers;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
public class CityService implements ICityService {
	private static final CityMapper mapper = Mappers.getMapper(CityMapper.class);

	@Autowired
	private CityRepository cityRepository;

	@Override
	public List<CityDto> getAllDtos() {
		return getAll().stream().map(mapper::toDto).collect(Collectors.toList());
	}

	public List<City> getAll() {
		return cityRepository.findAll();
	}

	@Override
	public CityDto getDtoById(Integer id) {
		return mapper.toDto(getById(id));
	}

	public City getById(Integer id) {
		return cityRepository.findById(id).orElseThrow(() -> new EntityNotFoundResponseStatusException(City.class, id));
	}

	@Override
	public CityDto create(CityDto cityDto) {
		return mapper.toDto(cityRepository.save(mapper.toEntity(cityDto)));
	}

	@Override
	public CityDto update(CityDto cityDto) {
		validateExistingCity(cityDto.getId());
		return mapper.toDto(cityRepository.save(mapper.toEntity(cityDto)));
	}

	@Override
	public void deleteById(Integer id) {
		validateExistingCity(id);
		cityRepository.deleteById(id);
	}

	private void validateExistingCity(Integer id) {
		if (!cityRepository.existsById(id)) {
			throw new EntityNotFoundResponseStatusException(City.class, id);
		}
	}
}
