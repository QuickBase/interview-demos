package com.quickbase.devint;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.function.Consumer;

/**
 * Created by ckeswani on 9/16/15.
 */
public interface DBManager {

    Connection getConnection() throws SQLException;
    void query(String query, Consumer<ResultSet> resultProcessor, Consumer<Throwable> errorProcessor);
}
