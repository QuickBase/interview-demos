package com.quickbase.services.state;

import com.quickbase.dtos.StateDto;
import com.quickbase.entities.State;
import com.quickbase.repositories.StateRepository;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;
import org.springframework.web.server.ResponseStatusException;

import java.util.List;
import java.util.Optional;

import static com.quickbase.builders.EntityBuilders.createValidState;
import static com.quickbase.builders.EntityBuilders.createValidStateDto;
import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;
import static org.mockito.Mockito.verify;
import static org.mockito.Mockito.when;

@ExtendWith(MockitoExtension.class)
class StateServiceUnitTests {
	private static final String STATE_NOT_FOUND_MESSAGE =
			"404 NOT_FOUND \"State with id: 2 does not exist in the repository.\"";
	private final State mockState = createValidState();
	private final StateDto mockStateDto = createValidStateDto();

	@Mock
	private StateRepository stateRepository;

	@InjectMocks
	private StateService test;

	@Test
	void test_getAllDtos_Success() {
		when(stateRepository.findAll()).thenReturn(List.of(mockState));
		assertEquals(List.of(mockStateDto), test.getAllDtos());
	}

	@Test
	void test_getDtoById_Success() {
		when(stateRepository.findById(mockState.getId())).thenReturn(Optional.of(mockState));
		assertEquals(mockStateDto, test.getDtoById(mockStateDto.getId()));
	}

	@Test
	void test_getDtoById_NotFoundException() {
		when(stateRepository.findById(mockState.getId())).thenReturn(Optional.empty());
		assertEquals(STATE_NOT_FOUND_MESSAGE, assertThrows(
				ResponseStatusException.class,
				() -> test.getDtoById(mockStateDto.getId())).getMessage()
		);
	}

	@Test
	void test_create_Success() {
		when(stateRepository.save(mockState)).thenReturn(mockState);
		assertEquals(mockStateDto, test.create(mockStateDto));
	}

	@Test
	void test_update_Success() {
		when(stateRepository.existsById(mockState.getId())).thenReturn(true);
		when(stateRepository.save(mockState)).thenReturn(mockState);
		assertEquals(mockStateDto, test.update(mockStateDto));
	}

	@Test
	void test_update_NotFoundException() {
		when(stateRepository.existsById(mockState.getId())).thenReturn(false);
		assertEquals(STATE_NOT_FOUND_MESSAGE, assertThrows(
				ResponseStatusException.class,
				() -> test.update(mockStateDto)).getMessage()
		);
	}

	@Test
	void test_deleteById_Success() {
		when(stateRepository.existsById(mockState.getId())).thenReturn(true);
		test.deleteById(mockStateDto.getId());
		verify(stateRepository).deleteById(mockStateDto.getId());
	}

	@Test
	void test_deleteById_NotFoundException() {
		when(stateRepository.existsById(mockState.getId())).thenReturn(false);
		assertEquals(STATE_NOT_FOUND_MESSAGE, assertThrows(
				ResponseStatusException.class,
				() -> test.deleteById(mockStateDto.getId())).getMessage()
		);
	}
}
