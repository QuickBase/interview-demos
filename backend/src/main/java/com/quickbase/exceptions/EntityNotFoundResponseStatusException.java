package com.quickbase.exceptions;

import org.springframework.http.HttpStatus;
import org.springframework.web.server.ResponseStatusException;

public class EntityNotFoundResponseStatusException extends ResponseStatusException {
	public EntityNotFoundResponseStatusException(Class entityClass, Number id) {
		super(HttpStatus.NOT_FOUND, entityClass.getSimpleName() + " with id: " + id + " does not exist in the repository.");
	}
}
