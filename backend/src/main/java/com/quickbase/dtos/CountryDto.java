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
public class CountryDto {
	@NotNull(message = "Country's id must not be null")
	private Integer id;

	@Size(max = 2000, message = "Country's name must be maximum 2000 characters")
	@NotBlank(message = "Country's name must not be blank")
	private String name;
}
