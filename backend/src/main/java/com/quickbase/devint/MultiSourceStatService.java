package com.quickbase.devint;

import com.google.common.collect.ImmutableList;
import org.apache.commons.lang3.tuple.Pair;
import org.reactivestreams.Publisher;
import reactor.core.publisher.Flux;
import reactor.core.publisher.Mono;

import java.util.Collection;
import java.util.HashSet;
import java.util.List;
import java.util.stream.Collectors;

/**
 * The {@link MultiSourceStatService} is an implementation of {@link IStatService}
 * that merges the results of multiple {@link IStatService} sources.
 * <p>
 * Given a sequence of sources all sources are queried, and the order sequence of the sources is treated as 'precedence'.
 * Data from sources earlier into the sequence takes precedence over data from sources further back.
 * <p>
 * In the case of duplicates the data from source which is first in the sequence ordering
 * will take precedence and be kept in the final result and the data which is further back into the sequence will be discarded.
 *
 * Eny error during the querying of the sources will result in an error for the whole operation.
 */
public class MultiSourceStatService implements IStatService {

    private final List<IStatService> sources;

    public MultiSourceStatService(Iterable<IStatService> sources) {
        this.sources = ImmutableList.copyOf(sources);
    }

    @Override
    public Mono<List<Pair<String, Integer>>> getCountryPopulations() {
        return Flux.fromIterable(sources)
                .index()
                .flatMap(src -> orderedSourcePopulation(src.getT1(), src.getT2()))
                .sort((p1, p2) -> (int) (p1.getKey() - p2.getKey()))
                .map(Pair::getValue)
                .collectList()
                .map(populations -> {
                    final var alreadyAdded = new HashSet<>();
                    return populations.stream()
                            .flatMap(Collection::stream)
                            .filter(p ->  alreadyAdded.add(p.getKey()))
                            .collect(Collectors.toList());
                });
    }

    private Publisher<Pair<Long, List<Pair<String, Integer>>>> orderedSourcePopulation(long order, IStatService source) {
        return source.getCountryPopulations().map(populations -> Pair.of(order, populations));
    }
}
