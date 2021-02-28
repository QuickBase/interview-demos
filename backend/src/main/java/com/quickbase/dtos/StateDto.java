package com.quickbase.dtos;

import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.experimental.SuperBuilder;

import javax.validation.constraints.NotBlank;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;

@Data
@NoArgsConstructor
@SuperBuilder
public class StateDto {
	@NotNull(message = "State's id must not be null")
	private Integer id;

	@Size(max = 2000, message = "State's name must be maximum 2000 characters")
	@NotBlank(message = "State's name must not be blank")
	private String name;

	@NotNull(message = "State's country must not be null")
	private CountryDto country;
}
