package com.quickbase.services.country;

import com.quickbase.dtos.CountryDto;
import com.quickbase.entities.Country;
import com.quickbase.repositories.CountryRepository;
import com.quickbase.services.external.StatService;
import org.apache.commons.lang3.tuple.ImmutablePair;
import org.apache.commons.lang3.tuple.Pair;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;
import org.springframework.web.server.ResponseStatusException;

import java.util.*;

import static com.quickbase.builders.EntityBuilders.createValidCountry;
import static com.quickbase.builders.EntityBuilders.createValidCountryDto;
import static com.quickbase.builders.EntityBuilders.COUNTRY_NAME;
import static com.quickbase.builders.EntityBuilders.CITY_POPULATION;
import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;
import static org.mockito.Mockito.verify;
import static org.mockito.Mockito.when;

@ExtendWith(MockitoExtension.class)
class CountryServiceUnitTests {
	private static final String COUNTRY_NOT_FOUND_MESSAGE =
			"404 NOT_FOUND \"Country with id: 1 does not exist in the repository.\"";
	private final Country mockCountry = createValidCountry();
	private final CountryDto mockCountryDto = createValidCountryDto();

	@Mock
	private StatService statService;

	@Mock
	private CountryRepository countryRepository;

	@InjectMocks
	private CountryService test;

	@Test
	void test_getAllDtos_Success() {
		when(countryRepository.findAll()).thenReturn(List.of(mockCountry));
		assertEquals(List.of(mockCountryDto), test.getAllDtos());
	}

	@Test
	void test_getDtoById_Success() {
		when(countryRepository.findById(mockCountry.getId())).thenReturn(Optional.of(mockCountry));
		assertEquals(mockCountryDto, test.getDtoById(mockCountryDto.getId()));
	}

	@Test
	void test_getDtoById_NotFoundException() {
		when(countryRepository.findById(mockCountry.getId())).thenReturn(Optional.empty());
		assertEquals(COUNTRY_NOT_FOUND_MESSAGE, assertThrows(
				ResponseStatusException.class,
				() -> test.getDtoById(mockCountryDto.getId())).getMessage()
		);
	}

	@Test
	void test_getAllCountryNamesAndPopulations_Success() {
		when(countryRepository.getEachCountryPopulation()).thenReturn(List.of(CITY_POPULATION));
		when(countryRepository.findAll()).thenReturn(List.of(mockCountry));

		List<Pair<String, Integer>> result = test.getAllCountryNamesAndPopulations();

		assertEquals(COUNTRY_NAME, result.get(0).getLeft());
		assertEquals(CITY_POPULATION, result.get(0).getRight());
	}

	@Test
	void test_getUpdatedCountryNamesAndPopulations_Success() {
		when(countryRepository.getEachCountryPopulation()).thenReturn(List.of(CITY_POPULATION));
		when(countryRepository.findAll()).thenReturn(List.of(mockCountry));
		when(statService.getCountryPopulations())
				.thenReturn(new ArrayList<>(List.of(new ImmutablePair<>(COUNTRY_NAME, 1))));

		List<Pair<String, Integer>> result = test.getUpdatedCountryNamesAndPopulations();

		assertEquals(COUNTRY_NAME, result.get(0).getLeft());
		assertEquals(CITY_POPULATION, result.get(0).getRight());
	}

	@Test
	void test_create_Success() {
		when(countryRepository.save(mockCountry)).thenReturn(mockCountry);
		assertEquals(mockCountryDto, test.create(mockCountryDto));
	}

	@Test
	void test_update_Success() {
		when(countryRepository.existsById(mockCountry.getId())).thenReturn(true);
		when(countryRepository.save(mockCountry)).thenReturn(mockCountry);
		assertEquals(mockCountryDto, test.update(mockCountryDto));
	}

	@Test
	void test_update_NotFoundException() {
		when(countryRepository.existsById(mockCountry.getId())).thenReturn(false);
		assertEquals(COUNTRY_NOT_FOUND_MESSAGE, assertThrows(
				ResponseStatusException.class,
				() -> test.update(mockCountryDto)).getMessage()
		);
	}

	@Test
	void test_deleteById_Success() {
		when(countryRepository.existsById(mockCountry.getId())).thenReturn(true);
		test.deleteById(mockCountryDto.getId());
		verify(countryRepository).deleteById(mockCountryDto.getId());
	}

	@Test
	void test_deleteById_NotFoundException() {
		when(countryRepository.existsById(mockCountry.getId())).thenReturn(false);
		assertEquals(COUNTRY_NOT_FOUND_MESSAGE, assertThrows(
				ResponseStatusException.class,
				() -> test.deleteById(mockCountryDto.getId())).getMessage()
		);
	}
}
