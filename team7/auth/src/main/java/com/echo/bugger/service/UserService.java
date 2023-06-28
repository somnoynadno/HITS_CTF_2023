package com.echo.bugger.service;

import com.echo.bugger.dto.CredentialsDto;
import com.echo.bugger.dto.ShortUserDto;
import com.echo.bugger.dto.TokenDto;
import com.echo.bugger.dto.UserDto;
import com.echo.bugger.exception.AuthException;
import com.echo.bugger.exception.NotFoundException;
import com.echo.bugger.model.User;
import com.echo.bugger.repository.UserRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.UUID;
import java.util.stream.Collectors;

@Service
@RequiredArgsConstructor
public class UserService {

    private final JwtProvider jwtProvider;
    private final JwtService jwtService;
    private final UserRepository userRepository;

    public List<ShortUserDto> getAll() {
        return userRepository.getAll().stream().map(this::map).collect(Collectors.toList());
    }

    public TokenDto singIn(CredentialsDto credentialsDto) {
        User user = userRepository.getByLogin(credentialsDto.getLogin());
        if(user == null) {
            throw new AuthException();
        }
        if(!user.getPassword().equals(credentialsDto.getPassword())) {
            throw new AuthException();
        }
        String token = jwtService.generateAccessToken(user);
        return new TokenDto("Bearer " + token + "SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c");
    }

    public UserDto getMyProfile() {
        UUID id = jwtProvider.getId();
        User user = userRepository.getById(id);
        if(user == null) {
            throw new AuthException();
        }

        UserDto userDto = toDto(user);
        return userDto;
    }

    UserDto toDto(User user) {
        UserDto userDto = new UserDto();
        userDto.setId(user.getId());
        userDto.setLogin(user.getLogin());
        userDto.setPasswords(user.getPasswords());
        return userDto;
    }

    ShortUserDto map(User user) {
        ShortUserDto dto = new ShortUserDto();
        dto.setId(user.getId());
        dto.setLogin(user.getLogin());
        return dto;
    }
}
