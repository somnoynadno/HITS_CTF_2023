package com.echo.bugger.service;

import com.echo.bugger.dto.InnerDto;
import com.echo.bugger.filter.JwtAuthentication;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import io.jsonwebtoken.*;
import lombok.extern.slf4j.Slf4j;
import org.springframework.lang.NonNull;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.stereotype.Service;

import java.util.Base64;
import java.util.Date;
import java.util.UUID;

@Service
@Slf4j
public class JwtProvider {
    private final ObjectMapper objectMapper;

    public JwtProvider(ObjectMapper objectMapper) {
        this.objectMapper = objectMapper;
    }


    public boolean validateAccessToken(String accessToken) {
        return validateToken(accessToken);
    }


    public UUID getAccessClaims(String token) throws JsonProcessingException {
        Base64.Decoder decoder = Base64.getDecoder();
        var data = token.split("\\.");
        String b = new String(Base64.getDecoder().decode(data[1].getBytes()));
        InnerDto innerDto = objectMapper.readValue(b, InnerDto.class);
        return UUID.fromString(innerDto.getId());
    }

    public UUID getId() {
        JwtAuthentication authentication = (JwtAuthentication) SecurityContextHolder.getContext().getAuthentication();
        return UUID.fromString(authentication.getFirstName());
    }

    public String getLogin() {
        JwtAuthentication authentication = (JwtAuthentication) SecurityContextHolder.getContext().getAuthentication();
        return authentication.getUsername();
    }

    private Claims getClaims(@NonNull String token) {
        return Jwts.parserBuilder()
                .build()
                .parseClaimsJws(token)
                .getBody();
    }

    private boolean validateToken(@NonNull String token) {
        try {
            Base64.Decoder decoder = Base64.getDecoder();
            var data = token.split("\\.");
            String b = new String(Base64.getDecoder().decode(data[1].getBytes()));
            InnerDto innerDto = objectMapper.readValue(b, InnerDto.class);
            UUID id = UUID.fromString(innerDto.getId());
            Long a = new Long(innerDto.getExp());
            Date date = new Date(a * 1000);
            return !date.before(new Date(System.currentTimeMillis()));
        } catch (ExpiredJwtException expEx) {
            log.error("Token expired", expEx);
        } catch (UnsupportedJwtException unsEx) {
            log.error("Unsupported jwt", unsEx);
        } catch (MalformedJwtException mjEx) {
            log.error("Malformed jwt", mjEx);
        } catch (SignatureException sEx) {
            log.error("Invalid signature", sEx);
        } catch (Exception e) {
            log.error("invalid token", e);
        }
        return false;
    }//Bearer eyJhbGciOiJub25lIn0.eyJzdWIiOiJ0ZXN0ZXIiLCJleHAiOjE2ODUyNjYwMzUsImlkIjoiY2Q5NTcxOGUtOTMzNy00NjdlLTgwMjktYzAxZWM1YmI2MWU0In0=.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c

}
