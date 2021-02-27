package com.quickbase.controllers;

import com.quickbase.dtos.CountryDto;
import com.quickbase.services.country.ICountryService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;

import javax.validation.Valid;
import java.util.List;

@RestController
public class CountryController {
	@Autowired
	private ICountryService countryService;

	@GetMapping("api/countries/get/all")
	public ResponseEntity<List<CountryDto>> getAll() {
		return new ResponseEntity<>(countryService.getAllDtos(), HttpStatus.OK);
	}

	@GetMapping("api/countries/get/{id}")
	public ResponseEntity<CountryDto> getById(@PathVariable("id") Integer id) {
		return new ResponseEntity<>(countryService.getDtoById(id), HttpStatus.OK);
	}

	@PostMapping("api/countries/create")
	public ResponseEntity<CountryDto> create(@RequestBody @Valid CountryDto dto) {
		return new ResponseEntity<>(countryService.create(dto), HttpStatus.OK);
	}

	@PutMapping("api/countries/update")
	public ResponseEntity<CountryDto> update(@RequestBody @Valid CountryDto dto) {
		return new ResponseEntity<>(countryService.update(dto), HttpStatus.OK);
	}

	@DeleteMapping("api/countries/delete/{id}")
	public ResponseEntity<CountryDto> deleteById(@PathVariable("id") Integer id) {
		countryService.deleteById(id);
		return new ResponseEntity<>(HttpStatus.OK);
	}
}
