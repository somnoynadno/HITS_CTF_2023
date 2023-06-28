package com.echo.bugger.exception;

import org.springframework.http.HttpStatus;

public class AuthException extends CustomException {

    public AuthException(String message, HttpStatus status) {
        super(message, status);
    }

    public AuthException(String message) {
        super(message, HttpStatus.UNAUTHORIZED);
    }

    public AuthException() {
        super("UNAUTHORIZED", HttpStatus.UNAUTHORIZED);
    }

}