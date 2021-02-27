package com.quickbase.entities;

import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Id;
import javax.validation.constraints.NotNull;

@Entity
@Table(name = "Country")
@Data
@NoArgsConstructor
public class Country {
	@Id
	//	@SequenceGenerator(name="hibernateSequence", sequenceName="hibernate_sequence", allocationSize = 1)
	//	@GeneratedValue(strategy= GenerationType.SEQUENCE, generator="hibernateSequence")
	private Integer CountryId;

	@NotNull
	private String CountryName;
}
