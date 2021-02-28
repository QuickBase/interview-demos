package com.quickbase.services.external;

import java.util.List;
import org.apache.commons.lang3.tuple.Pair;

public interface IStatService {
	List<Pair<String, Integer>> getCountryPopulations();
}
