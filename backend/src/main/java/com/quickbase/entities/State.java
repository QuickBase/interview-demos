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
@Table(name = "State")
@Data
@NoArgsConstructor
public class State {
	@Id
	//	@SequenceGenerator(name="hibernateSequence", sequenceName="hibernate_sequence", allocationSize = 1)
	//	@GeneratedValue(strategy= GenerationType.SEQUENCE, generator="hibernateSequence")
	private Integer StateId;

	@NotNull
	private String StateName;

	@ManyToOne
	@JoinColumn(name = "CountryId")
	@NotNull
	private Country CountryId;
}
