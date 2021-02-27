package com.quickbase.controllers;

import com.quickbase.dtos.StateDto;
import com.quickbase.services.state.IStateService;
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
public class StateController {
	@Autowired
	private IStateService stateService;

	@GetMapping("api/states/get/all")
	public ResponseEntity<List<StateDto>> getAll() {
		return new ResponseEntity<>(stateService.getAllDtos(), HttpStatus.OK);
	}

	@GetMapping("api/states/get/{id}")
	public ResponseEntity<StateDto> getById(@PathVariable("id") Integer id) {
		return new ResponseEntity<>(stateService.getDtoById(id), HttpStatus.OK);
	}

	@PostMapping("api/states/create")
	public ResponseEntity<StateDto> create(@RequestBody @Valid StateDto dto) {
		return new ResponseEntity<>(stateService.create(dto), HttpStatus.OK);
	}

	@PutMapping("api/states/update")
	public ResponseEntity<StateDto> update(@RequestBody @Valid StateDto dto) {
		return new ResponseEntity<>(stateService.update(dto), HttpStatus.OK);
	}

	@DeleteMapping("api/states/delete/{id}")
	public ResponseEntity<StateDto> deleteById(@PathVariable("id") Integer id) {
		stateService.deleteById(id);
		return new ResponseEntity<>(HttpStatus.OK);
	}
}
