package com.echo.bugger.controller;

import com.echo.bugger.dto.CredentialsDto;
import com.echo.bugger.dto.ShortUserDto;
import com.echo.bugger.dto.TokenDto;
import com.echo.bugger.dto.UserDto;
import com.echo.bugger.service.UserService;
import io.swagger.annotations.Api;
import lombok.RequiredArgsConstructor;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@Api
@RestController
@RequestMapping(produces = MediaType.APPLICATION_JSON_VALUE)
@RequiredArgsConstructor
public class UserController {

    private final UserService userService;

    @PostMapping(value = "sing-in", consumes = MediaType.APPLICATION_JSON_VALUE)
    public TokenDto singIn(@RequestBody CredentialsDto credentialsDto)
    {
        return userService.singIn(credentialsDto);
    }

    @GetMapping(value = "users")
    public List<ShortUserDto> getAll()
    {
        return userService.getAll();
    }

    @GetMapping(value = "me")
    public UserDto getMe()
    {
        return userService.getMyProfile();
    }

}
