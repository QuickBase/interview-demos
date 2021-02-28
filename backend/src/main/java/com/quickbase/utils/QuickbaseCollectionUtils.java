package com.quickbase.utils;

import java.util.Collection;
import java.util.List;
import java.util.function.BiPredicate;

public final class QuickbaseCollectionUtils {
	private QuickbaseCollectionUtils() {}

	public static <T> List<T> mergeList(List<T> output, List<T> input, BiPredicate<T, T> mergeRules) {
		mergeCollection(output, input, mergeRules);
		return output;
	}

	public static <T> void mergeCollection(Collection<T> output, Collection<T> input, BiPredicate<T, T> mergeRules) {
		if (input != null && !input.isEmpty()) {
			output.removeIf(outputObject -> input.stream().anyMatch(inputObject -> mergeRules.test(outputObject, inputObject)));
			output.addAll(input);
		}
	}
}
