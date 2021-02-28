package com.quickbase.repositories;

import com.quickbase.entities.Country;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface CountryRepository  extends JpaRepository<Country, Integer> {
	@Query(nativeQuery = true, value =
			"SELECT SUM(city.Population) FROM Country "
			+ "INNER JOIN State state ON Country.CountryId = state.CountryId "
			+ "INNER JOIN City city ON state.StateId = city.StateId "
			+ "GROUP BY Country.CountryId "
			+ "ORDER BY Country.CountryId")
	List<Integer> getEachCountryPopulation();
}
