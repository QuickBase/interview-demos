package com.quickbase.devint;

import org.apache.commons.lang3.tuple.Pair;
import reactor.core.publisher.Mono;

import java.util.List;

public interface IStatService {
	
	Mono<List<Pair<String, Integer>>> getCountryPopulations();

}
