package com.quickbase.devint.service.names;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class DefaultCountryNameResolverTest {

    DefaultCountryNameResolver defaultCountryNameResolver = new DefaultCountryNameResolver();

    @Test
    void getOfficialName_returnsOriginalName() {
        assertEquals("TestName", defaultCountryNameResolver.getOfficialName("TestName"));
    }

    @Test
    void getOfficialName_returnsProperName() {
        assertEquals("United States of America", defaultCountryNameResolver.getOfficialName("U.S.A."));
    }
}