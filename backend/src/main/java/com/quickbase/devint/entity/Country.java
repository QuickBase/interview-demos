package com.quickbase.devint.entity;

import lombok.RequiredArgsConstructor;
import lombok.Value;

@Value
@RequiredArgsConstructor(staticName = "of")
public class Country {
    String name;
    Integer population;
}
