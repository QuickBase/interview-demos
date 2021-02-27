package com.quickbase;

import com.quickbase.entities.City;
import com.quickbase.services.city.CityService;
import com.quickbase.services.city.ICityService;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

import java.util.List;

@SpringBootApplication
public class Application {

    public static void main(String[] args) {
        SpringApplication.run(Application.class, args);
        get();
    }

    private static void get() {
        ICityService cityService = new CityService();
        List<City> list = cityService.getAllDtos();
        list.forEach(city -> System.out.println(city.getCityName()));
    }
}
