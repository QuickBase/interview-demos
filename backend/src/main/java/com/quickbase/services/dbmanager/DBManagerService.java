package com.quickbase.services.dbmanager;

import lombok.extern.slf4j.Slf4j;

import java.sql.*;
import java.util.Arrays;

/**
 * This DBManager implementation provides a connection to the database containing population data.
 * <p>
 * Created by ckeswani on 9/16/15.
 */
@Slf4j
public class DBManagerService implements IDBManagerService {
	public Connection getConnection() {
		log.info("Getting DB Connection");
		Connection connection = null;

		try {
			Class.forName("org.sqlite.JDBC");
			connection = DriverManager.getConnection("jdbc:sqlite:resources/data/citystatecountry.db");
			log.info("Connected to the database successfully");
		} catch (ClassNotFoundException cnf) {
			log.info("Could not load driver");
		} catch (SQLException sqle) {
			log.info("SQL exception:" + Arrays.toString(sqle.getStackTrace()));
		}

		return connection;
	}

	//TODO: Add a method (signature of your choosing) to query the db for population data by country
	public void x() throws SQLException {
		Connection connection = getConnection();
		if (null == connection) {
			log.info("Failed to connect to database");
			//            System.exit(1);
			return;
		}

		//        Statement stmt = connection.createStatement(
		//                ResultSet.TYPE_SCROLL_INSENSITIVE,
		//                ResultSet.CONCUR_UPDATABLE);
		//        ResultSet rs = stmt.executeQuery("SELECT a, b FROM TABLE2");
		//        Array a = rs.getArray(1);

		String query = "select COF_NAME, SUP_ID, PRICE, SALES, TOTAL from COFFEES";
		Statement statement = connection.createStatement();
		ResultSet rs = statement.executeQuery(query);
		while (rs.next()) {
			String coffeeName = rs.getString("COF_NAME");
			int supplierID = rs.getInt("SUP_ID");
			float price = rs.getFloat("PRICE");
			int sales = rs.getInt("SALES");
			int total = rs.getInt("TOTAL");
			log.debug(coffeeName + ", " + supplierID + ", " + price + ", " + sales + ", " + total);
		}
	}

}
