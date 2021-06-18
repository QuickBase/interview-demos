package com.quickbase.devint;

import java.util.ArrayList;
import java.util.List;

import lombok.extern.slf4j.Slf4j;
import org.apache.commons.lang3.tuple.ImmutablePair;
import org.apache.commons.lang3.tuple.Pair;
import reactor.core.publisher.Mono;

@Slf4j
public class ConcreteStatService implements IStatService {

	/**
	 * Returns an unordered list of countries and their populations
	 */
	@Override
	public Mono<List<Pair<String, Integer>>> getCountryPopulations() {
		final var output = new ArrayList<Pair<String, Integer>>();
		
		// Pretend this calls a REST API somewhere
		output.add(new ImmutablePair<>("India", 1182105000));
		output.add(new ImmutablePair<>("United Kingdom",62026962));
		output.add(new ImmutablePair<>("Chile",17094270));
		output.add(new ImmutablePair<>("Mali",15370000));
		output.add(new ImmutablePair<>("Greece",11305118));
		output.add(new ImmutablePair<>("Armenia",3249482));
		output.add(new ImmutablePair<>("Slovenia",2046976));
		output.add(new ImmutablePair<>("Saint Vincent and the Grenadines",109284));
		output.add(new ImmutablePair<>("Bhutan",695822));
		output.add(new ImmutablePair<>("Aruba (Netherlands)",101484));
		output.add(new ImmutablePair<>("Maldives",319738));
		output.add(new ImmutablePair<>("Mayotte (France)",202000));
		output.add(new ImmutablePair<>("Vietnam",86932500));
		output.add(new ImmutablePair<>("Germany",81802257));
		output.add(new ImmutablePair<>("Botswana",2029307));
		output.add(new ImmutablePair<>("Togo",6191155));
		output.add(new ImmutablePair<>("Luxembourg",502066));
		output.add(new ImmutablePair<>("U.S. Virgin Islands (US)",106267));
		output.add(new ImmutablePair<>("Belarus",9480178));
		output.add(new ImmutablePair<>("Myanmar",59780000));
		output.add(new ImmutablePair<>("Mauritania",3217383));
		output.add(new ImmutablePair<>("Malaysia",28334135));
		output.add(new ImmutablePair<>("Dominican Republic",9884371));
		output.add(new ImmutablePair<>("New Caledonia (France)",248000));
		output.add(new ImmutablePair<>("Slovakia",5424925));
		output.add(new ImmutablePair<>("Kyrgyzstan",5418300));
		output.add(new ImmutablePair<>("Lithuania",3329039));
		output.add(new ImmutablePair<>("United States of America",309349689));

		return Mono.just(output);
	}

}
