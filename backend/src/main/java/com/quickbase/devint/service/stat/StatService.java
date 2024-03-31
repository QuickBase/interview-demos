package com.quickbase.devint.service.stat;

import org.apache.commons.lang3.tuple.Pair;

import java.util.List;

public interface StatService {
	List<Pair<String, Integer>> getCountryPopulations();
}
