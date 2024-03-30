package com.quickbase.devint.service.stat;

import java.util.List;
import org.apache.commons.lang3.tuple.Pair;

public interface StatService {
	
	List<Pair<String, Integer>> getCountryPopulations();

}
