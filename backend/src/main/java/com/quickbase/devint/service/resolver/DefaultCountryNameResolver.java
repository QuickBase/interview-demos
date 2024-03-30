package com.quickbase.devint.service.resolver;

import java.util.Map;

/**
 * Maps alternative to official country names.
 */
public class DefaultCountryNameResolver implements CountryNameResolver {
    // TODO:
    //  1. We need a database if we want to handle the alternative names of all countries.
    //  2. Consider what names should the application return (e.g. ISO 3166).
    private final Map<String, String> officialNameMapping = Map.of("U.S.A.", "United States of America");

    @Override
    public String getOfficialName(String name) {
        return officialNameMapping.getOrDefault(name, name);
    }
}
