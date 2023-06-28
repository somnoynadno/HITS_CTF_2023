package com.echo.bugger.dto;

import lombok.Data;

import java.util.UUID;

@Data
public class ShortUserDto {
    private String login;
    private UUID id;
}
