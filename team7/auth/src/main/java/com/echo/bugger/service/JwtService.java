package com.echo.bugger.service;

import com.echo.bugger.model.User;
import com.echo.bugger.repository.UserRepository;
import io.jsonwebtoken.Jwts;
import io.jsonwebtoken.io.Decoders;
import io.jsonwebtoken.security.Keys;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Service;

import javax.crypto.SecretKey;
import java.time.Instant;
import java.time.LocalDateTime;
import java.time.ZoneId;
import java.util.Date;

@Service
public class JwtService {

    private final JwtProvider jwtProvider;

    private final UserRepository userRepository;

    public JwtService(JwtProvider jwtProvider, UserRepository userRepository) {
        this.jwtProvider = jwtProvider;
        this.userRepository = userRepository;
    }

    public String generateAccessToken(User user) {
        Date exp = new Date(System.currentTimeMillis() + (1000 * 60 * 60));
        return Jwts.builder()
                .setSubject(user.getLogin())
                .setExpiration(exp)
                .claim("id", user.getId())
                .compact();
    }



}
