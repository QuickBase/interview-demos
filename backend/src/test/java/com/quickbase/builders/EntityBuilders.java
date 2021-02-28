package com.quickbase.builders;

import com.quickbase.dtos.CityDto;
import com.quickbase.dtos.CountryDto;
import com.quickbase.dtos.StateDto;
import com.quickbase.entities.City;
import com.quickbase.entities.Country;
import com.quickbase.entities.State;

public final class EntityBuilders {
	public static final Integer COUNTRY_ID = 1;
	public static final Integer STATE_ID = 2;
	public static final Integer CITY_ID = 3;
	public static final Integer CITY_POPULATION = 10000;
	public static final String COUNTRY_NAME = "COUNTRY_NAME";
	public static final String STATE_NAME = "STATE_NAME";
	public static final String CITY_NAME = "CITY_NAME";

	public static Country createValidCountry() {
		return Country.builder()
				.id(COUNTRY_ID)
				.name(COUNTRY_NAME)
				.build();
	}

	public static CountryDto createValidCountryDto() {
		return CountryDto.builder()
				.id(COUNTRY_ID)
				.name(COUNTRY_NAME)
				.build();
	}

	public static State createValidState() {
		return State.builder()
				.id(STATE_ID)
				.name(STATE_NAME)
				.country(createValidCountry())
				.build();
	}

	public static StateDto createValidStateDto() {
		return StateDto.builder()
				.id(STATE_ID)
				.name(STATE_NAME)
				.country(createValidCountryDto())
				.build();
	}

	public static City createValidCity() {
		return City.builder()
				.id(CITY_ID)
				.name(CITY_NAME)
				.state(createValidState())
				.population(CITY_POPULATION)
				.build();
	}

	public static CityDto createValidCityDto() {
		return CityDto.builder()
				.id(CITY_ID)
				.name(CITY_NAME)
				.state(createValidStateDto())
				.population(CITY_POPULATION)
				.build();
	}
}
