package com.quickbase.devint;

import java.sql.ResultSet;
import java.util.function.Consumer;

/**
 * Created by ckeswani on 9/16/15.
 */
public interface DBManager {
    void query(String query, Consumer<ResultSet> resultProcessor, Consumer<Throwable> errorProcessor);
}
