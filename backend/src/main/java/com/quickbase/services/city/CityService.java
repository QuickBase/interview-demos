package com.quickbase.services.city;

import com.quickbase.entities.City;
import com.quickbase.repositories.CityRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class CityService implements ICityService {
	@Autowired
	private CityRepository cityRepository;

	@Override
	public List<City> getAllDtos() {
		return cityRepository.findAll();
	}
}
