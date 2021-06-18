package com.quickbase;

import com.google.common.collect.ImmutableList;
import com.quickbase.devint.ConcreteStatService;
import com.quickbase.devint.DBManager;
import com.quickbase.devint.DBManagerImpl;
import com.quickbase.devint.MultiSourceStatService;
import com.quickbase.devint.SQLiteStatService;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import java.io.File;
import java.sql.SQLException;

@Configuration
public class MainConfig {

    @Bean(name = "dbFile")
    File dbFile(@Value("${db.path}") String dbPath) {
        final var db = new File(dbPath);
        if (!db.exists()) {
            throw new IllegalStateException("Database file does not exist");
        } else {
            return db;
        }
    }

    @Bean
    ConcreteStatService concreteStatService() {
        return new ConcreteStatService();
    }

    @Bean
    SQLiteStatService sqLiteStatService(DBManager dbManager) {
        return new SQLiteStatService(dbManager);
    }

    @Bean
    MultiSourceStatService mergingStatService(SQLiteStatService sqLiteStatService, ConcreteStatService concreteStatService) {
        return new MultiSourceStatService(ImmutableList.of(sqLiteStatService, concreteStatService));
    }

    @Bean
    DBManager dbManager(@Qualifier("dbFile") File dbFile) throws ClassNotFoundException, SQLException {
        final var url = "jdbc:sqlite:" + dbFile.getAbsolutePath();
        return new DBManagerImpl(url);
    }
}
