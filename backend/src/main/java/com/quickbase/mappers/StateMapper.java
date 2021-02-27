package com.quickbase.mappers;

import com.quickbase.dtos.StateDto;
import com.quickbase.entities.State;
import org.mapstruct.Mapper;

@Mapper
public interface StateMapper {
	State toEntity(StateDto dto);
	StateDto toDto(State entity);
}
