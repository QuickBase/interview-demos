package com.quickbase;

import com.quickbase.devint.DBManager;
import com.quickbase.devint.DBManagerImpl;
import lombok.extern.slf4j.Slf4j;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

import java.sql.Connection;

@Slf4j
@SpringBootApplication
public class Application {
    public static void main(String[] args) {
        startConnection();
        SpringApplication.run(Application.class, args);
    }

    public static void startConnection() {
        log.info("Starting.");
        log.info("Getting DB Connection...");

        DBManager dbm = new DBManagerImpl();
        Connection c = dbm.getConnection();
        if (null == c ) {
            log.info("failed.");
            System.exit(1);
        }
    }
}
