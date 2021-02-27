package com.quickbase.services.city;

import com.quickbase.dtos.CityDto;

import java.util.List;

public interface ICityService {
	List<CityDto> getAllDtos();
	CityDto getDtoById(Integer id);
	CityDto create(CityDto cityDto);
	CityDto update(CityDto cityDto);
	void deleteById(Integer id);
}
