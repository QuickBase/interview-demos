package com.quickbase.services.state;

import com.quickbase.dtos.StateDto;

import java.util.List;

public interface IStateService {
	List<StateDto> getAllDtos();
	StateDto getDtoById(Integer id);
	StateDto create(StateDto cityDto);
	StateDto update(StateDto cityDto);
	void deleteById(Integer id);
}
