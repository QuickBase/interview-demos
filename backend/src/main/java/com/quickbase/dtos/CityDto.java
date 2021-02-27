package com.quickbase.dtos;

import lombok.Data;
import lombok.NoArgsConstructor;

import javax.validation.constraints.NotBlank;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;

@Data
@NoArgsConstructor
public class CityDto {
	@NotNull(message = "City's id must not be null")
	private Integer id;

	@Size(max = 2000, message = "City's name must be maximum 2000 characters")
	@NotBlank(message = "City's name must not be blank")
	private String name;

	@NotNull(message = "City's state must not be null")
	private StateDto state;

	private Integer population;
}
