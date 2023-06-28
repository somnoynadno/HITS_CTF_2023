package com.echo.bugger.dto;

import lombok.Data;

import java.util.List;
import java.util.UUID;

@Data
public class UserDto {
    private UUID id;
    private String login;
    private List<String> passwords;

}
