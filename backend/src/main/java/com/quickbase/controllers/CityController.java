package com.quickbase.controllers;

import com.quickbase.dtos.CityDto;
import com.quickbase.services.city.ICityService;
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
public class CityController {
	@Autowired
	private ICityService cityService;

	@GetMapping("api/cities/get/all")
	public ResponseEntity<List<CityDto>> getAll() {
		return new ResponseEntity<>(cityService.getAllDtos(), HttpStatus.OK);
	}

	@GetMapping("api/cities/get/{id}")
	public ResponseEntity<CityDto> getById(@PathVariable("id") Integer id) {
		return new ResponseEntity<>(cityService.getDtoById(id), HttpStatus.OK);
	}

	@PostMapping("api/cities/create")
	public ResponseEntity<CityDto> create(@RequestBody @Valid CityDto dto) {
		return new ResponseEntity<>(cityService.create(dto), HttpStatus.OK);
	}

	@PutMapping("api/cities/update")
	public ResponseEntity<CityDto> update(@RequestBody @Valid CityDto dto) {
		return new ResponseEntity<>(cityService.update(dto), HttpStatus.OK);
	}

	@DeleteMapping("api/cities/delete/{id}")
	public ResponseEntity<CityDto> deleteById(@PathVariable("id") Integer id) {
		cityService.deleteById(id);
		return new ResponseEntity<>(HttpStatus.OK);
	}
}
