package com.quickbase.mappers;

import com.quickbase.dtos.CountryDto;
import com.quickbase.entities.Country;
import org.mapstruct.Mapper;

@Mapper
public interface CountryMapper {
	Country toEntity(CountryDto dto);
	CountryDto toDto(Country entity);
}
