package com.quickbase.services.country;

import com.quickbase.services.external.IStatService;
import com.quickbase.dtos.CountryDto;
import com.quickbase.entities.Country;
import com.quickbase.exceptions.EntityNotFoundResponseStatusException;
import com.quickbase.mappers.CountryMapper;
import com.quickbase.repositories.CountryRepository;
import org.apache.commons.lang3.tuple.ImmutablePair;
import org.apache.commons.lang3.tuple.Pair;
import org.mapstruct.factory.Mappers;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.Comparator;
import java.util.LinkedList;
import java.util.List;
import java.util.Objects;
import java.util.stream.Collectors;

import static com.quickbase.utils.QuickbaseCollectionUtils.mergeList;

@Service
public class CountryService implements ICountryService {
	private static final CountryMapper mapper = Mappers.getMapper(CountryMapper.class);

	@Autowired
	private IStatService statService;

	@Autowired
	private CountryRepository countryRepository;

	@Override
	public List<CountryDto> getAllDtos() {
		return getAll().stream().map(mapper::toDto).collect(Collectors.toList());
	}

	private List<Country> getAll() {
		return countryRepository.findAll();
	}

	@Override
	public CountryDto getDtoById(Integer id) {
		return mapper.toDto(getById(id));
	}

	private Country getById(Integer id) {
		return countryRepository.findById(id).orElseThrow(() -> new EntityNotFoundResponseStatusException(Country.class, id));
	}

	@Override
	public List<Pair<String, Integer>> getAllCountryNamesAndPopulations() {
		List<Pair<String, Integer>> countryNamesAndPopulationList = new LinkedList<>();
		List<Integer> populationsList = countryRepository.getEachCountryPopulation();
		List<String> countryNamesList = getAll().stream()
				.sorted(Comparator.comparingInt(Country::getId))
				.map(Country::getName)
				.collect(Collectors.toList());

		for (int i = 0; i < countryNamesList.size(); i++) {
			countryNamesAndPopulationList.add(new ImmutablePair<>(countryNamesList.get(i), populationsList.get(i)));
		}

		return countryNamesAndPopulationList;
	}

	@Override
	public List<Pair<String, Integer>> getUpdatedCountryNamesAndPopulations() {
		List<Pair<String, Integer>> dbNamesAndPopulationList = getAllCountryNamesAndPopulations();
		List<Pair<String, Integer>> apiNamesAndPopulationList = statService.getCountryPopulations();

		return mergeList(apiNamesAndPopulationList, dbNamesAndPopulationList,
				(output, input) -> Objects.equals(output.getLeft(), input.getLeft()));
	}

	@Override
	public CountryDto create(CountryDto countryDto) {
		return mapper.toDto(countryRepository.save(mapper.toEntity(countryDto)));
	}

	@Override
	public CountryDto update(CountryDto countryDto) {
		validateExistingCountry(countryDto.getId());
		return mapper.toDto(countryRepository.save(mapper.toEntity(countryDto)));
	}

	@Override
	public void deleteById(Integer id) {
		validateExistingCountry(id);
		countryRepository.deleteById(id);
	}

	private void validateExistingCountry(Integer id) {
		if (!countryRepository.existsById(id)) {
			throw new EntityNotFoundResponseStatusException(Country.class, id);
		}
	}
}
