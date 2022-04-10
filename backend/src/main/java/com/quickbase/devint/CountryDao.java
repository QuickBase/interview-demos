package main.java.com.quickbase.devint;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

import org.apache.commons.lang3.tuple.Pair;
import org.apache.commons.lang3.tuple.ImmutablePair;

/**
 * This CountryDao implementation provides methods
 *
 * Created by Zidi Xia on 04/09/2022
 */
public class CountryDao {
	private DBManager dbm;
	
	// Single pattern: instantiation is limited to one object.
	// This is avoid open multiple connections to DB for the same purpose.
	private static CountryDao instance = null;
	private CountryDao() {
		this.dbm = new DBManagerImpl();
	}
	
	public static CountryDao getInstance() {
		if(instance == null) {
			instance = new CountryDao();
		}
		
		return instance;
	}
	
    // GetCountryPopulations Add a method to query the db for population data by country
	public List<Pair<String, Integer>> GetCountryPopulations() throws SQLException{
		List<Pair<String, Integer>> output = new ArrayList<Pair<String, Integer>>();

		// This query will join Country, State and City table and generate a table
		// with 2 columns: CountryName and Population
		String query = "SELECT CountryName, SUM(Population) as Population\n"
				+ "FROM\n"
				+ "(SELECT Country.CountryName, City.Population, Country.CountryId\n"
				+ "FROM Country\n"
				+ "JOIN State ON State.CountryId=Country.CountryId\n"
				+ "JOIN City ON City.StateId=State.StateId)\n"
				+ "GROUP BY CountryId";
		Connection connection = null;
		ResultSet results = null;
		try {
			connection = this.dbm.getConnection();
			Statement statement = connection.createStatement();
			results = statement.executeQuery(query);
			while(results.next()) {
				String countryName = results.getString("CountryName");
				int population = results.getInt("Population");
				output.add(new ImmutablePair<String, Integer>(countryName,population));
			}
		} catch (SQLException e) {
			e.printStackTrace();
			throw e;
		} finally {
			if(connection != null) {
				System.out.println("Close DB Connection...");
				connection.close();
			}
			if(results != null) {
				results.close();
			}
		}
		
		return output;
	}
}
