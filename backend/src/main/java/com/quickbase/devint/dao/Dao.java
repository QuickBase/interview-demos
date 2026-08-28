package com.quickbase.devint.dao;

import java.util.List;

public interface Dao<T> {
    List<T> getAll();
}
