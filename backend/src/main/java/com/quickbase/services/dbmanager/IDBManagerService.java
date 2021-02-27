package com.quickbase.services.dbmanager;

import java.sql.Connection;

/**
 * Created by ckeswani on 9/16/15.
 */
public interface IDBManagerService {
    Connection getConnection();
}
