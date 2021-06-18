package com.quickbase;

import com.google.common.collect.ImmutableList;
import com.quickbase.devint.IStatService;
import com.quickbase.devint.MultiSourceStatService;
import lombok.Value;
import org.apache.commons.lang3.tuple.Pair;
import org.junit.jupiter.api.Test;
import org.mockito.Mockito;
import reactor.core.publisher.Mono;
import reactor.core.scheduler.Schedulers;
import reactor.test.StepVerifier;

import java.time.Duration;
import java.util.List;

import static java.util.stream.Collectors.toList;

public class MultiSourceStatServiceTest {

    @Test
    void ensureEmptyDataSourcesResultInEmptyList() {
        final var service = multiSourceStatService(noDataStatService(), noDataStatService());

        StepVerifier.create(service.getCountryPopulations())
                .as("Empty sources should result in an empty list")
                .expectNextMatches(List::isEmpty)
                .expectComplete()
                .verify();
    }

    @Test
    void ensureCountriesFromDifferentSourcesAreMergedInTheFinalResult() {
        final var service = multiSourceStatService(
                listStatService(Pair.of("A", 1), Pair.of("B", 1)),
                listStatService(Pair.of("C", 1))
        );
        StepVerifier.create(service.getCountryPopulations())
                .as("Data from multiple sources should be merged in the final result")
                .expectNextMatches(l -> l.stream().map(Pair::getKey).collect(toList()).containsAll(ImmutableList.of("A", "B", "C")))
                .expectComplete()
                .verify();
    }

    @Test
    void ensureDataSourceOrderIsMaintainedAsDataPrecedence() {
        final var s1 = listStatService(Pair.of("A", 1), Pair.of("B", 1));
        final var s2 = listStatService(Pair.of("A", 2));

        final var service = multiSourceStatService(s1, s2);
        StepVerifier.create(service.getCountryPopulations())
                .as("Expect first service data in final result")
                .expectNextMatches(l -> l.stream().anyMatch(p -> "A".equals(p.getKey()) && 1 == p.getValue()))
                .expectComplete()
                .verify();

        final var inversePrecedence = multiSourceStatService(s2, s1);
        StepVerifier.create(inversePrecedence.getCountryPopulations())
                .as("Expect first service data in final result")
                .expectNextMatches(l -> l.stream().anyMatch(p -> "A".equals(p.getKey()) && 2 == p.getValue()))
                .expectComplete()
                .verify();
    }

    @Test
    void ensurePrecedenceIsMaintainedRegardlessOfResponseDelay() {
        final var s1 = new DelayedStatService(Duration.ofSeconds(2), listStatService(Pair.of("A", 1), Pair.of("B", 1)));
        final var s2 = listStatService(Pair.of("A", 2));
        final var service = multiSourceStatService(s1, s2);
        StepVerifier.create(service.getCountryPopulations().subscribeOn(Schedulers.parallel()))
                .as("Expect first service data in the final result, regardless of delay")
                .expectNextMatches(l -> l.stream().anyMatch(p -> "A".equals(p.getKey()) && 1 == p.getValue()))
                .expectComplete()
                .verify();
    }

    @Test
    void ensureErrorInAnyDataSourceIsPropagated() {
        final var s1 = listStatService(Pair.of("A", 1));
        final var s2 = Mockito.mock(IStatService.class);
        Mockito.when(s2.getCountryPopulations()).thenReturn(Mono.error(new RuntimeException("Simulated")));
        final var service = multiSourceStatService(s1, s2);
        StepVerifier.create(service.getCountryPopulations())
                .as("Expect data source error to be propagated")
                .expectErrorMatches(t -> t instanceof RuntimeException && "Simulated".equals(t.getMessage()))
                .verify();
        // test with delayed error
        final var delayedSourceError = multiSourceStatService(s1, new DelayedStatService(Duration.ofSeconds(2), s2));
        StepVerifier.create(delayedSourceError.getCountryPopulations().subscribeOn(Schedulers.parallel()))
                .as("Expect data source error to be propagated")
                .expectErrorMatches(t -> t instanceof RuntimeException && "Simulated".equals(t.getMessage()))
                .verify();
    }

    private static MultiSourceStatService multiSourceStatService(IStatService... sources) {
        return new MultiSourceStatService(ImmutableList.copyOf(sources));
    }

    private static IStatService noDataStatService() {
        return new ListBackedStatService(ImmutableList.of());
    }

    @SafeVarargs
    private static IStatService listStatService(Pair<String, Integer>... data) {
        return new ListBackedStatService(ImmutableList.copyOf(data));
    }

    @Value
    private static class ListBackedStatService implements IStatService {
        List<Pair<String, Integer>> data;

        @Override
        public Mono<List<Pair<String, Integer>>> getCountryPopulations() {
            return Mono.just(data);
        }
    }

    @Value
    private static class DelayedStatService implements IStatService {
        Duration delay;
        IStatService delegate;

        @Override
        public Mono<List<Pair<String, Integer>>> getCountryPopulations() {
            return Mono.delay(delay).then(delegate.getCountryPopulations());
        }
    }
}
