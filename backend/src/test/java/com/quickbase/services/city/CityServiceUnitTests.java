package com.quickbase.services.city;

import com.quickbase.dtos.CityDto;
import com.quickbase.entities.City;
import com.quickbase.repositories.CityRepository;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;
import org.springframework.web.server.ResponseStatusException;

import java.util.List;
import java.util.Optional;

import static com.quickbase.builders.EntityBuilders.createValidCity;
import static com.quickbase.builders.EntityBuilders.createValidCityDto;
import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;
import static org.mockito.Mockito.verify;
import static org.mockito.Mockito.when;

@ExtendWith(MockitoExtension.class)
class CityServiceUnitTests {
	private static final String CITY_NOT_FOUND_MESSAGE =
			"404 NOT_FOUND \"City with id: 3 does not exist in the repository.\"";
	private final City mockCity = createValidCity();
	private final CityDto mockCityDto = createValidCityDto();
	@Mock
	private CityRepository cityRepository;

	@InjectMocks
	private CityService test;

	@Test
	void test_getAllDtos_Success() {
		when(cityRepository.findAll()).thenReturn(List.of(mockCity));
		assertEquals(List.of(mockCityDto), test.getAllDtos());
	}

	@Test
	void test_getDtoById_Success() {
		when(cityRepository.findById(mockCity.getId())).thenReturn(Optional.of(mockCity));
		assertEquals(mockCityDto, test.getDtoById(mockCityDto.getId()));
	}

	@Test
	void test_getDtoById_NotFoundException() {
		when(cityRepository.findById(mockCity.getId())).thenReturn(Optional.empty());
		assertEquals(CITY_NOT_FOUND_MESSAGE, assertThrows(
				ResponseStatusException.class,
				() -> test.getDtoById(mockCityDto.getId())).getMessage()
		);
	}

	@Test
	void test_create_Success() {
		when(cityRepository.save(mockCity)).thenReturn(mockCity);
		assertEquals(mockCityDto, test.create(mockCityDto));
	}

	@Test
	void test_update_Success() {
		when(cityRepository.existsById(mockCity.getId())).thenReturn(true);
		when(cityRepository.save(mockCity)).thenReturn(mockCity);
		assertEquals(mockCityDto, test.update(mockCityDto));
	}

	@Test
	void test_update_NotFoundException() {
		when(cityRepository.existsById(mockCity.getId())).thenReturn(false);
		assertEquals(CITY_NOT_FOUND_MESSAGE, assertThrows(
				ResponseStatusException.class,
				() -> test.update(mockCityDto)).getMessage()
		);
	}

	@Test
	void test_deleteById_Success() {
		when(cityRepository.existsById(mockCity.getId())).thenReturn(true);
		test.deleteById(mockCityDto.getId());
		verify(cityRepository).deleteById(mockCityDto.getId());
	}

	@Test
	void test_deleteById_NotFoundException() {
		when(cityRepository.existsById(mockCity.getId())).thenReturn(false);
		assertEquals(CITY_NOT_FOUND_MESSAGE, assertThrows(
				ResponseStatusException.class,
				() -> test.deleteById(mockCityDto.getId())).getMessage()
		);
	}
}
