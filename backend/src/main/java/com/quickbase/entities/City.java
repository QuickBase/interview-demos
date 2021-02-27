package com.quickbase.entities;

import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Id;
import javax.persistence.Column;
import javax.persistence.ManyToOne;
import javax.persistence.JoinColumn;
import javax.validation.constraints.NotNull;

@Entity
@Table(name = "City")
@Data
@NoArgsConstructor
public class City {
	@Id
	@Column(name = "CityId")
	@NotNull
	private Integer id;

	@Column(name = "CityName")
	@NotNull
	private String name;

	@ManyToOne
	@JoinColumn(name = "StateId")
	@NotNull
	private State state;

	@Column(name = "Population")
	private Integer population;
}
