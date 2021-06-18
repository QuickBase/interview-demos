package com.quickbase.devint;

import lombok.Value;
import lombok.extern.slf4j.Slf4j;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.function.Consumer;

/**
 * This DBManager implementation provides a connection to the database containing population data.
 *
 * Created by ckeswani on 9/16/15.
 */
@Slf4j
@Value
public class DBManagerImpl implements DBManager {

    String url;

    public DBManagerImpl(String url) throws SQLException, ClassNotFoundException {
        this.url = url;
        Class.forName("org.sqlite.JDBC");
        try (var c = getConnection()) {
            log.info("Opened database successfully");
        }
    }

    @Override
    public Connection getConnection() throws SQLException {
        return DriverManager.getConnection(url);
    }

    @Override
    public void query(String query, Consumer<ResultSet> resultProcessor, Consumer<Throwable> errorProcessor) {
        try(var c = getConnection();
            var st = c.prepareStatement(query);
            var rs = st.executeQuery()) {
            resultProcessor.accept(rs);
        } catch (Throwable ex) {
            errorProcessor.accept(ex);
        }
    }
}
