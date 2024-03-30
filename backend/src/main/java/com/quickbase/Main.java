package com.quickbase;


import com.quickbase.devint.dao.CountryDb;
import com.quickbase.devint.dao.Dao;
import com.quickbase.devint.entity.Country;
import lombok.extern.slf4j.Slf4j;


import java.sql.Connection;

/**
 * The main method of the executable JAR generated from this repository. This is to let you
 * execute something from the command-line or IDE for the purposes of demonstration, but you can choose
 * to demonstrate in a different way (e.g. if you're using a framework)
 */
@Slf4j
public class Main {
    public static void main( String args[] ) {
        log.info("Starting.");

        Dao<Country> countryDao = new CountryDb("jdbc:sqlite:resources/data/citystatecountry.db");
        log.debug("Countries in db: {}", countryDao.getAll());

    }
}