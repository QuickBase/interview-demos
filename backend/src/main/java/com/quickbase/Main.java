package com.quickbase;

import com.quickbase.devint.DBManager;
import com.quickbase.devint.DBManagerImpl;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

import java.sql.Connection;

/**
 * The main method of the executable JAR generated from this repository. This is to let you
 * execute something from the command-line or IDE for the purposes of demonstration, but you can choose
 * to demonstrate in a different way (e.g. if you're using a framework)
 */
@SpringBootApplication
public class Main implements CommandLineRunner {

    public static void main(String[] args) {
        SpringApplication.run(Main.class, args);
    }

    @Override
    public void run(String... args) throws Exception {
        System.out.println("Starting.");
        System.out.print("Getting DB Connection...");

        DBManager dbm = new DBManagerImpl();
        Connection c = dbm.getConnection();
        if (null == c) {
            System.out.println("failed.");
            System.exit(1);
        }
    }
}