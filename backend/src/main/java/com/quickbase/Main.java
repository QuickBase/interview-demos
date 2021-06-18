package com.quickbase;

import com.quickbase.devint.MultiSourceStatService;
import lombok.extern.slf4j.Slf4j;
import org.springframework.beans.BeansException;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.ApplicationContext;
import org.springframework.context.ApplicationContextAware;
import reactor.core.scheduler.Schedulers;

/**
 * The main method of the executable JAR generated from this repository. This is to let you
 * execute something from the command-line or IDE for the purposes of demonstration, but you can choose
 * to demonstrate in a different way (e.g. if you're using a framework)
 */
@SpringBootApplication
@Slf4j
public class Main implements CommandLineRunner, ApplicationContextAware {

    private ApplicationContext context;

    public static void main(String[] args) {
        SpringApplication.run(Main.class, args);
    }

    @Override
    public void run(String... args) {
        log.info("Starting.");

        final var statService = context.getBean(MultiSourceStatService.class);
        final var populations = statService.getCountryPopulations()
                .subscribeOn(Schedulers.parallel())
                .block();

        populations.forEach(p -> System.out.println(String.format("%-35s: %s", p.getKey(), p.getValue())));
    }

    @Override
    public void setApplicationContext(ApplicationContext applicationContext) throws BeansException {
        this.context = applicationContext;
    }
}