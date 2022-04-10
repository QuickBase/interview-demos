package main.java.com.quickbase.devint;

import java.sql.Connection;
import java.sql.SQLException;

/**
 * Created by ckeswani on 9/16/15.
 */
public interface DBManager {
    public Connection getConnection();
}
