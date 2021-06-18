package com.quickbase.devint;

import lombok.extern.slf4j.Slf4j;
import org.apache.commons.lang3.tuple.Pair;
import reactor.core.publisher.Flux;
import reactor.core.publisher.Mono;

import java.sql.ResultSet;
import java.util.List;
import java.util.function.Consumer;

@Slf4j
public class SQLiteStatService implements IStatService {

    private static final String SELECT_ALL_COUNTRIES_POPULATION =
            "select Country.CountryName, sum(City.Population) as CountryPopulation" +
                    " from City left join State on City.StateId = State.StateId" +
                    " left join Country on Country.CountryId = State.CountryId" +
                    " group by Country.CountryId";

    private final DBManager dbManager;

    public SQLiteStatService(DBManager dbManager) {
        this.dbManager = dbManager;
    }

    @Override
    public Mono<List<Pair<String, Integer>>> getCountryPopulations() {
        return Flux.<Pair<String, Integer>>create(emitter -> {
            final Consumer<ResultSet> emitResultSet = rs -> {
                try {
                    while (rs.next()) {
                        emitter.next(Pair.of(rs.getString(1), rs.getInt(2)));
                    }
                    emitter.complete();
                } catch(Exception ex) {
                    emitter.error(ex);
                }
            };
            dbManager.query(SELECT_ALL_COUNTRIES_POPULATION, emitResultSet, emitter::error);
        }).collectList();
    }
}
