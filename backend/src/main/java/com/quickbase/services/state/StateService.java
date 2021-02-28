package com.quickbase.services.state;

import com.quickbase.dtos.StateDto;
import com.quickbase.entities.State;
import com.quickbase.exceptions.EntityNotFoundResponseStatusException;
import com.quickbase.mappers.StateMapper;
import com.quickbase.repositories.StateRepository;
import org.mapstruct.factory.Mappers;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
public class StateService implements IStateService {
	private static final StateMapper mapper = Mappers.getMapper(StateMapper.class);

	@Autowired
	private StateRepository stateRepository;

	@Override
	public List<StateDto> getAllDtos() {
		return getAll().stream().map(mapper::toDto).collect(Collectors.toList());
	}

	private List<State> getAll() {
		return stateRepository.findAll();
	}

	@Override
	public StateDto getDtoById(Integer id) {
		return mapper.toDto(getById(id));
	}

	private State getById(Integer id) {
		return stateRepository.findById(id).orElseThrow(() -> new EntityNotFoundResponseStatusException(State.class, id));
	}

	@Override
	public StateDto create(StateDto stateDto) {
		return mapper.toDto(stateRepository.save(mapper.toEntity(stateDto)));
	}

	@Override
	public StateDto update(StateDto stateDto) {
		validateExistingState(stateDto.getId());
		return mapper.toDto(stateRepository.save(mapper.toEntity(stateDto)));
	}

	@Override
	public void deleteById(Integer id) {
		validateExistingState(id);
		stateRepository.deleteById(id);
	}

	private void validateExistingState(Integer id) {
		if (!stateRepository.existsById(id)) {
			throw new EntityNotFoundResponseStatusException(State.class, id);
		}
	}
}
