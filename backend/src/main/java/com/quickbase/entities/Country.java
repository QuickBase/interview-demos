package com.quickbase.entities;

import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.experimental.SuperBuilder;

import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Id;
import javax.persistence.Column;
import javax.validation.constraints.NotNull;

@Entity
@Table(name = "Country")
@Data
@NoArgsConstructor
@SuperBuilder
public class Country {
	@Id
	@Column(name = "CountryId")
	@NotNull
	private Integer id;

	@Column(name = "CountryName")
	@NotNull
	private String name;
}
