package com.quickbase.mappers;

import com.quickbase.dtos.CityDto;
import com.quickbase.entities.City;
import org.mapstruct.Mapper;

@Mapper
public interface CityMapper {
	City toEntity(CityDto dto);
	CityDto toDto(City entity);
}
