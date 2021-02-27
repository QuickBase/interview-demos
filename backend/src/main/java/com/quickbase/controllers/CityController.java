package com.quickbase.controllers;

import com.quickbase.entities.City;
import com.quickbase.services.city.ICityService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
public class CityController {
	@Autowired
	private ICityService cityService;

	@GetMapping("api/cities")
	public ResponseEntity<List<City>> getAll() {
		return new ResponseEntity<>(cityService.getAllDtos(), HttpStatus.OK);
	}
}
