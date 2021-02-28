package com.quickbase.entities;

import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.experimental.SuperBuilder;

import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Id;
import javax.persistence.Column;
import javax.persistence.ManyToOne;
import javax.persistence.JoinColumn;
import javax.validation.constraints.NotNull;

@Entity
@Table(name = "State")
@Data
@NoArgsConstructor
@SuperBuilder
public class State {
	@Id
	@Column(name = "StateId")
	@NotNull
	private Integer id;

	@Column(name = "StateName")
	@NotNull
	private String name;

	@ManyToOne
	@JoinColumn(name = "CountryId")
	@NotNull
	private Country country;
}
