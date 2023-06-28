package com.echo.bugger.model;

import lombok.Data;

import java.util.List;
import java.util.UUID;

@Data
public class User {
    private UUID id;
    private String login;
    private String password;
    private List<String> passwords;
}
