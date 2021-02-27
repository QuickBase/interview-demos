package com.quickbase.entities;

import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Id;
import javax.persistence.ManyToOne;
import javax.persistence.JoinColumn;
import javax.validation.constraints.NotNull;

@Entity
@Table(name = "City")
@Data
@NoArgsConstructor
public class City {
	@Id
//	@SequenceGenerator(name="hibernateSequence", sequenceName="hibernate_sequence", allocationSize = 1)
//	@GeneratedValue(strategy= GenerationType.SEQUENCE, generator="hibernateSequence")
	private Integer CityId;

	@NotNull
	private String CityName;

	@ManyToOne
	@JoinColumn(name = "StateId")
	@NotNull
	private State StateId;

	private Integer Population;
}
