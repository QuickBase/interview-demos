package com.quickbase.devint;

import java.util.ArrayList;
import java.util.List;

import org.apache.commons.lang3.tuple.ImmutablePair;
import org.apache.commons.lang3.tuple.Pair;

public class ConcreteStatService implements IStatService {

	@Override
	/**
	 * Returns an unordered list of countries and their populations
	 */
	public List<Pair<String, Integer>> GetCountryPopulations() {
		List<Pair<String, Integer>> output = new ArrayList<Pair<String, Integer>>();
		
		// Pretend this calls a REST API somewhere
		output.add(new ImmutablePair<String, Integer>("India",1182105000));
		output.add(new ImmutablePair<String, Integer>("United Kingdom",62026962));
		output.add(new ImmutablePair<String, Integer>("Chile",17094270));
		output.add(new ImmutablePair<String, Integer>("Mali",15370000));
		output.add(new ImmutablePair<String, Integer>("Greece",11305118));
		output.add(new ImmutablePair<String, Integer>("Armenia",3249482));
		output.add(new ImmutablePair<String, Integer>("Slovenia",2046976));
		output.add(new ImmutablePair<String, Integer>("Saint Vincent and the Grenadines",109284));
		output.add(new ImmutablePair<String, Integer>("Bhutan",695822));
		output.add(new ImmutablePair<String, Integer>("Aruba (Netherlands)",101484));
		output.add(new ImmutablePair<String, Integer>("Maldives",319738));
		output.add(new ImmutablePair<String, Integer>("Mayotte (France)",202000));
		output.add(new ImmutablePair<String, Integer>("Vietnam",86932500));
		output.add(new ImmutablePair<String, Integer>("Germany",81802257));
		output.add(new ImmutablePair<String, Integer>("Botswana",2029307));
		output.add(new ImmutablePair<String, Integer>("Togo",6191155));
		output.add(new ImmutablePair<String, Integer>("Luxembourg",502066));
		output.add(new ImmutablePair<String, Integer>("U.S. Virgin Islands (US)",106267));
		output.add(new ImmutablePair<String, Integer>("Belarus",9480178));
		output.add(new ImmutablePair<String, Integer>("Myanmar",59780000));
		output.add(new ImmutablePair<String, Integer>("Mauritania",3217383));
		output.add(new ImmutablePair<String, Integer>("Malaysia",28334135));
		output.add(new ImmutablePair<String, Integer>("Dominican Republic",9884371));
		output.add(new ImmutablePair<String, Integer>("New Caledonia (France)",248000));
		output.add(new ImmutablePair<String, Integer>("Slovakia",5424925));
		output.add(new ImmutablePair<String, Integer>("Kyrgyzstan",5418300));
		output.add(new ImmutablePair<String, Integer>("Lithuania",3329039));
		output.add(new ImmutablePair<String, Integer>("United States of America",309349689));
		return output;
	}

}
